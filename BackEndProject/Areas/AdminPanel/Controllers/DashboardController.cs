using BackEndProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BackEndProject.Area.Admin.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public class DashboardController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;

        public DashboardController
            (UserManager<AppUser> usermanager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<AppUser> signInManager
            )
        {
            _userManager = usermanager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }
        public async Task<IActionResult> Index()
        {
            ViewBag.AdminEmail = "";
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.AdminEmail= $"{user.Email}";
            }
            return View();
        }
    }
}



