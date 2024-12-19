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
    public async Task<ICollection<Employee>> GetAll()
    {
        return await _employeeService.GetAllAsync();
    }

    [HttpPost]
    public async Task<Employee> Create(EmployeeAddDTO addDTO)
    {
        return await _employeeService.CreateAsync(addDTO);
    }
}
