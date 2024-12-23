using FluentValidation;
using System.Text.RegularExpressions;
namespace DepartmentApp.BL.DTOs.AppUserDTOs;
public class AppUserCreateDtoValidation : AbstractValidator<AppUserCreateDTO>
{
    public AppUserCreateDtoValidation()
    {
        RuleFor(b => b.FirstName).NotEmpty()
        .WithMessage("Name cannot be empty")
        .NotNull().WithMessage("Name cannot be null")
        .MaximumLength(30).WithMessage("Maximum length is 30");

        RuleFor(b => b.LastName).NotEmpty()
       .WithMessage("Surname cannot be empty")
       .NotNull().WithMessage("Surname cannot be null")
       .MaximumLength(50).WithMessage("Surname Maximum length is 50");

        RuleFor(b => b.Email).Must(e => BeValidEmailAddress(e)).WithMessage("Enter correct email address");

    }

    public  bool BeValidEmailAddress(string email)
    {
        Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        Match match = regex.Match(email);
        if (match.Success) { return true; }
        return false;
    }
}
