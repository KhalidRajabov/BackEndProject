﻿using BackEndProject.Helper;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Security.Claims;
using System.Threading.Tasks;
using SignInResult = Microsoft.AspNetCore.Identity.SignInResult;

namespace BackEndProject.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _usermanager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<AppUser> _signInManager;
        private IConfiguration _config { get; }

        public AccountController
            (UserManager<AppUser> usermanager,
            RoleManager<IdentityRole> roleManager,
            SignInManager<AppUser> signInManager,
            IConfiguration config
            )
        {
            _usermanager = usermanager;
            _roleManager = roleManager;
            _signInManager = signInManager;
            _config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("index", "home");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("index", "home");

            if (!ModelState.IsValid) return View();
            AppUser appUser = new AppUser
            {
                Fullname = registerVM.Fullname,
                UserName = registerVM.Username,
                Email = registerVM.Email

            };
            IdentityResult result = await _usermanager.CreateAsync(appUser, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View(registerVM);
            }
            await _usermanager.AddToRoleAsync(appUser, "Member");
            string token = await _usermanager.GenerateEmailConfirmationTokenAsync(appUser);
            string ConfirmationLink = Url.Action("ConfirmEmail", "EmailConfirmation", new { token, Email = registerVM.Email }, Request.Scheme);

            EmailHelper emailHelper = new EmailHelper(_config.GetSection("ConfirmationParam:Email").Value, _config.GetSection("ConfirmationParam:Password").Value);
            var emailResult = emailHelper.SendEmail(registerVM.Email, ConfirmationLink);

            if (!emailResult)
            {
                return View(registerVM);
            }


            return RedirectToAction("login", "account");
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("index", "home");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginVM loginvm, string ReturnUrl)
        {
            if (User.Identity.IsAuthenticated) return RedirectToAction("index", "home");
            if (!ModelState.IsValid) return View();
            AppUser appUser = await _usermanager.FindByEmailAsync(loginvm.Email);
            if (appUser == null)
            {
                ModelState.AddModelError("", "Email or password is wrong");
                return View(loginvm);
            }


            var roles = await _usermanager.GetRolesAsync(appUser);
            foreach (var item in roles)
            {
                if (item.ToLower() == "ban" || roles == null)
                {
                    ModelState.AddModelError("", "You are banned");
                    await _signInManager.SignOutAsync();
                    return View(loginvm);
                }

                else if (item.ToLower().Contains("admin"))
                {
                    if (!appUser.EmailConfirmed)
                    {
                        ModelState.AddModelError("", "Please confirm your email");
                        return View();
                    }
                    await _signInManager.SignInAsync(appUser, isPersistent: true);
                    if (ReturnUrl != null)
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("index", "dashboard", new { Area = "AdminPanel" });
                }
            }
            SignInResult result = await _signInManager.PasswordSignInAsync(appUser, loginvm.Password, loginvm.RememberMe, true);
            if (result.IsLockedOut)
            {
                ModelState.AddModelError("", "Your account is blocked");
                return View(loginvm);
            }


            if (!appUser.EmailConfirmed)
            {
                ModelState.AddModelError("", "Please confirm your email");
                return View(loginvm);
            }


            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "Email or password is wrong");
                return View(loginvm);
            }


            await _signInManager.SignInAsync(appUser, isPersistent: true);
            if (ReturnUrl != null)
            {
                return Redirect(ReturnUrl);
            }

            return RedirectToAction("index", "home");

        }

        public async Task<IActionResult> Logout(string returnurl)
        {
            await _signInManager.SignOutAsync();
            if (returnurl!=null)
            {
                return Redirect(returnurl);
            }
            return RedirectToAction("index", "home");
        }




        public async Task CreateRole()
        {

            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            }
            if (!await _roleManager.RoleExistsAsync("Member"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Member" });
            }
            if (!await _roleManager.RoleExistsAsync("SuperAdmin"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "SuperAdmin" });
            }
            if (!await _roleManager.RoleExistsAsync("Ban"))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = "Ban" });
            }
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> ExternalLoginConfirmation(ExternalLoginVM model, string? returnurl=null)
        {
            returnurl = returnurl ?? Url.Content("~/");
            if (ModelState.IsValid)
            {
                var info = await _signInManager.GetExternalLoginInfoAsync();
                if (info == null) return View("Error");
                var user = new AppUser { UserName = model.Username, Email = model.Email };
                var result = await _usermanager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await _usermanager.AddToRoleAsync(user, "Member");
                    result = await _usermanager.AddLoginAsync(user, info);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        await _signInManager.UpdateExternalAuthenticationTokensAsync(info);
                        return LocalRedirect(returnurl);
                    }
                }
                ModelState.AddModelError("Email", "Email already used");
            }
                ViewData["ReturnUrl"] = returnurl;
                return View(model);
        }

        


        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public IActionResult ExternalLogin(string provider, string returnurl = null)
        {
            var redirectUrl = Url.Action("ExternalLoginCallBack", "Account", new { ReturnUrl = returnurl });
            var properties = _signInManager.ConfigureExternalAuthenticationProperties(provider, redirectUrl);
            return Challenge(properties, provider);
        }
        [HttpGet]
        public async Task<IActionResult> ExternalLoginCallBack(string returnurl = null, string remoteerror = null)
        {
            if (remoteerror!=null)
            {
                ModelState.AddModelError(string.Empty, "Provider error");
                return View("Login");
            }
            var info = await _signInManager.GetExternalLoginInfoAsync();
            if (info == null) return RedirectToAction("Login");
            var result = await _signInManager.ExternalLoginSignInAsync(info.LoginProvider, info.ProviderKey, isPersistent: true);
            if (result.Succeeded)
            {
                await _signInManager.UpdateExternalAuthenticationTokensAsync(info);
                return LocalRedirect(returnurl);
            }
            else
            {
                ViewData["ReturnUrl"] = returnurl;
                ViewData["ProviderDisplayName"] = info.ProviderDisplayName;
                var email = info.Principal.FindFirstValue(ClaimTypes.Email);
                return View("ExternalLoginConfirmation", new ExternalLoginVM { Email = email});
            }

        }

        public IActionResult GoogleLogin(string ReturnUrl)
        {
            string redirectUrl = Url.Action("ExternalResponse", new { ReturnUrl = ReturnUrl });

            AuthenticationProperties properties = _signInManager.ConfigureExternalAuthenticationProperties("Google", redirectUrl);
            //Bağlantı kurulacak harici platformun hangisi olduğunu belirtiyor ve bağlantı özelliklerini elde ediyoruz.
            return new ChallengeResult("Google", properties);
            //ChallengeResult; kimlik doğrulamak için gerekli olan tüm özellikleri kapsayan AuthenticationProperties nesnesini alır ve ayarlar.
        }

        public async Task<IActionResult> ExternalResponse(string ReturnUrl = "/")
        {
            ExternalLoginInfo loginInfo = await _signInManager.GetExternalLoginInfoAsync();
            //Kullanıcıyla ilgili dış kaynaktan gelen tüm bilgileri taşıyan nesnedir.
            //Bu nesnesnin 'LoginProvider' propertysinin değerine göz atarsanız eğer hangi dış kaynaktan geliniyorsa onun bilgisinin yazdığını göreceksiniz.
            if (loginInfo == null)
                return RedirectToAction("Login");
            else
            {
                Microsoft.AspNetCore.Identity.SignInResult loginResult = await _signInManager.ExternalLoginSignInAsync(loginInfo.LoginProvider, loginInfo.ProviderKey, true);
                //Giriş yapıyoruz.
                if (loginResult.Succeeded)
                    return Redirect(ReturnUrl);
                else
                {
                    //Eğer ki akış bu bloğa girerse ilgili kullanıcı uygulamamıza kayıt olmadığından dolayı girişi başarısız demektir.
                    //O halde kayıt işlemini yapıp, ardından giriş yaptırmamız gerekmektedir.
                    AppUser user = new AppUser
                    {
                        Email = loginInfo.Principal.FindFirst(ClaimTypes.Email).Value,
                        UserName = loginInfo.Principal.FindFirst(ClaimTypes.GivenName).Value,
                        Fullname = loginInfo.Principal.FindFirst(ClaimTypes.Name).Value

                    };
                    //Dış kaynaktan gelen Claimleri uygun eşlendikleri propertylere atıyoruz.
                    IdentityResult createResult = await _usermanager.CreateAsync(user);
                    //Kullanıcı kaydını yapıyoruz.
                    if (createResult.Succeeded)
                    {
                        //Eğer kayıt başarılıysa ilgili kullanıcı bilgilerini AspNetUserLogins tablosuna kaydetmemiz gerekmektedir ki
                        //bir sonraki dış kaynak login talebinde Identity mimarisi ilgili kullanıcının hangi dış kaynaktan geldiğini anlayabilsin.
                        IdentityResult addLoginResult = await _usermanager.AddLoginAsync(user, loginInfo);
                        //Kullanıcı bilgileri dış kaynaktan gelen bilgileriyle AspNetUserLogins tablosunda eşleştirilmek suretiyle kaydedilmiştir.
                        if (addLoginResult.Succeeded)
                        {
                            await _signInManager.SignInAsync(user, true);
                            //await _signInManager.ExternalLoginSignInAsync(loginInfo.LoginProvider, loginInfo.ProviderKey, true);
                            return Redirect(ReturnUrl);
                        }
                    }

                }
            }
            return Redirect(ReturnUrl);
        }
    }
}