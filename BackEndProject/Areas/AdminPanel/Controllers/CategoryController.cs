﻿using BackEndProject.DAL;
using BackEndProject.Extensions;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
            List<Category> category = _context.Categories.Where(c=>c.ParentId==null).Skip((page - 1) * take).Take(take).ToList();
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
            

                bool isValid = _context.Categories.Any(c => c.Name.ToLower() == category.Name.ToLower());
                if (isValid)
                {
                    ModelState.AddModelError("Name", "This category name already exists");
                    return View();
                }
            Category newcategory = new Category
            {
                Name = category.Name,
                ImageUrl = category.Images.SaveImage(_env, "images")
            };
                await _context.Categories.AddAsync(newcategory);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            public async Task<IActionResult> Update(int? id)
            {
                if (id == null) return NotFound();
                Category category = await _context.Categories.FindAsync(id);
                if (category == null) return NotFound();
                return View(category);
            }


            public async Task<IActionResult> Delete(int? id)
            {
                if (id == null) return NotFound();
                Category category = await _context.Categories.FindAsync(id);
                if (category == null) return NotFound();
                return View(category);
            }

            [HttpPost]
            [ValidateAntiForgeryToken]
            [ActionName("Delete")]
            public async Task<IActionResult> DeleteCategory(int? id)
            {
                if (id == null) return NotFound();
                Category category = await _context.Categories.FindAsync(id);
                if (category == null) return NotFound();
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return RedirectToAction("index");
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
                dbCategory.Name = category.Name;
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
