﻿using BackEndProject.DAL;
using BackEndProject.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.ViewComponents
{
    public class FooterViewComponent:ViewComponent
    {
        private readonly AppDbContext _context;
        public FooterViewComponent(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Bio bio = _context.Bios.FirstOrDefault();
            return View(await Task.FromResult(bio));
        }

    }
}
