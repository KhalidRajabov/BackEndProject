using BackEndProject.DAL;
using BackEndProject.Extensions;
using BackEndProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public class BrandController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;
        public BrandController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Brand> brands = _context.Brands.Where(b=>b.IsDeleted!=true).ToList();
            return View(brands);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Brand brand)
        {
            if (brand.Photo == null)
            {
                ModelState.AddModelError("Photo", "Do not leave it empty");
                return View();
            }

            if (!brand.Photo.IsImage())
            {
                ModelState.AddModelError("Photo", "Do not leave it empty");
                return View();
            }
            if (brand.Photo.ValidSize(10000))
            {
                ModelState.AddModelError("Photo", "Image size can not be large");
                return View();
            }
            
            if (!ModelState.IsValid)
            {
                return View();
            }

            bool isValid = _context.Brands.Any(c => c.Name.ToLower() == brand.Name.ToLower());
            if (isValid)
            {
                ModelState.AddModelError("Name", "This category name already exists");
                return View();
            }
            brand.ImageUrl = brand.Photo.SaveImage(_env, "images/brand");
            brand.CreatedTime = System.DateTime.Now;
            await _context.Brands.AddAsync(brand);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }


        public async Task<IActionResult> Update(int? id)
        {
            
            if (id == null) return NotFound();
            Brand brand= await _context.Brands.FindAsync(id);
            if (brand == null) return NotFound();
            return View(brand);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Brand brand)
        {
            
            if (!ModelState.IsValid) return View();
            if (id == null) return NotFound();
            Brand dbBrand = await _context.Brands.FindAsync(id);
            if (dbBrand == null) return NotFound();

            if (brand.Photo == null)
            {
                dbBrand.ImageUrl = dbBrand.ImageUrl;
            }
            else
            {
                if (!brand.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Choose images only");
                    return View();
                }
                if (brand.Photo.ValidSize(20000))
                {
                    ModelState.AddModelError("Photo", "Image size can not be large");
                    return View();
                }
                string oldImg = dbBrand.ImageUrl;
                string path = Path.Combine(_env.WebRootPath, "img", oldImg);
                dbBrand.ImageUrl = brand.Photo.SaveImage(_env, "images/brand");
                Helper.Helper.DeleteImage(path);

            }
            dbBrand.Name = brand.Name;
            dbBrand.LastUpdatedAt = System.DateTime.Now;

            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

        public async Task<IActionResult> Details(int id)
        {
            if(id==null) return NotFound();
            Brand brand = await _context.Brands.FindAsync(id);
            if (brand == null) return NotFound();
            return View(brand);

        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Brand brands = await _context.Brands.FindAsync(id);
            if (brands == null) return NotFound();
            brands.IsDeleted = true;
            brands.DeletedAt = System.DateTime.Now;
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

    }
}
