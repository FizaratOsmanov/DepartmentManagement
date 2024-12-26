using AutoMapper;
using DepartmentApp.BL.DTOs.AppUserDTOs;
using DepartmentApp.Core.Entities;

namespace DepartmentApp.BL.Profiles.AppUserProfiles
{
    public class AppUserProfile:Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser, AppUserCreateDTO>();
            CreateMap<AppUserCreateDTO, AppUser>();

        }
    }
}
