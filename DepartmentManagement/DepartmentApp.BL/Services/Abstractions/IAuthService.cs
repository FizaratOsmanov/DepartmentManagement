using DepartmentApp.BL.DTOs.AppUserDTOs;
using DepartmentApp.Core.Entities;

namespace DepartmentApp.BL.Services.Abstractions;

public interface IAuthService
{
    Task<bool> RegisterAsync(AppUserCreateDTO dto);
    Task<bool> ConfirmEmail(string userId, string token);

}
