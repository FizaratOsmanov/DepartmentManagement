using AutoMapper;
using DepartmentApp.BL.DTOs.DepartmentDTOs;
using DepartmentApp.BL.DTOs.EmployeeDTOs;
using DepartmentApp.Core.Entities;

namespace DepartmentApp.BL.Profiles.EmployeeProfiles
{
    public class EmployeeProfile:Profile
    {
        public EmployeeProfile()
        {
            CreateMap<EmployeeAddDTO, Employee>();
            CreateMap<EmployeeAddDTO, Employee>().ReverseMap();
        }
    }
}
