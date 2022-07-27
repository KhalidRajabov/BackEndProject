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
                .Skip((page - 1) * take).Take(take).ToList();
            PaginationVM<Product> paginationVM = new PaginationVM<Product>(product, PageCount(take), page);

            return View(paginationVM);
        }

        private int PageCount(int take)
        {
            List<Product> products = _context.Products.ToList();
            return (int)Math.Ceiling((decimal)products.Count() / take);
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null) return NotFound();
            Product dbProduct = await _context.Products.Include(c => c.Category)
                .Include(c=>c.ProductTags).ThenInclude(t=>t.Tags)
                .Include(pi=>pi.ProductImages)
                .FirstOrDefaultAsync(c => c.Id == id);
            if (dbProduct == null) return NotFound();
            return View(dbProduct);
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
                Count = product.Count,
                ProductImages = Images
            };

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


        public async Task<IActionResult> Update(int? id)
        {
            ViewBag.Brands = new SelectList(_context.Brands.ToList(), "Id", "Name");
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
            if (id == null) return NotFound();
            Product product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            return View(product);
        }




        /*[HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Product product)
        {
            ViewBag.Categories = new SelectList(_context.Categories.ToList(), "Id", "Name");
            if (!ModelState.IsValid) return View();
            if (id == null) return NotFound();
            Product dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct == null) return NotFound();

            if (product.Photo == null)
            {
                dbProduct.ImageUrl = dbProduct.ImageUrl;
            }
            else
            {
                if (!product.Photo.IsImage())
                {
                    ModelState.AddModelError("Photo", "Choose images only");
                    return View();
                }
                if (product.Photo.ValidSize(20000))
                {
                    ModelState.AddModelError("Photo", "Image size can not be large");
                    return View();
                }
                string oldImg = dbProduct.ImageUrl;
                string path = Path.Combine(_env.WebRootPath, "img", oldImg);
                dbProduct.ImageUrl = product.Photo.SaveImage(_env, "img");
                Helper.Helper.DeleteImage(path);

            }




            dbProduct.Name = product.Name;
            dbProduct.Price = product.Price;
            dbProduct.Count = product.Count;
            dbProduct.CategoryId = product.CategoryId;


            //await _context.AddAsync(dbProduct);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }

*/


        /*public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            Product product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound();
            string path = Path.Combine(_env.WebRootPath, "img", product.Photo);
            Helper.Helper.DeleteImage(path);
            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction("index");
        }*/

        public IActionResult GetSubCategory(int cid)
        {
            var SubCategory_List = _context.Categories.Where(s => s.ParentId== cid).Where(s=>s.ParentId!=null).Select(c => new { Id = c.Id, Name = c.Name }).ToList();
            return Json(SubCategory_List);
        }
    }
}
