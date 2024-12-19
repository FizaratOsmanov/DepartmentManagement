using DepartmentApp.BL.DTOs.DepartmentDTOs;
using DepartmentApp.BL.Services.Abstractions;
using DepartmentApp.Core;
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



    [HttpGet]
    public async Task<IActionResult> GetAllDepartments()
    {
        var department=await _departmentService.GetAllAsync();
        return Ok(department);
    }   



    [HttpGet("{id}")]
    public async Task<IActionResult> GetDepartmentById(int id)
    {
        var department=await _departmentService.GetByIdAsync(id);
        return Ok(department);
    }



    [HttpPost]
    public async Task<IActionResult> CreateDepartment(DepartmentAddDTO addDTO)
    {
        await _departmentService.CreateAsync(addDTO);
        return Ok(addDTO);
    }



    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDepartment(Department department)
    {
        await _departmentService.UpdateAsync(department);
        return Ok(department);
    }



    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDepartment(Department department)
    {
        await _departmentService.DeleteAsync(department);
        return Ok();
    }



}
