﻿namespace DepartmentApp.BL.DTOs.AppUserDTOs
{
    public class ChangePasswordDTO
    {
        public string Email { get; set; }
        public string OldPassword { get; set; }
        public string NewPassword { get; set; }
    }
}