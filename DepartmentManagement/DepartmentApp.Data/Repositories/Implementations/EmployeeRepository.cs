using DepartmentApp.Core;
using DepartmentApp.Data.DAL;
using DepartmentApp.Data.Repositories.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentApp.Data.Repositories.Implementations
{
    public class EmployeeRepository :  GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext appDbContext):base(appDbContext) { }
    }
}
