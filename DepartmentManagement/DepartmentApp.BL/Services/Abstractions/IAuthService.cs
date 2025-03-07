﻿using DepartmentApp.BL.DTOs.AppUserDTOs;
using DepartmentApp.Core.Entities;

namespace DepartmentApp.BL.Services.Abstractions;

public interface IAuthService
{
    Task<bool> RegisterAsync(AppUserCreateDTO dto);
    Task<string> LoginAsync(LoginUserDTO dto);
    Task<bool> ConfirmEmailAsync(string userId, string token);
    Task<bool> ChangePasswordAsync(string email, string oldPassword, string newPassword);

    Task<ICollection<AppUserCreateDTO>> GetAllUsersAsync();
    Task<AppUserCreateDTO> GetOneUserAsync(string userName);
}
