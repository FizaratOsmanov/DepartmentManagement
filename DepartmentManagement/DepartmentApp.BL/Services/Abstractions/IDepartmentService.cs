using DepartmentApp.BL.DTOs.DepartmentDTOs;
using DepartmentApp.Core;

namespace DepartmentApp.BL.Services.Abstractions
{
    public interface IDepartmentService
    {
        Task<ICollection<Department>> GetAllAsync();

        Task<Department> GetByIdAsync(int id);

        Task<Department> CreateAsync(DepartmentAddDTO addDTO);
        Task UpdateAsync(Department department);
        Task DeleteAsync(Department department);
    }
}
