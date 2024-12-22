using AutoMapper;
using DepartmentApp.BL.DTOs.DepartmentDTOs;
using DepartmentApp.BL.Exceptions.CommonExceptions;
using DepartmentApp.BL.Services.Abstractions;
using DepartmentApp.Core.Entities;
using DepartmentApp.Data.Repositories.Abstractions;

namespace DepartmentApp.BL.Services.Implementations;
public class DepartmentService:IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository;
    private readonly IMapper _mapper;

    public DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper)
    {
        _departmentRepository = departmentRepository;
        _mapper = mapper;
    }

    public async Task<ICollection<Department>> GetAllAsync()
    {
        return await _departmentRepository.GetAllAsync();
    }

    public async Task<Department> CreateAsync(DepartmentAddDTO dto)
    {
        Department createdDepartment = _mapper.Map<Department>(dto);
        createdDepartment.CreatedAt = DateTime.UtcNow.AddHours(4);
        var createdEntity = await _departmentRepository.CreateAsync(createdDepartment);
        await _departmentRepository.Save();
        return createdEntity;
    }

    public async Task<Department> GetByIdAsync(int id)
    {
        if (!await _departmentRepository.IsExistsAsync(id))
        {
            throw new EntityNotFoundException();
        }
        return await _departmentRepository.GetByIdAsync(id);
    }

    public async Task<bool> SoftDeleteAsync(int id)
    {
        var departmentEntity = await GetByIdAsync(id);
        _departmentRepository.SoftDelete(departmentEntity);
        await _departmentRepository.Save();
        return true;
    }

    public async Task<bool> UpdateAsync(int id, DepartmentAddDTO dto)
    {
        var departmentEntity = await GetByIdAsync(id);
        Department updatedDepartment = _mapper.Map<Department>(dto);
        updatedDepartment.UpdatedAt = DateTime.UtcNow.AddHours(4);
        updatedDepartment.Id = id;
        _departmentRepository.Update(updatedDepartment);
        await _departmentRepository.Save();
        return true;
    }
}
