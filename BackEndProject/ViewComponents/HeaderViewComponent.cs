using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewComponents
{
    public class HeaderViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly UserManager<AppUser> _userManager;
        public HeaderViewComponent(AppDbContext context, UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }   

        public async Task<IViewComponentResult> InvokeAsync()
        {
            string username = "";
            if (User.Identity.IsAuthenticated)
            {
                username = User.Identity.Name;
            }
            ViewBag.UserId = "";
            ViewBag.UserRole = "";
            ViewBag.User = "Login";
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _userManager.FindByNameAsync(User.Identity.Name);
                ViewBag.User = user.UserName;
                ViewBag.UserId = user.Id;
                var roles = (await _userManager.GetRolesAsync(user));
                foreach (var item in roles)
                {
                    if (item.ToLower().Contains("admin"))
                    {
                        ViewBag.UserRole = "admin";
                    }
                }

            }
            HeaderComponentVM hdVM = new HeaderComponentVM();
            hdVM.Bio = _context.Bios.FirstOrDefault();
            hdVM.Categories = _context.Categories.Where(c=>c.IsDeleted!=true).Where(c => c.ParentId == null).ToList();
            ViewBag.BasketCount = 0;
            ViewBag.TotalPrice = 0;
            ViewBag.Products = "";
            var product = _context.Products.Where(p => p.IsDeleted != true).ToList();
            int TotalCount = 0;
            double TotalPrice = 0;
            string basket = Request.Cookies[$"basket{username}"];
            if (basket != null)
            {
                List<BasketVM> products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                foreach (var item in products)
                {
                    TotalCount += item.ProductCount;
                }
                foreach (var item in products)
                {
                    TotalPrice += item.Price * item.ProductCount;
                }
            }
            ViewBag.BasketCount = TotalCount;
            ViewBag.TotalPrice = TotalPrice;
            return View(await Task.FromResult(hdVM));
        }
    }
}
