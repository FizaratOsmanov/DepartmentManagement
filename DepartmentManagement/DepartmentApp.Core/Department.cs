using DepartmentApp.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentApp.Core
{
    public class Department:BaseAuditableEntity
    {
        public string Name {  get; set; }
        public string Description { get; set; }

        public IEnumerable<Employee> Employees { get; set; }
    }
}
