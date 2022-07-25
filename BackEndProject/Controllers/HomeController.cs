﻿using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
            var product = await _context.Products.Include(pi => pi.ProductImages).ToListAsync();
            HomeVM homeVM = new HomeVM();
            homeVM.Sliders = await _context.Sliders.ToListAsync();
            homeVM.Categories = await _context.Categories.Where(c=>c.ParentId==null).ToListAsync();
            homeVM.Products =await _context.Products
            .Include(pi=>pi.ProductImages).Include(pc=>pc.Category).Include(b=>b.Brand)
            .Include(tp=>tp.ProductTags).ThenInclude(t=>t.Tags).ToListAsync();

            homeVM.ProductImages = await _context.ProductImages.Include(pi => pi.Product).ToListAsync();
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

        
    }
}
