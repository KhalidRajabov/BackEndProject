using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public async  Task<IActionResult> Index()
        {
            var product = await _context.Products.Where(p => p.IsDeleted != true).Include(pi => pi.ProductImages).ToListAsync();
            HomeVM homeVM = new HomeVM();
            homeVM.Sliders = await _context.Sliders.ToListAsync();
            homeVM.Categories = await _context.Categories.Where(p => p.IsDeleted != true).Where(c=>c.ParentId==null).ToListAsync();
            homeVM.Products =await _context.Products.Where(p=>p.IsDeleted!=true).Take(7)
            .Include(pi=>pi.ProductImages).Include(pc=>pc.Category).Include(b=>b.Brand)
            .Include(tp=>tp.ProductTags).ThenInclude(t=>t.Tags).ToListAsync();
            homeVM.FeaturedProducts= await _context.Products
                .Where(p=>p.IsFeatured==true).Where(p=>p.IsDeleted!=true)
                .Include(i=>i.ProductImages).ToListAsync();
            //homeVM.ProductImages = await _context.ProductImages.Include(pi => pi.Product).ToListAsync();
            var NewProduct = product.Where(n => n.NewArrival).ToList();
            var Bestseller = product.Where(b=>b.Bestseller).ToList();
            var Featured = product.Where(f => f.IsFeatured).ToList();
            var IsMain = await _context.ProductImages.Where(m=>m.IsMain).ToListAsync();

            ViewBag.NewProducts = NewProduct;
            ViewBag.Bestseller = Bestseller;
            ViewBag.Featured = Featured;
            ViewBag.IsMain = IsMain;
            return View(homeVM);
        }
        public IActionResult SearchProduct(string search)
        {
            List<Product> products = _context.Products
                .Include(p => p.Category)
                .OrderBy(p => p.Id).Where(p=>p.IsDeleted!=true).Where(p => p.Name.ToLower().Contains(search.ToLower()))
                .Take(10).ToList();

            return PartialView("_SearchPartial", products);
        }
        
        
        public IActionResult Shop(int page = 1, int take = 12)
        {

            List<Product> product = _context.Products.Where(p=>p.IsDeleted!=true)
                .Include(p => p.Category).Where(c=>c.IsDeleted!=true)
                .Include(pi => pi.ProductImages).Skip((page - 1) * take).Take(take).ToList();
            PaginationVM<Product> paginationVM = new PaginationVM<Product>(product, PageCount(take), page);

            return View(paginationVM);
        }

        private int PageCount(int take)
        {
            List<Product> products = _context.Products.Where(p => p.IsDeleted != true).ToList();
            return (int)Math.Ceiling((decimal)products.Count() / take);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Product product = await _context.Products
                .Include(b=>b.Brand)
                .Include(i=>i.ProductImages)
                .Include(pt=>pt.ProductTags).ThenInclude(t=>t.Tags)
                .FirstOrDefaultAsync(p => p.Id == id);
            HomeVM vm = new HomeVM();
            vm.SingleProduct = product;
            vm.Products = _context.Products.Where(p => p.IsDeleted != true).Include(i => i.ProductImages).ToList();
            return View(vm);
        }


    }
}
