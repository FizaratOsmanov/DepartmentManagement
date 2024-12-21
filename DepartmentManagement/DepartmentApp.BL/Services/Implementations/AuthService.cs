using AutoMapper;
using DepartmentApp.BL.DTOs.AppUserDTOs;
using DepartmentApp.BL.Services.Abstractions;
using DepartmentApp.Core.Entities;
using Microsoft.AspNetCore.Identity;

namespace DepartmentApp.BL.Services.Implementations
{
    public class AuthService:IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;

        public AuthService(UserManager<AppUser> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
        }

        public async Task<bool> RegisterAsync(AppUserCreateDTO dto)
        {
            AppUser user = _mapper.Map<AppUser>(dto);
            var result = await _userManager.CreateAsync(user, dto.Password);
            if (!result.Succeeded)
            {
                throw new Exception("Could not create user");
            }
            return true;

        }
    }
}
