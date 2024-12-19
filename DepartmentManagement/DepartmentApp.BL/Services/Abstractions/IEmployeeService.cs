using DepartmentApp.BL.DTOs.DepartmentDTOs;
using DepartmentApp.BL.DTOs.EmployeeDTOs;
using DepartmentApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentApp.BL.Services.Abstractions
{
    public interface IEmployeeService
    {
        Task<ICollection<Employee>> GetAllAsync();

        Task<Employee> GetByIdAsync(int id);

        Task<Employee> CreateAsync(EmployeeAddDTO addDTO);
        void Update(Employee employee);
        void Delete(Employee employee);

    }
}
