using DepartmentApp.BL.Services.Abstractions;
using DepartmentApp.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentApp.BL.Services.Implementations
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeService(IEmployeeService employeeService)
        {
            _employeeService=employeeService;
        }

        public async Task<ICollection<Employee>> GetAllAsync()
        {
            return await _employeeService.GetAllAsync();
        }
    }
}
