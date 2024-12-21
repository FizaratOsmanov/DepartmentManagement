using AutoMapper;
using DepartmentApp.BL.DTOs.DepartmentDTOs;
using DepartmentApp.Core.Entities;

namespace DepartmentApp.BL.Profiles.DepartmentProfiles
{
    public class DepartmentProfile:Profile
    {
        public DepartmentProfile()
        {
            CreateMap<DepartmentAddDTO, Department>();
            CreateMap<DepartmentAddDTO, Department>().ReverseMap();
        }
    }
}
