using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public class OrdersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;
        public OrdersController
            (UserManager<AppUser> usermanager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<AppUser> signInManager,
            AppDbContext context)
        {
            _userManager = usermanager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
       
            


            return View();
        }

        public async Task<IActionResult> Detail(int id)
        {
          
            Order order = await _context.Orders.Include(u=>u.AppUser).FirstOrDefaultAsync(o=>o.Id==id);
            List<OrderItem> orderItems = _context.OrderItems.Include(p=>p.Product).Where(i=>i.Id==order.Id).ToList();
            if(order == null) return NotFound();
            return View(orderItems);
        }
    }
}
