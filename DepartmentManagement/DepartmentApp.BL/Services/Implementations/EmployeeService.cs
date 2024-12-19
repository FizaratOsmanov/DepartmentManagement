using DepartmentApp.BL.DTOs.EmployeeDTOs;
using DepartmentApp.BL.Services.Abstractions;
using DepartmentApp.Core;
using DepartmentApp.Data.DAL;
using DepartmentApp.Data.Repositories.Abstractions;

namespace DepartmentApp.BL.Services.Implementations;

public class EmployeeService : IEmployeeService
{
    private readonly AppDbContext _appDbContext;
    private readonly IEmployeeRepository _employeeRepository;
    public EmployeeService(IEmployeeRepository employeeRepository, AppDbContext appDbContext)
    {
        _employeeRepository = employeeRepository;
        _appDbContext = appDbContext;
    }

    public async Task<Employee> CreateAsync(EmployeeAddDTO addDTO)
    {
        Employee employee = new Employee
        {
            Name = addDTO.Name,
            Surname = addDTO.Surname,
            Email = addDTO.Email,
            DepartmentId = addDTO.DepartmentId,
            CreatedAt = DateTime.UtcNow.AddHours(4),
            IsDeleted = false
        };
        return await _employeeRepository.CreateAsync(employee);


    }

    public async Task DeleteAsync(Employee employee)
    {
        employee.IsDeleted = true;
        employee.DeletedAt = DateTime.UtcNow.AddHours(4);
        _employeeRepository.Update(employee);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<ICollection<Employee>> GetAllAsync()
    {

        return await _employeeRepository.GetAllAsync();
    }

    public async Task<Employee> GetByIdAsync(int id)
    {
        return await _employeeRepository.GetByIdAsync(id);
    }

    public async Task UpdateAsync(Employee employee)
    {
        Employee employee1 = await _employeeRepository.GetByIdAsync(employee.Id);
        employee1.Name = employee.Name;
        employee1.Surname = employee.Surname;
        employee1.Email = employee.Email;
        employee1.DepartmentId = employee.DepartmentId;
        employee1.UpdatedAt = DateTime.UtcNow.AddHours(4);
        _employeeRepository.Update(employee1);
        await _appDbContext.SaveChangesAsync();
    }
}
