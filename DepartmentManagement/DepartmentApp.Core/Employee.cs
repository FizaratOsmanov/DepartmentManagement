using DepartmentApp.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentApp.Core
{
    public class Employee:BaseAuditableEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string? Email { get; set; }

        public int DepartmentId { get; set; }
        public Department? Department { get; set; }

    }
}
