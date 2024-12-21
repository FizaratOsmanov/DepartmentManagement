using DepartmentApp.BL.DTOs.DepartmentDTOs;
using DepartmentApp.BL.Services.Abstractions;
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
    public async Task<IActionResult> Create(DepartmentAddDTO dto)
    {
        if (!ModelState.IsValid)
        {
            return StatusCode(StatusCodes.Status400BadRequest, ModelState);
        };
        return StatusCode(StatusCodes.Status200OK, await _departmentService.CreateAsync(dto));
    }



}
