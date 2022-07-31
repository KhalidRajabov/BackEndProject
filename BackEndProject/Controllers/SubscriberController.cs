using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndProject.Controllers
{
    public class SubscriberController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _usermanager;

        public SubscriberController(AppDbContext context,
        SignInManager<AppUser> signInManager,
        UserManager<AppUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _usermanager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> Form([FromForm] Subscribers subs)
        {
            
            Subscribers subscribe = new Subscribers();
            List<Subscribers> subscribers = await _context.Subscribers.ToListAsync();
            if (string.IsNullOrEmpty(subs.Email))
            {
                return Ok("Bos qoyma");
            }
            else
            {
                foreach (var item in subscribers)
                {
                    if (item.Email == subs.Email)
                    {
                        return Ok("Bu hesab artiq melumatlar bazamizda movcuddur");
                    }
                    else
                    {
                        subscribe.Email = subs.Email;
                        _context.Subscribers.Add(subscribe);
                        _context.SaveChanges();
                    }
                    break;
                }
            }

            return Ok();
        }
    }
}
