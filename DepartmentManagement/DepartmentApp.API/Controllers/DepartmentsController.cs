using DepartmentApp.BL.DTOs.DepartmentDTOs;
using DepartmentApp.BL.Services.Abstractions;
using DepartmentApp.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DepartmentsController : ControllerBase
{
    private readonly IDepartmentService _departmentService;

    public DepartmentsController(IDepartmentService departmentService)
    {
        _departmentService = departmentService;
    }



    [HttpPost]
    public async Task<IActionResult> CreateDepartment(DepartmentAddDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        };
        return StatusCode(StatusCodes.Status200OK, await _departmentService.CreateAsync(dto));
    }

    [HttpGet]  
    public async Task<ICollection<Department>> GetAllDepartment()
    {
        return await _departmentService.GetAllAsync();
    }


    [HttpGet("{id}")]

    public async Task<Department> GetDepartmentById(int id)
    {
        return await _departmentService.GetByIdAsync(id);
    }


    [HttpDelete("{id}")]

    public async Task<bool> DeleteDepartment(int id)
    {
        return await _departmentService.SoftDeleteAsync(id);
    }


    [HttpPut("{id}")]
    public async Task<bool> UpdateDepartment(int id, DepartmentAddDTO dto)
    {
        return await _departmentService.UpdateAsync(id, dto);
        
    }


}
