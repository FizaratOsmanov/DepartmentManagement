using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentApp.Core.Base
{
    public abstract class BaseAuditableEntity:BaseEntity
    {
        public DateTime CreatedAt { get; set; }

        public string? CreateBy { get; set; }

        public DateTime? UpdatedAt { get; set; }

        public DateTime? DeletedAt { get; set; }

        public string? DeletedBy { get; set; }
    }
}
