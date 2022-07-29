using BackEndProject.DAL;
using BackEndProject.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewComponents
{
    public class BrandViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;

        public BrandViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(int take)
        {
            List<Brand> brands = _context.Brands.Where(b => b.IsDeleted != true).Take(take).ToList();
            return View(await Task.FromResult(brands));
        }
    }
}
