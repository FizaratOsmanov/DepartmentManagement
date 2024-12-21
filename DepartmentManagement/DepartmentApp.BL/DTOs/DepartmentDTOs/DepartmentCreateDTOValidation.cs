using DepartmentApp.Core.Entities;
using FluentValidation;

namespace DepartmentApp.BL.DTOs.DepartmentDTOs
{
    public class DepartmentCreateDTOValidation:AbstractValidator<Department>
    {
        public DepartmentCreateDTOValidation()
        {
            RuleFor(x => x.Name).NotEmpty()
                .WithMessage("Name cannot be empty")
                .NotNull().WithMessage("Name cannot be null")
                .MaximumLength(100).WithMessage("Max length is 100");
            RuleFor(y => y.Description).NotEmpty()
                .WithMessage("Description cannot be empty")
                .NotNull().WithMessage("Description cannot be null")
                .MaximumLength(250).WithMessage("Max length is 250");
        }
    }
}
