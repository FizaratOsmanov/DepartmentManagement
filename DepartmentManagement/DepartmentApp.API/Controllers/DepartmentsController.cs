using DepartmentApp.BL.DTOs.DepartmentDTOs;
using DepartmentApp.BL.Services.Abstractions;
using DepartmentApp.Core;
using DepartmentApp.Data.DAL;
using Microsoft.AspNetCore.Http;
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
    public async Task<ICollection<Department>> GetAll()
    {
        return await _departmentService.GetAllAsync();
    }   

    [HttpPost]
    public async Task<Department> Create(DepartmentAddDTO addDTO)
    {
        return await _departmentService.CreateAsync(addDTO);
    }
}
