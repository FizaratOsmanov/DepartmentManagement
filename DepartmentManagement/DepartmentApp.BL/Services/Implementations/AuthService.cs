using AutoMapper;
using DepartmentApp.BL.DTOs.AppUserDTOs;
using DepartmentApp.BL.Exceptions.CommonExceptions;
using DepartmentApp.BL.ExternalServices.Abstractions;
using DepartmentApp.BL.Services.Abstractions;
using DepartmentApp.Core.Entities;
using DepartmentApp.Data.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Net.Mail;
using System.Text.RegularExpressions;

namespace DepartmentApp.BL.Services.Implementations
{
    public class AuthService : IAuthService
    {
        readonly IEmailService _emailService;
        readonly UserManager<AppUser> _userManager;
        readonly SignInManager<AppUser> _signInManager;
        private readonly IJwtTokenService _jwtTokenService;

        private readonly IMapper _mapper;

        public AuthService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, AppDbContext context, IEmailService emailService, IJwtTokenService jwtTokenService, IMapper mapper)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _emailService = emailService;
            _jwtTokenService = jwtTokenService;
            _mapper = mapper;

        }
        public async Task<bool> ChangePasswordAsync(string email, string oldPassword, string newPassword)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user == null)
            {
                throw new Exception("User not found.");
            }

            var result = await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);

            if (!result.Succeeded)
            {
                throw new Exception("Something went wrong");
            }

            return true;
        }

        public async Task<bool> ConfirmEmailAsync(string userId, string token)
        {


            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
                throw new Exception("Invalid user ID.");

            var result = await _userManager.ConfirmEmailAsync(user, token);
            if (!result.Succeeded)
            {
                throw new Exception("Email confirmation failed");
            }
            return true;




        }

        public async Task<ICollection<AppUserCreateDTO>> GetAllUsersAsync()
        {
            ICollection<AppUser> users = await _userManager.Users.ToListAsync();

            ICollection<AppUserCreateDTO> allUsers = _mapper.Map<ICollection<AppUserCreateDTO>>(users);

            return allUsers;
        }

        public async Task<AppUserCreateDTO> GetOneUserAsync(string username)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.UserName == username);
            AppUserCreateDTO oneUser = _mapper.Map<AppUserCreateDTO>(user);
            return oneUser;
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
            if (string.IsNullOrEmpty(appUser.UserName))
            {
                throw new Exception("UserName is required.");
            }
            if (string.IsNullOrEmpty(appUser.Email))
            {
                throw new Exception("Email is required.");
            }
            if (!new EmailAddressAttribute().IsValid(appUser.Email))
            {
                throw new Exception("Email is not valid.");
            }
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

        public async Task<string> LoginAsync(LoginUserDTO dto)
        {
            AppUser? user = await _userManager.FindByNameAsync(dto.UserName);
            if (user == null)
            {
                throw new EntityNotFoundException();
            }

            bool result = await _userManager.CheckPasswordAsync(user, dto.Password);

            if (!result)
            {
                throw new Exception("Username or password is wrong");
            }
            string token = _jwtTokenService.GenerateToken(user);
            return token;

        }

    }
}
