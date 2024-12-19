using DepartmentApp.BL.DTOs.DepartmentDTOs;
using DepartmentApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentApp.BL.Services.Abstractions
{
    public interface IDepartmentService
    {
        Task<ICollection<Department>> GetAllAsync();

        Task<Department> GetByIdAsync(int id);

        Task<Department> CreateAsync(DepartmentAddDTO addDTO);
        void Update(Department department);
        void Delete(Department department);
    }
}
