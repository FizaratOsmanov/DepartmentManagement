using DepartmentApp.BL.DTOs.AppUserDTOs;

namespace DepartmentApp.BL.Services.Abstractions;

public interface IAuthService
{
    Task<bool> RegisterAsync(AppUserCreateDTO dto);

}
