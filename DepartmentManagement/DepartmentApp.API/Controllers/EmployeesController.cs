using DepartmentApp.BL.DTOs.EmployeeDTOs;
using DepartmentApp.BL.Services.Abstractions;
using DepartmentApp.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DepartmentApp.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class EmployeesController : ControllerBase
{


    private readonly IEmployeeService _employeeService;

    public EmployeesController(IEmployeeService employeeService)
    {
        _employeeService = employeeService;
    }


    [HttpPost("Create")]
    public async Task<IActionResult> CreateEmployee(EmployeeAddDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        };
        return StatusCode(StatusCodes.Status200OK, await _employeeService.CreateAsync(dto));
    }





    [HttpGet("GetAll")]
    public async Task<ICollection<Employee>> GetAllEmployee()
    {
        return await _employeeService.GetAllAsync();
    }




    [HttpGet("{id}")]
    public async Task<Employee> GetEmployeeById(int id)
    {
        return await _employeeService.GetByIdAsync(id);
    }


    [HttpDelete("{id}")]

    public async Task<bool> DeleteEmployee(int id)
    {
        return await _employeeService.SoftDeleteAsync(id);
    }


    [HttpPut("{id}")]
    public async Task<bool> UpdateEmployee(int id, EmployeeAddDTO dto)
    {
        return await _employeeService.UpdateAsync(id, dto);

    }

}
