using BackEndProject.DAL;
using BackEndProject.Models;
using BackEndProject.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEndProject.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _usermanager;

        public BasketController(AppDbContext context, 
        SignInManager<AppUser> signInManager, 
        UserManager<AppUser> userManager)
        {
            _context = context;
            _signInManager = signInManager;
            _usermanager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public async Task<IActionResult> AddItem(int? id)
        {
            string username = "";
            bool online = false;
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("login", "account");
                online = false;
            }
            else
            {
                username = User.Identity.Name;
                online = true;
            }
            if (id == null)
                if (id == null) return NotFound();
            Product dbProduct = await _context.Products.FindAsync(id);
            if (dbProduct == null) return NotFound();
            List<BasketVM> products;
            if (Request.Cookies[$"basket{username}"] == null)
            {
                products = new List<BasketVM>();
            }
            else
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies[$"basket{username}"]);
            }
            BasketVM IsExist = products.Find(x => x.Id == id);
            if (IsExist == null)
            {
                BasketVM basketvm = new BasketVM
                {
                    Id = dbProduct.Id,
                    ProductCount = 1,
                };
                if (dbProduct.DiscountPercent>0)
                {
                    basketvm.Price = dbProduct.DiscountPrice;
                }
                else
                {
                    basketvm.Price=dbProduct.Price;
                }
                products.Add(basketvm);
            }
            else
            {
                IsExist.ProductCount++;
            }

            Response.Cookies.Append($"basket{username}", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(100) });
            double price = 0;
            double count = 0;

            foreach (var product in products)
            {
                price += product.Price * product.ProductCount;
                count += product.ProductCount;
            }

            var obj = new
            {
                Price = price,
                Count = count,
                online = online
            };
            //obj data-id ile baghlidir. response "obj" obyektidir,
            //Ok'in icnde return edilmelidir ki API'de response gorsun
            return RedirectToAction("index", "home");
        }

        public IActionResult ShowItem()
        {
            string username = "";
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("login", "account");
            }
            else
            {
                username = User.Identity.Name;
            }
            //string name = HttpContext.Session.GetString("name");
            string basket = Request.Cookies[$"basket{username}"];
            List<BasketVM> products;
            if (basket != null)
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                foreach (var item in products)
                {
                    Product dbProducts = _context.Products.Include(pi=>pi.ProductImages).FirstOrDefault(x => x.Id == item.Id);
                    item.Name = dbProducts.Name;
                    if(dbProducts.DiscountPercent > 0)
                    {
                        item.Price = dbProducts.DiscountPrice;
                    }
                    else
                    {
                    item.Price = dbProducts.Price;
                    }
                    foreach (var image in dbProducts.ProductImages)
                    {
                        if (image.IsMain)
                        {
                            item.ImageUrl = image.ImageUrl;
                        }
                    }
                }
            }
            else
            {
                products = new List<BasketVM>();
            }
            return View(products);
        }

        public IActionResult RemoveItem(int? id)
        {
            string username = "";
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("login", "account");
            }
            else
            {
                username = User.Identity.Name;
            }
            if (id == null) return NotFound();
            string basket = Request.Cookies[$"basket{username}"];
            List<BasketVM> products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            BasketVM dbProduct = products.Find(p => p.Id == id);
            if (dbProduct == null) return NotFound();


            products.Remove(dbProduct);
            Response.Cookies.Append($"basket{username}", JsonConvert.SerializeObject(products), new CookieOptions { MaxAge = TimeSpan.FromDays(100) });

            double subtotal = 0;
            int basketCount = 0;

            if (products.Count > 0)
            {
                foreach (BasketVM item in products)
                {
                    subtotal += item.Price * dbProduct.ProductCount;
                    basketCount += item.ProductCount;
                }
            }

            var obj = new
            {
                Price = $"(${subtotal})",
                Count = basketCount
            };
            return RedirectToAction("showitem");
        }

        
        
        
        public IActionResult Minus(int? id)
        {
            string username = "";
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("login", "account");
            }
            else
            {
                username = User.Identity.Name;
            }
            if (id == null) return NotFound();
            string basket = Request.Cookies[$"basket{username}"];
            List<BasketVM> products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            BasketVM dbproducts = products.Find(p => p.Id == id);
            if (dbproducts == null) return NotFound();


            double subtotal = 0;
            int basketCount = 0;

            if (dbproducts.ProductCount > 1)
            {
                dbproducts.ProductCount--;
                Response.Cookies.Append($"basket{username}", JsonConvert.SerializeObject(dbproducts));
            }
            else
            {
                products.Remove(dbproducts);


                List<BasketVM> productsNew = products.FindAll(p => p.Id != id);

                Response.Cookies.Append($"basket{username}", JsonConvert.SerializeObject(productsNew));

                foreach (BasketVM pr in productsNew)
                {
                    subtotal += pr.Price * pr.ProductCount;
                    basketCount += pr.ProductCount;
                }

                var obje = new
                {
                    count = 0,
                    price = subtotal,
                    main = basketCount
                };

                return RedirectToAction("showitem");
            }
            Response.Cookies.Append($"basket{username}", JsonConvert.SerializeObject(products), new CookieOptions
            {
                MaxAge = TimeSpan.FromDays(100)
            });


            foreach (var product in products)
            {
                subtotal += product.Price * product.ProductCount;
                basketCount += product.ProductCount;
            }

            var obj = new
            {
                Price = subtotal,
                Count = dbproducts.ProductCount,
                main = basketCount,
                itemTotal = dbproducts.Price * dbproducts.ProductCount
            };
            return RedirectToAction("showitem");
        }
        
        
        
        public IActionResult Plus(int? id)
        {
            string username = "";
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("login", "account");
            }
            else
            {
                username = User.Identity.Name;
            }
            if (id == null) return NotFound();
            string basket = Request.Cookies[$"basket{username}"];
            List<BasketVM> products;
            products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
            BasketVM dbproducts = products.Find(p => p.Id == id);
            if (dbproducts == null) return NotFound();
            dbproducts.ProductCount++;
            Response.Cookies.Append($"basket{username}", JsonConvert.SerializeObject(products), new CookieOptions
            {
                MaxAge = TimeSpan.FromDays(100)
            });

            double price = 0;
            double count = 0;

            foreach (var product in products)
            {
                price += product.Price * product.ProductCount;
                count += product.ProductCount;
            }
            var obj = new
            {
                Price = price,
                Count = count,
                main = dbproducts.ProductCount,
                itemTotal = dbproducts.Price * dbproducts.ProductCount
            };

            return RedirectToAction("showitem");
        }




        public IActionResult CheckOut()
        {
            string username = "";
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("login", "account");
            }
            else
            {
                username = User.Identity.Name;
            }
            //string name = HttpContext.Session.GetString("name");
            string basket = Request.Cookies[$"basket{username}"];
            List<BasketVM> products;
            if (basket != null)
            {
                products = JsonConvert.DeserializeObject<List<BasketVM>>(basket);
                foreach (var item in products)
                {
                    Product dbProducts = _context.Products.FirstOrDefault(x => x.Id == item.Id);
                    item.Name = dbProducts.Name;
                    if (dbProducts.DiscountPercent > 0)
                    {
                        item.Price = dbProducts.DiscountPrice;
                    }
                    else
                    {
                        item.Price = dbProducts.Price;
                    }
                }
            }
            else
            {
                products = new List<BasketVM>();
            }
            return View(products);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Order()
        {
            string username = "";
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("login", "account");
            }
            else
            {
                username = User.Identity.Name;
            }
            if (User.Identity.IsAuthenticated)
            {
                AppUser user = await _usermanager.FindByNameAsync(User.Identity.Name);
                Order order = new Order();
                order.OrderedAt = DateTime.Now;
                order.AppUserId = user.Id;
                List<BasketVM> basket = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies[$"basket{username}"]);
                List<OrderItem> OrderItems = new List<OrderItem>();
                double Total = 0;
                foreach (var baskepProducts in basket)
                {
                    Product dbProduct = await _context.Products.FindAsync(baskepProducts.Id);
                    if (baskepProducts.ProductCount > dbProduct.Count)
                    {
                        TempData["Fail"] = "Purchase failed. Not enough product in storehouse left...";
                        return RedirectToAction("showitem");
                    }
                    OrderItem OrderItem = new OrderItem();
                    OrderItem.ProductId = dbProduct.Id;
                    OrderItem.Count = baskepProducts.ProductCount;
                    OrderItem.Id = order.Id;
                    OrderItem.Total = dbProduct.Price;
                    OrderItems.Add(OrderItem);
                    Total += baskepProducts.ProductCount * dbProduct.Price;
                    dbProduct.Count -= baskepProducts.ProductCount;
                }
                order.OrderItems = OrderItems;
                order.Price = Total;
                await _context.AddAsync(order);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Purchase succesfull";
                return RedirectToAction("showitem");
            }
            else
            {
                return RedirectToAction("login", "account");
            }
        }



    }
}
