using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentApp.BL.DTOs.EmployeeDTOs
{
    public class EmployeeAddDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string? Email { get; set; }

        public int DepartmentId { get; set; }
    }
}
