using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BackEndProject.Models
{
    public class AppUser:IdentityUser
    {
        public string Fullname { get; set; }
        public bool IsActivated { get; set; }
        public List<Order> Orders{ get; set; }
    }
}
