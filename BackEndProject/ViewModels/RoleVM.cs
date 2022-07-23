using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BackEndProject.ViewModels
{
    public class RoleVM
    {
        
            public string UserId { get; set; }
        public string Fullname { get; internal set; }
        public List<IdentityRole> Roles { get; set; }

            public IList<string> UserRoles { get; set; }
        
    }
}