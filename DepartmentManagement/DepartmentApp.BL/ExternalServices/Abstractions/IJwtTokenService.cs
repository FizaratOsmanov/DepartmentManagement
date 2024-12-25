using DepartmentApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DepartmentApp.BL.ExternalServices.Abstractions
{
    public interface IJwtTokenService
    {
        public string GenerateToken(AppUser user);
    }
}
