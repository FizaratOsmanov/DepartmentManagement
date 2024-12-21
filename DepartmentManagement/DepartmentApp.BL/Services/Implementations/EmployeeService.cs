using AutoMapper;
using DepartmentApp.BL.DTOs.EmployeeDTOs;
using DepartmentApp.BL.Exceptions.CommonExceptions;
using DepartmentApp.BL.Services.Abstractions;
using DepartmentApp.Core.Entities;
using DepartmentApp.Data.Repositories.Abstractions;

namespace DepartmentApp.BL.Services.Implementations;

public class EmployeeService : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IMapper _mapper;

    public EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper)
    {
        _employeeRepository = employeeRepository;
        _mapper = mapper;
    }


    public async Task<ICollection<Employee>> GetAllAsync()
    {
        return await _employeeRepository.GetAllAsync();
    }



    public async Task<Employee> CreateAsync(EmployeeAddDTO dto)
    {
        Employee createdEmployee = _mapper.Map<Employee>(dto);
        createdEmployee.CreatedAt = DateTime.UtcNow.AddHours(4);
        var createdEntity = await _employeeRepository.CreateAsync(createdEmployee);
        await _employeeRepository.SaveChangesAsync();
        return createdEntity;
    }



    public async Task<Employee> GetByIdAsync(int id)
    {
        if (!await _employeeRepository.IsExistsAsync(id))
        {
            throw new EntityNotFoundException();
        }
        return await _employeeRepository.GetByIdAsync(id);

    }



    public async Task<bool> SoftDeleteAsync(int id)
    {
        var employeeEntity = await GetByIdAsync(id);
        _employeeRepository.SoftDelete(employeeEntity);
        await _employeeRepository.SaveChangesAsync();
        return true;
    }



    public async Task<bool> UpdateAsync(int id, EmployeeAddDTO dto)
    {
        var employeeEntity = await GetByIdAsync(id);
        Employee updatedEmployee = _mapper.Map<Employee>(dto);
        updatedEmployee.UpdatedAt = DateTime.UtcNow.AddHours(4);
        updatedEmployee.Id = id;
        _employeeRepository.Update(employeeEntity);
        await _employeeRepository.SaveChangesAsync();
        return true;

    }
}
