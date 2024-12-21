using DepartmentApp.BL;
using DepartmentApp.BL.DTOs.DepartmentDTOs;
using DepartmentApp.BL.DTOs.EmployeeDTOs;
using DepartmentApp.BL.Profiles.DepartmentProfiles;
using DepartmentApp.BL.Profiles.EmployeeProfiles;
using DepartmentApp.Core.Entities;
using DepartmentApp.Data.DAL;
using DepartmentApp.Data.Repositories.Abstractions;
using DepartmentApp.Data.Repositories.Implementations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
builder.Services.AddBusinessServices();
builder.Services.AddIdentity<AppUser, IdentityRole>(opt =>
{
    {

        opt.Password.RequiredLength = 8;
        opt.User.RequireUniqueEmail = true;
        opt.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789._";
        opt.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
        opt.Lockout.MaxFailedAccessAttempts = 3;
    }
}).AddDefaultTokenProviders().AddEntityFrameworkStores<AppDbContext>();

//new version 
builder.Services.AddAutoMapper(typeof(DepartmentProfile));
builder.Services.AddValidatorsFromAssembly(typeof(DepartmentCreateDTOValidation).Assembly);
builder.Services.AddAutoMapper(typeof(EmployeeProfile));
builder.Services.AddValidatorsFromAssembly(typeof(EmployeeCreateDTOValidation).Assembly);
builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("FiziSQL"));
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
