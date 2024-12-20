using DepartmentApp.Core;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentApp.BL.DTOs.EmployeeDTOs;

public class EmployeeAddDTO
{
    public string Name { get; set; }
    public string Surname { get; set; }

    public string Email { get; set; }

    public int DepartmentId { get; set; }
}

public class EmployeeCreateDTOValidation : AbstractValidator<Employee>
{
    public EmployeeCreateDTOValidation()
    {
        RuleFor(x => x.Name).NotEmpty().NotNull().WithMessage("Name cannot be empty or null").MaximumLength(100).WithMessage("Max length is 100");
        RuleFor(x => x.Surname).NotEmpty().NotNull().WithMessage("Surname cannot be empty or null").MaximumLength(250).WithMessage("Max length is 250");
        RuleFor(x=>x.Email).NotEmpty().NotNull().WithMessage("Email cannot be empty or null").Matches(@"^[^@]+@[^@]+\.[^@]+$").WithMessage("Email is not true");
        RuleFor(x => x.DepartmentId).NotEmpty().NotNull().WithMessage("DepartmentId cannot be empty or null");
    }
}
