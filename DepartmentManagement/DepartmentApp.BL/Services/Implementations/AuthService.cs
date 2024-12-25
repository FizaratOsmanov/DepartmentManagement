using AutoMapper;
using DepartmentApp.BL.DTOs.AppUserDTOs;
using DepartmentApp.BL.Exceptions.CommonExceptions;
using DepartmentApp.BL.Services.Abstractions;
using DepartmentApp.Core.Entities;
using DepartmentApp.Data.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net.Mail;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace DepartmentApp.BL.Services.Implementations
{
    public class AuthService : IAuthService
    {
        readonly IEmailService _emailService;
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        private readonly IMapper _mapper;

        public AuthService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext context, IEmailService emailService, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailService = emailService;
            _mapper = mapper;
        }
        public Task ChangePasswordAsync(string email, string oldPassword, string newPassword)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> ConfirmEmailAsync(string userId, string token)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                throw new Exception("Invalid user.");
            }

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
                throw new Exception("Email confirmation failed.");
            }
            return true;
        }

        public async Task<ICollection<AppUserCreateDTO>> GetAllUsersAsync()
        {
            ICollection<AppUser> users = await _userManager.Users.ToListAsync();

            ICollection<AppUserCreateDTO> allUsers = _mapper.Map<ICollection<AppUserCreateDTO>>(users);

            return allUsers;
        }

        public async Task<AppUserCreateDTO> GetOneUserAsync(string userName)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == userName);
            AppUserCreateDTO oneUser = _mapper.Map<AppUserCreateDTO>(user);
            return oneUser;
        }















        public async Task<string> LoginAsync(LoginUserDTO dto)
        {
            AppUser? user = await _userManager.FindByNameAsync(dto.Username);
            if (user == null)
            {
                throw new EntityNotFoundException("Not found");
            }
            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, true);
            if (!result.Succeeded)
            {
                throw new Exception("Something went wrong");
            }

            string issuer = "http://localhost:5201/";
            string audience = "http://localhost:5201/";

            SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("0b1f61d2-42ed-48bb-ba11-fdef1ae13c83"));
            SigningCredentials signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.Sha256);

            List<Claim> claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.NameIdentifier,user.Id));
            claims.Add(new Claim(ClaimTypes.GivenName,user.FirstName));
            claims.Add(new Claim(ClaimTypes.Name,user.UserName));

            JwtSecurityToken token = new JwtSecurityToken(            
                issuer:issuer,
                audience:audience,
                signingCredentials:signingCredentials,
                claims:claims,
                expires: DateTime.UtcNow.AddMinutes(60)
                );
            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var Token=handler.WriteToken(token);
            return Token;


        }

























        public async Task<bool> RegisterAsync(AppUserCreateDTO dto)
        {

            MailAddress email = new MailAddress(dto.Email);

            string pattern = @"^\+994(50|51|55|70|77)\d{7}$";
            Regex regex = new Regex(pattern);

            if (!regex.IsMatch(dto.PhoneNumber))
            {
                throw new Exception("Phone number is not valid");
            }

            AppUser appUser = _mapper.Map<AppUser>(dto);
            var result = await _userManager.CreateAsync(appUser, dto.Password);
            if (!result.Succeeded)
            {
                if (result.Errors.Any(e => e.Code == "DuplicateEmail"))
                {
                    throw new Exception("You have already been registered with this email.");
                }
                throw new Exception("Something went wrong.");
            }
            return true;
        }
    }
}
