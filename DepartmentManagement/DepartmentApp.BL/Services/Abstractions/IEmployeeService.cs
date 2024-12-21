using DepartmentApp.BL.DTOs.EmployeeDTOs;
using DepartmentApp.Core.Entities;

namespace DepartmentApp.BL.Services.Abstractions;

public interface IEmployeeService
{
    Task<ICollection<Employee>> GetAllAsync();
    Task<Employee> CreateAsync(EmployeeAddDTO dto);
    Task<Employee> GetByIdAsync(int id);
    Task<bool> SoftDeleteAsync(int id);
    Task<bool> UpdateAsync(int id, EmployeeAddDTO dto);

}
