﻿using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [Authorize(Roles = "Admin, SuperAdmin")]
    public class OrdersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;
        public OrdersController
            (UserManager<AppUser> usermanager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<AppUser> signInManager,
            AppDbContext context)
        {
            _userManager = usermanager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<AppUser> users = await _userManager.Users.Include(o => o.Orders).ThenInclude(i => i.OrderItems).ToListAsync();
            OrderVM orderVM = new OrderVM();
            List<Order> orders = await _context.Orders.Include(u => u.AppUser).Include(o => o.OrderItems).ToListAsync();
            orderVM.Orders = orders;
            orderVM.User = users;
            return View(orderVM);
        }

        public async Task<IActionResult> Detail(int id)
        {
            Order order = await _context.Orders.Include(u=>u.AppUser).Include(o=>o.OrderItems)
                .FirstOrDefaultAsync(o=>o.Id==id);
            if(order == null) return NotFound();
            AppUser user = await _userManager.Users.FirstOrDefaultAsync(i=>i.Id==order.AppUserId);
            if(user == null) return NotFound();
            List<OrderItem> orderItems = _context.OrderItems.Where(o=>o.OrderId==id)
                .Include(p=>p.Product).ToList();
            if (orderItems == null) return NotFound();

            OrderItemVM orderitemVM = new OrderItemVM();
            orderitemVM.Order = order;
            orderitemVM.User = user;
            orderitemVM.OrderItems = orderItems;
            return View(orderitemVM);
        }
    }
}
