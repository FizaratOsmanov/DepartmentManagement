using DepartmentApp.BL.Services.Abstractions;
using DepartmentApp.BL.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;

namespace DepartmentApp.BL
{
    public static class ConfigurationServices
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IDepartmentService, DepartmentService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IAuthService, AuthService>();
        }
    }
}
