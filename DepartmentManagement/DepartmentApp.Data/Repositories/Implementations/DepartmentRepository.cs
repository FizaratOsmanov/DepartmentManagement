using DepartmentApp.Core.Entities;
using DepartmentApp.Data.DAL;
using DepartmentApp.Data.Repositories.Abstractions;

namespace DepartmentApp.Data.Repositories.Implementations;

public class DepartmentRepository : GenericRepository<Department>, IDepartmentRepository
{
    public DepartmentRepository(AppDbContext appDbContext) : base(appDbContext) { }

}
