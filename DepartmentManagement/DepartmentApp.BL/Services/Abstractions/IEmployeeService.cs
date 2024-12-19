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

    }
}
