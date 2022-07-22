using BackEndProject.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BackEndProject.DAL
{
    public class AppDbContext:IdentityDbContext<AppUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {  
           
        }  
           
        public DbSet<Bio> Bios { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<TagProducts> TagProducts { get; set; }
        public DbSet<Tags> Tags { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Category>().HasData(
                
                new Category
                {
                    Id=21,
                    Name="Computers",
                    ImageUrl= "category-6.jpg"
                },
                new Category
                {
                    Id = 22,
                    Name = "Monitors",
                    ImageUrl = "category-2.jpg"
                }, 
                new Category
                {
                    Id = 23,
                    Name = "Watches",
                    ImageUrl = "category-8.jpg"
                },
                new Category
                {
                    Id = 24,
                    Name = "Notebooks",
                    ImageUrl = "category-1.jpg"
                },
                new Category
                {
                    Id = 25,
                    Name = "Game Consoles",
                    ImageUrl = "category-4.jpg"
                },
                new Category
                {
                    Id = 26,
                    Name = "Washing Machine",
                    ImageUrl = "category-9.jpg"
                },
                new Category
                {
                    Id = 27,
                    Name = "Batteries",
                    ImageUrl = "category-12.jpg"
                },
                new Category
                {
                    Id = 28,
                    Name = "Cameras",
                    ImageUrl = "category-10.jpg"
                },
                new Category
                {
                    Id = 29,
                    Name = "Printers",
                    ImageUrl = "category-7.jpg"
                },
                new Category
                {
                    Id = 31,
                    Name = "Video Games",
                    ImageUrl = "category-8.jpg"
                },
                new Category
                {
                    Id = 32,
                    Name = "Accessories",
                    ImageUrl = "category-8.jpg"
                },
                new Category
                {
                    Id = 33,
                    Name = "Implants",
                    ImageUrl = "category-13.jpg"
                },
                new Category
                {
                    Id = 34,
                    Name = "Gerenade Laucnhers",
                    ImageUrl = "category-14.jpg"
                },
                new Category
                {
                    Id = 35,
                    Name = "Pets",
                    ImageUrl = "category-15.jpg"
                },
                new Category
                {
                    Id = 36,
                    Name = "Nuclear Weapons",
                    ImageUrl = "category-16.jpg"
                },
                new Category
                {
                    Id = 37,
                    Name = "SuperCars",
                    ImageUrl = "category-17.jpg"
                },
                new Category
                {
                    Id = 38,
                    Name = "Space Ships",
                    ImageUrl = "category-18.jpg"
                },
                new Category
                {
                    Id = 39,
                    Name = "Tanks",
                    ImageUrl = "category-19.jpg"
                },
                new Category
                {
                    Id = 40,
                    Name = "Automatic Assault Rifles",
                    ImageUrl = "category-20.jpg"
                },
                new Category
                {
                    Id = 41,
                    Name = "Nasa Super Computers",
                    ParentId = 21
                },
                new Category
                {
                    Id = 42,
                    Name = "Office Computers",
                    ParentId = 21
                }
                ,
                new Category
                {
                    Id = 43,
                    Name = "Gaming Monitor",
                    ParentId = 22
                },
                new Category
                {
                    Id = 44,
                    Name = "Standart Monitor",
                    ParentId = 22
                },
                new Category
                {
                    Id = 45,
                    Name = "Digital Watches",
                    ParentId = 23
                },
                new Category
                {
                    Id = 46,
                    Name = "Analog Watches",
                    ParentId = 23
                },
                new Category
                {
                    Id = 47,
                    Name = "Gaming Notebook",
                    ParentId = 24
                },
                new Category
                {
                    Id = 48,
                    Name = "Word Notebook",
                    ParentId = 24
                },
                new Category
                {
                    Id = 49,
                    Name = "Wired Oldschool",
                    ParentId = 25
                },
                new Category
                {
                    Id = 50,
                    Name = "Next Generation",
                    ParentId = 25
                },
                new Category
                {
                    Id = 51,
                    Name = "Large Machine",
                    ParentId = 26
                },
                new Category
                {
                    Id = 52,
                    Name = "Standart",
                    ParentId = 26
                },
                new Category
                {
                    Id = 53,
                    Name = "Power Banks",
                    ParentId = 27
                },
                new Category
                {
                    Id = 54,
                    Name = "Adapters",
                    ParentId = 27
                },
                new Category
                {
                    Id = 55,
                    Name = "Telescopic Cameras",
                    ParentId = 28
                },
                new Category
                {
                    Id = 56,
                    Name = "Digital Cameras",
                    ParentId = 28
                },
                new Category
                {
                    Id = 57,
                    Name = "Laser Printers",
                    ParentId = 29
                },
                new Category
                {
                    Id = 58,
                    Name = "Inky Printers",
                    ParentId = 29
                },
                new Category
                {
                    Id = 59,
                    Name = "Bracalet",
                    ParentId = 32
                },
                new Category
                {
                    Id = 60,
                    Name = "Headsets",
                    ParentId = 32
                },
                new Category
                {
                    Id = 61,
                    Name = "Pc Video Games",
                    ParentId = 31
                },
                new Category
                {
                    Id = 62,
                    Name = "Console Video Games",
                    ParentId = 31
                },
                new Category
                {
                    Id = 63,
                    Name = "Robotic Heart",
                    ParentId = 33
                },
                new Category
                {
                    Id = 64,
                    Name = "Robotic Eye",
                    ParentId = 33
                },
                new Category
                {
                    Id = 65,
                    Name = "Electronic",
                    ParentId = 34
                },
                new Category
                {
                    Id = 66,
                    Name = "Close Range",
                    ParentId = 34
                },
                new Category
                {
                    Id = 67,
                    Name = "Cats",
                    ParentId = 35
                },
                new Category
                {
                    Id = 68,
                    Name = "Dogs",
                    ParentId = 35
                },
                new Category
                {
                    Id = 69,
                    Name = "Hydrogen Bombs",
                    ParentId = 36
                },
                new Category
                {
                    Id = 70,
                    Name = "Electro Magnetic Bombs",
                    ParentId = 36
                },
                new Category
                {
                    Id = 71,
                    Name = "Supersports",
                    ParentId = 37
                },
                new Category
                {
                    Id = 72,
                    Name = "Hyper Cars",
                    ParentId = 37
                },
                new Category
                {
                    Id = 73,
                    Name = "Orbiter spacecraft",
                    ParentId = 38
                },
                new Category
                {
                    Id = 74,
                    Name = "Rover Spacecraft",
                    ParentId = 38
                },
                new Category
                {
                    Id = 75,
                    Name = "Heavy Tanks",
                    ParentId = 39
                },
                new Category
                {
                    Id = 76,
                    Name = "Artillery Tanks",
                    ParentId = 39
                },
                new Category
                {
                    Id = 77,
                    Name = "Close Range Rifles",
                    ParentId = 40
                },
                new Category
                {
                    Id = 78,
                    Name = "Long Range Rifles",
                    ParentId = 40
                }


                );

            builder.Entity<Bio>().HasData(
                new Bio
                {
                    Id = 1,
                    Logo= "logo.png",
                    CouponCode = "<p>Get FREE Shipping with <b>$35!</b> Code: FREESHIPPING</p>",
                    SupportNumber = 500500500,
                    Address = "45 Grand Central Terminal New York,NY 1017 United State USA",
                    Phone = 123456789,
                    Email = "email@yourwebsitename.com",
                    WorkTimes = "Mon-Sat 9:00pm - 5:00pm Sun:Closed",
                    Author = "Me Myself",
                    CardsImageUrl = "payment.png"
                }
                );

                
        }
    }
}
