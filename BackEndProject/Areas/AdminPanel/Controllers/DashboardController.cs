using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BackEndProject.Area.Admin.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
