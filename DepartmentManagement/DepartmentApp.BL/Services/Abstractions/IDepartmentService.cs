using DepartmentApp.BL.DTOs.DepartmentDTOs;
using DepartmentApp.Core.Entities;

namespace DepartmentApp.BL.Services.Abstractions;

public interface IDepartmentService
{
    Task<ICollection<Department>> GetAllAsync();
    Task<Department> CreateAsync(DepartmentAddDTO dto);
    Task<Department> GetByIdAsync(int id);
    Task<bool> SoftDeleteAsync(int id);
    Task<bool> UpdateAsync(int id, DepartmentAddDTO dto);
}
