using BackEndProject.DAL;
using BackEndProject.Extensions;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.AdminPanel.Controllers
{
    
        [Area("AdminPanel")]
        [Authorize(Roles = "Admin, SuperAdmin")]
        public class CategoryController : Controller
        {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public CategoryController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }



        //6ci deqiq
        public IActionResult Index(int page = 1, int take = 5)
        {
            List<Category> category = _context.Categories.Where(c=>c.ParentId==null&&c.IsDeleted==null).Skip((page - 1) * take).Take(take).ToList();
            PaginationVM<Category> paginationVM = new PaginationVM<Category>(category, PageCount(take), page);
            return View(paginationVM);
        }
        private int PageCount(int take)
        {
            List<Category> categories = _context.Categories.Where(c => c.ParentId == null).ToList();
            return (int)Math.Ceiling((decimal)categories.Count() / take);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
        if (category.Images == null)
        {
            ModelState.AddModelError("Photo", "Do not leave it empty");
            return View();
        }

        if (!category.Images.IsImage())
        {
            ModelState.AddModelError("Photo", "Do not leave it empty");
            return View();
        }
        if (category.Images.ValidSize(10000))
        {
            ModelState.AddModelError("Photo", "Image size can not be large");
            return View();
        }
        if (!ModelState.IsValid)
        {
            return View();
        }
        

        bool isValid = await _context.Categories.AnyAsync(c => c.Name.ToLower() == category.Name.ToLower());
        if (isValid)
        {
            ModelState.AddModelError("Name", "This category name already exists");
            return View();
        }
        Category newcategory = new Category
        {
            Name = category.Name,
            ImageUrl = category.Images.SaveImage(_env, "images"),
            CreatedTime = DateTime.Now
        };
        await _context.AddAsync(newcategory);
        await _context.SaveChangesAsync();
        return RedirectToAction("Index");
        }

        public IActionResult CreateSubCategory()
        {
            ViewBag.MainCategories = new SelectList(_context.Categories.Where(c=>c.ParentId==null).ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateSubCategory(Category subcategory)
        {
            ViewBag.MainCategories = new SelectList(_context.Categories.Where(c => c.ParentId == null).ToList(), "Id", "Name");
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (subcategory.ParentId==null)
            {
                ModelState.AddModelError("ParentId", "Select a category");
                return View();
            }
            bool isValid = _context.Categories.Where(c=>c.ParentId!=null).Any(c => c.Name.ToLower() == subcategory.Name.ToLower());
            if (isValid)
            {
                ModelState.AddModelError("Name", "This category name already exists");
                return View();
            }
            Category newsubcategory = new Category
            {
                Name = subcategory.Name,
                ParentId = subcategory.ParentId
            };
            await _context.Categories.AddAsync(newsubcategory);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }



     
        public async Task<IActionResult> DeleteCategory(int? id)
        {
            if (id == null) return NotFound();
            Category category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound();
            category.IsDeleted=true;
            category.DeletedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }



        public async Task<IActionResult> Update(int? id)
        {
            if (id == null) return NotFound();
            Category category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Category category)
        {
            if (!ModelState.IsValid) return View();
            if (id == null) return NotFound();
            Category dbCategory = await _context.Categories.FindAsync(id);
            if (dbCategory == null) return NotFound();
            Category checkCategory = _context.Categories.FirstOrDefault(c => c.Name.ToLower() == category.Name.ToLower());
            if (checkCategory != null)
            {
                if (dbCategory.Name != checkCategory.Name)
                {
                    ModelState.AddModelError("Name", "This category name already exists");
                    return View();
                }
            }
            if (category.Images == null)
            {
                dbCategory.ImageUrl = dbCategory.ImageUrl;
            }
            else
            {
                if (!category.Images.IsImage())
                {
                    ModelState.AddModelError("Photo", "Choose images only");
                    return View();
                }
                if (category.Images.ValidSize(20000))
                {
                    ModelState.AddModelError("Photo", "Image size can not be large");
                    return View();
                }
                string oldImg = dbCategory.ImageUrl;
                string path = Path.Combine(_env.WebRootPath, "images", oldImg);
                Helper.Helper.DeleteImage(path);
                dbCategory.ImageUrl = category.Images.SaveImage(_env, "images");
            }
            dbCategory.Name = category.Name;
            dbCategory.LastUpdatedAt = DateTime.Now;
       
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Category dbCategory = await _context.Categories.FindAsync(id);
            if (dbCategory == null) return NotFound();
            return View(dbCategory);
        }
        }
}