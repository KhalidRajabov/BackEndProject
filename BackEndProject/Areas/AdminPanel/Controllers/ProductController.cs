﻿using BackEndProject.DAL;
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

namespace BackEndProject.Area.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }


        public IActionResult Index(int page = 1, int take = 5)
        {

            List<Product> product = _context.Products.Include(p => p.Category).Include(pi=>pi.ProductImages)
                .Where(p=>p.IsDeleted!=true).Skip((page - 1) * take).Take(take).ToList();
            PaginationVM<Product> paginationVM = new PaginationVM<Product>(product, PageCount(take), page);

            return View(paginationVM);
        }

        private int PageCount(int take)
        {
            List<Product> products = _context.Products.ToList();
            return (int)Math.Ceiling((decimal)products.Count() / take);
        }

        

        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_context.Categories.Where(c => c.IsDeleted != true).Where(c => c.ParentId == null).ToList(), "Id", "Name");
            ViewBag.Brands = new SelectList(_context.Brands.Where(c => c.IsDeleted != true).ToList(), "Id", "Name");
            ViewBag.Tags = new SelectList(_context.Tags.ToList(), "Id", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Product product)
        {
            ViewBag.Categories = new SelectList(_context.Categories.Where(c=>c.IsDeleted!=true).Where(c=>c.ParentId==null).ToList(), "Id", "Name");
            ViewBag.Brands = new SelectList(_context.Brands.Where(c => c.IsDeleted != true).ToList(), "Id", "Name");
            ViewBag.Tags = new SelectList(_context.Tags.ToList(), "Id", "Name");

            List<ProductImage> Images = new List<ProductImage>();

            foreach (var item in product.Photo)
            {
                if (item == null)
                {
                    ModelState.AddModelError("Photo", "Do not leave it empty");
                    return View();
                }
                if (!item.IsImage())
                {
                    ModelState.AddModelError("Photo", "Do not leave it empty");
                    return View();
                }
                if (item.ValidSize(10000))
                {
                    ModelState.AddModelError("Photo", "Image size can not be large");
                    return View();
                }
                ProductImage image = new ProductImage();
                image.ImageUrl = item.SaveImage(_env, "images/product");
                Images.Add(image);
            }


            Product NewProduct = new Product
            {
                Price = product.Price,
                Name = product.Name,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,
                DiscountPercent = product.DiscountPercent,
                DiscountPrice = product.Price - (product.Price * product.DiscountPercent) / 100,
                Count = product.Count,
                ProductImages = Images,
                TaxPercent = product.TaxPercent,
                Description = product.Description,
                CreatedTime = DateTime.Now
            };
            NewProduct.ProductImages[0].IsMain = true;

            List<ProductTags> productTags = new List<ProductTags>();
            foreach (int item in product.TagId)
            {
                ProductTags productTag = new ProductTags();
                productTag.TagId = item;
                productTag.ProductId = NewProduct.Id;
                productTags.Add(productTag);
            }
            NewProduct.ProductTags = productTags;
            _context.Products.Add(NewProduct);
            _context.SaveChanges();

            return RedirectToAction("index");
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Product dbProduct = await _context.Products.Include(c => c.Category).Where(c=>c.Category.ParentId!=null)
                .Include(c => c.ProductTags).ThenInclude(t => t.Tags)
                .Include(pi => pi.ProductImages)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (dbProduct == null) return NotFound();
            return View(dbProduct);
        }

        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Brands = new SelectList(_context.Brands.ToList(), "Id", "Name");
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
            ViewBag.Tags = new SelectList(_context.Tags.ToList(), "Id", "Name");
            if (id == null) return NotFound();
            Product product = await _context.Products.Include(i=>i.ProductImages)
                .Include(t=>t.ProductTags).ThenInclude(p=>p.Tags).FirstOrDefaultAsync(c=>c.Id ==id);
            if (product == null) return NotFound();
            return View(product);
        }




        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Product product)
        {
            ViewBag.Brands = new SelectList(_context.Brands.ToList(), "Id", "Name");
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
            ViewBag.Tags = new SelectList(_context.Tags.ToList(), "Id", "Name");
            if (!ModelState.IsValid)
            {
                return View();
            }
            Product dbProduct = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.ProductTags)
                .ThenInclude(t => t.Tags)
                .Include(b => b.Brand)
                .Include(c => c.Category)
                .FirstOrDefaultAsync(b => b.Id == product.Id);
            if (dbProduct == null)
            {
                return View();
            }
            List<ProductImage> images = new List<ProductImage>();
            Product dbProductName = _context.Products.FirstOrDefault(c => c.Name.ToLower().Trim() == product.Name.ToLower().Trim());
            string path = "";
            if (product.Photo == null)
            {
                foreach (var item in dbProduct.ProductImages)
                {
                    item.ImageUrl = item.ImageUrl;
                }
            }
            else
            {
                foreach (var item in product.Photo)
                {
                    if (item == null)
                    {
                        ModelState.AddModelError("Photo", "Don't be Empty");
                        return View();
                    }
                    if (!item.IsImage())
                    {
                        ModelState.AddModelError("Photo", "Only Image Files");
                        return View();
                    }

                    if (item.ValidSize(2000))
                    {
                        ModelState.AddModelError("Photo", "Size oversize");
                        return View();
                    }
                    ProductImage image = new ProductImage();
                    image.ImageUrl = item.SaveImage(_env, "images/product");

                    if (product.Photo.Count == 1)
                    {
                        image.IsMain = true;
                    }
                    else
                    {
                        for (int i = 0; i < images.Count; i++)
                        {
                            images[0].IsMain = true;
                        }
                    }
                    images.Add(image);
                }

                foreach (var item in product.Photo)
                {
                    if (!item.IsImage())
                    {
                        ModelState.AddModelError("Photo", "Only Image Files");
                        return View();
                    }

                    if (item.ValidSize(1000))
                    {
                        ModelState.AddModelError("Photo", "Size is higher max 1mb");
                        return View();
                    }
                }
            }

            foreach (var item in dbProduct.ProductImages)
            {
                if (item.ImageUrl != null)
                {
                    path = Path.Combine(_env.WebRootPath, "assets/images/product", item.ImageUrl);
                }
            }
            if (path != null)
            {
                Helper.Helper.DeleteImage(path);
            }
            else return NotFound();

            if (dbProductName != null)
            {
                if (dbProduct.Name != dbProduct.Name)
                {
                    ModelState.AddModelError("Name", "This Name already was taken");
                    return View();
                }
            }
            
            


            dbProduct.Name = product.Name;
            dbProduct.Price = product.Price;
            dbProduct.ProductImages = images;
            dbProduct.Count = product.Count;
            dbProduct.IsDeleted = false;
            dbProduct.IsAvailability = true;
            dbProduct.IsFeatured = false;
            dbProduct.DiscountPercent = product.DiscountPercent;
            dbProduct.DiscountPrice = product.Price - (product.Price * product.DiscountPercent) / 100;
            dbProduct.BrandId = product.BrandId;
            dbProduct.CategoryId = product.CategoryId;
            dbProduct.TaxPercent = product.TaxPercent;
            dbProduct.Description = product.Description;
            dbProduct.LastUpdatedAt = System.DateTime.Now;
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }




        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Product product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            product.IsDeleted = true;
            product.DeletedAt = DateTime.Now;
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

        public IActionResult GetSubCategory(int cid)
        {
            var SubCategory_List = _context.Categories.Where(s => s.ParentId== cid).Where(s=>s.ParentId!=null).Select(c => new { Id = c.Id, Name = c.Name }).ToList();
            return Json(SubCategory_List);
        }
    }
}
