using DepartmentApp.BL.DTOs.DepartmentDTOs;
using DepartmentApp.BL.Services.Abstractions;
using DepartmentApp.Core;
using DepartmentApp.Data.DAL;
using DepartmentApp.Data.Repositories.Abstractions;

namespace DepartmentApp.BL.Services.Implementations;
public class DepartmentService:IDepartmentService
{

    private readonly AppDbContext _appDbContext;
    private readonly IDepartmentRepository _departmentRepository;
    public DepartmentService(IDepartmentRepository departmentRepository,AppDbContext appDbContext)
    {
        _departmentRepository = departmentRepository;
        _appDbContext = appDbContext;
    }

    public async Task<Department> CreateAsync(DepartmentAddDTO addDTO)
    {
        Department department = new Department
        {
            Name = addDTO.Name,
            Description = addDTO.Description,
            CreatedAt = DateTime.UtcNow.AddHours(4), 
            IsDeleted = false
        };
        return await _departmentRepository.CreateAsync(department);

    }

    public async Task DeleteAsync(Department department)
    {
        department.IsDeleted = true;
        department.DeletedAt = DateTime.UtcNow.AddHours(4); 
        _departmentRepository.Update(department);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<ICollection<Department>> GetAllAsync()
    {

        return await _departmentRepository.GetAllAsync();
    }

    public async Task<Department> GetByIdAsync(int id)
    {
        return await _departmentRepository.GetByIdAsync(id);       
    } 

    public async Task UpdateAsync(Department department)
    {
        Department department1 = await _departmentRepository.GetByIdAsync(department.Id);
        department1.Name = department.Name;
        department1.Description = department.Description;
        department1.UpdatedAt = DateTime.UtcNow.AddHours(4);
        _departmentRepository.Update(department1);
        await _appDbContext.SaveChangesAsync();
    }
}
