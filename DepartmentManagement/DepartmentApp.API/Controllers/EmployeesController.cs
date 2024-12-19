using DepartmentApp.BL.DTOs.DepartmentDTOs;
using DepartmentApp.BL.DTOs.EmployeeDTOs;
using DepartmentApp.BL.Services.Abstractions;
using DepartmentApp.Core;
using Microsoft.AspNetCore.Http;
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



    [HttpGet]
    public async Task<IActionResult> GetAllEmployees()
    {
        var employee = await _employeeService.GetAllAsync();
        return Ok(employee);
    }



    [HttpGet("{id}")]
    public async Task<IActionResult> GetEmployeeById(int id)
    {
        var employee = await _employeeService.GetByIdAsync(id);
        return Ok(employee);
    }



    [HttpPost]
    public async Task<IActionResult> CreateEmployee(EmployeeAddDTO addDTO)
    {
        await _employeeService.CreateAsync(addDTO);
        return Ok(addDTO);
    }



    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateEmployee(Employee employee)
    {
        await _employeeService.UpdateAsync(employee);
        return Ok(employee);
    }



    [HttpDelete("id")]
    public async Task<IActionResult> DeleteEmployee(Employee employee)
    {
        await _employeeService.DeleteAsync(employee);
        return Ok();
    }
}
