using BackEndProject.DAL;
using BackEndProject.Helper;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BackEndProject.Controllers
{
    public class SubscriberController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _usermanager;
        private IConfiguration _config { get; }

        public SubscriberController(AppDbContext context,
        SignInManager<AppUser> signInManager,
        UserManager<AppUser> userManager,
        IConfiguration config)
        {
            _context = context;
            _signInManager = signInManager;
            _usermanager = userManager;
            _config = config;
        }
        [HttpPost]
        public async Task<IActionResult> Form([FromForm] Subscribers subs,string returnurl)
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
                        return Ok("You are already subscribed");
                    }
                    else
                    {
                        subscribe.Email = subs.Email;
                        var token = "";
                        string subject = "Subscription allup";
                        EmailHelper helper = new EmailHelper(_config.GetSection("ConfirmationParam:Email").Value, _config.GetSection("ConfirmationParam:Password").Value);
                     
                            token = $"Thanks for subscribing to us. We will keep you informed so that you won't miss anything";
                            var emailResult = helper.SendNews(subs.Email, token, subject);
                            continue;
                        
                        string confirmation = Url.Action("ConfirmEmail", "Account", new
                        {
                            token
                        }, Request.Scheme);
                        _context.Subscribers.Add(subscribe);
                        _context.SaveChanges();
                    }
                  
                }
            }

            return Redirect(returnurl);
        }
    }
}