using DepartmentApp.Core.Entities;
using DepartmentApp.Data.DAL;
using DepartmentApp.Data.Repositories.Abstractions;

namespace DepartmentApp.Data.Repositories.Implementations;

public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(AppDbContext appDbContext) : base(appDbContext) { }
}
