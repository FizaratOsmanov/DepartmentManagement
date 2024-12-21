using Microsoft.AspNetCore.Identity;

namespace DepartmentApp.Core.Entities
{
    public class AppUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
