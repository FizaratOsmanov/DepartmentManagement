using DepartmentApp.BL.DTOs.EmployeeDTOs;
using DepartmentApp.Core;

namespace DepartmentApp.BL.Services.Abstractions
{
    public interface IEmployeeService
    {
        Task<ICollection<Employee>> GetAllAsync();

        Task<Employee> GetByIdAsync(int id);

        Task<Employee> CreateAsync(EmployeeAddDTO addDTO);
        Task UpdateAsync(Employee employee);
        Task DeleteAsync(Employee employee);

    }
}
