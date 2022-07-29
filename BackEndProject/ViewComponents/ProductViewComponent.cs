using BackEndProject.DAL;
using BackEndProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewComponents
{
    public class ProductViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        
        public ProductViewComponent(AppDbContext context)
        {
            _context = context;
            
        }

        public async Task<IViewComponentResult> InvokeAsync( int take)
        {
            List<Product> product = _context.Products.Where(p => p.IsDeleted != true).Include(pi => pi.ProductImages).Take(take).ToList();
            return View(await Task.FromResult(product));
        }
    }
}
