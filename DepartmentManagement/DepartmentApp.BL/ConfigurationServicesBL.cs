using DepartmentApp.BL.DTOs.DepartmentDTOs;
using DepartmentApp.BL.DTOs.EmployeeDTOs;
using DepartmentApp.BL.ExternalServices.Abstractions;
using DepartmentApp.BL.ExternalServices.Implementations;
using DepartmentApp.BL.Profiles.DepartmentProfiles;
using DepartmentApp.BL.Profiles.EmployeeProfiles;
using DepartmentApp.BL.Services.Abstractions;
using DepartmentApp.BL.Services.Implementations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DepartmentApp.BL
{
    public static class ConfigurationServicesBL
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IJwtTokenService,JwtTokenService>();

        }

        public static void AddProfileServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DepartmentProfile));
            services.AddValidatorsFromAssembly(typeof(DepartmentCreateDTOValidation).Assembly);
            services.AddAutoMapper(typeof(EmployeeProfile));
            services.AddValidatorsFromAssembly(typeof(EmployeeCreateDTOValidation).Assembly);
        }
    }
}
