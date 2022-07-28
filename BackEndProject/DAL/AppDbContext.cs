using BackEndProject.Models;
using Microsoft.AspNetCore.Identity;
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
        public DbSet<Tag> Tags { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id= "39792324-9bcf-41cc-aff7-9421ab090dbf",
                    Name="Member"
                },
                new IdentityRole
                {
                    Id = "7985400a-d644-4954-a0c5-f579a46dd5c6",
                    Name = "Admin"
                },
                new IdentityRole
                {
                    Id = "d76fa29e-8b9b-431d-90e1-641c634654da",
                    Name = "SuperAdmin"
                });
            

            builder.Entity<Category>().HasData(
                
                new Category
                {
                    Id=1,
                    Name="Computers",
                    ImageUrl= "category-1.jpg"
                },
                new Category
                {
                    Id = 2,
                    Name = "Monitors",
                    ImageUrl = "category-2.jpg"
                }, 
                new Category
                {
                    Id = 3,
                    Name = "Watches",
                    ImageUrl = "category-8.jpg"
                },
                new Category
                {
                    Id = 4,
                    Name = "Notebooks",
                    ImageUrl = "category-1.jpg"
                },
                new Category
                {
                    Id = 5,
                    Name = "Game Consoles",
                    ImageUrl = "category-4.jpg"
                },
                new Category
                {
                    Id = 6,
                    Name = "Washing Machine",
                    ImageUrl = "category-9.jpg"
                },
                new Category
                {
                    Id = 7,
                    Name = "Batteries",
                    ImageUrl = "category-12.jpg"
                },
                new Category
                {
                    Id = 8,
                    Name = "Cameras",
                    ImageUrl = "category-10.jpg"
                },
                new Category
                {
                    Id = 9,
                    Name = "Printers",
                    ImageUrl = "category-7.jpg"
                },
                new Category
                {
                    Id = 10,
                    Name = "Video Games",
                    ImageUrl = "vg.jpg"
                },
                new Category
                {
                    Id = 11,
                    Name = "Nasa Super Computers",
                    ParentId = 1
                },
                new Category
                {
                    Id = 12,
                    Name = "Office Computers",
                    ParentId = 1
                }
                ,
                new Category
                {
                    Id = 13,
                    Name = "Gaming Monitor",
                    ParentId = 2
                },
                new Category
                {
                    Id = 14,
                    Name = "Standart Monitor",
                    ParentId = 2
                },
                new Category
                {
                    Id = 15,
                    Name = "Digital Watches",
                    ParentId = 3
                },
                new Category
                {
                    Id = 16,
                    Name = "Analog Watches",
                    ParentId = 3
                },
                new Category
                {
                    Id = 17,
                    Name = "Gaming Notebook",
                    ParentId = 4
                },
                new Category
                {
                    Id = 18,
                    Name = "Word Notebook",
                    ParentId = 4
                },
                new Category
                {
                    Id = 19,
                    Name = "Wired Oldschool",
                    ParentId = 5
                },
                new Category
                {
                    Id = 20,
                    Name = "Next Generation",
                    ParentId = 5
                },
                new Category
                {
                    Id = 21,
                    Name = "Large Machine",
                    ParentId = 6
                },
                new Category
                {
                    Id = 22,
                    Name = "Standart",
                    ParentId = 6
                },
                new Category
                {
                    Id = 23,
                    Name = "Power Banks",
                    ParentId = 7
                },
                new Category
                {
                    Id = 24,
                    Name = "Adapters",
                    ParentId = 7
                },
                new Category
                {
                    Id = 25,
                    Name = "Telescopic Cameras",
                    ParentId = 8
                },
                new Category
                {
                    Id = 26,
                    Name = "Digital Cameras",
                    ParentId = 8
                },
                new Category
                {
                    Id = 27,
                    Name = "Laser Printers",
                    ParentId = 9
                },
                new Category
                {
                    Id = 28,
                    Name = "Inky Printers",
                    ParentId = 9
                },
                new Category
                {
                    Id = 29,
                    Name = "Bracalet",
                    ParentId = 10
                },
                new Category
                {
                    Id = 30,
                    Name = "Headsets",
                    ParentId = 10
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
                    CardsImageUrl = "payment.png",
                    NewsLetterImgUrl = "bg-newletter.jpg"
                }
                );

            builder.Entity<Product>().HasData(
                 new Product
                 {
                     Id = 1,
                     Name = "Macbook Pro",
                     NewArrival = true,
                     Bestseller = true,
                     BrandId = 2,
                     CategoryId = 1,
                     Count = 20,
                     Price = 2000,
                     DiscountPercent = 10,
                     DiscountPrice = 1800,
                     TaxPercent = 10,
                     InStock = true,
                     IsFeatured = true,
                     IsDeleted = false,
                     IsAvailability = true,
                     IsSpecial = true,
                     Description = "This Model Is Special",
                     CreatedTime = System.DateTime.ParseExact("Saturday, 23 July 2022 00:46:20.0311359", "dddd, dd MMMM yyyy HH:mm:ss.fffffff", null)
                 });
            builder.Entity<Tag>().HasData(
                 new Tag
                 {
                     Id = 1,
                     Name = "Camera"
                 },
                 new Tag
                 {
                     Id = 2,
                     Name = "Drone"
                 },
                 new Tag
                 {
                     Id = 3,
                     Name = "Music"
                 },
                 new Tag
                 {
                     Id = 4,
                     Name = "Memory"
                 },
                 new Tag
                 {
                     Id = 5,
                     Name = "Gaming"
                 },
                 new Tag
                 {
                     Id = 6,
                     Name = "Premium"
                 });
            builder.Entity<Brand>().HasData(
               new Brand
               {
                   Id = 1,
                   Name = "David Smith",
                   ImageUrl = "brand-1.jpg"
               },
               new Brand
               {
                   Id = 2,
                   Name = "Avant Garde",
                   ImageUrl = "brand-2.jpg",
               },
               new Brand
               {
                   Id = 3,
                   Name = "Climb The Mountain",
                   ImageUrl = "brand-3.jpg",
               },
               new Brand
               {
                   Id = 4,
                   Name = "Ostrich Cafe",
                   ImageUrl = "brand-4.jpg",
               },
               new Brand
               {
                   Id = 5,
                   Name = "Golden",
                   ImageUrl = "brand-5.jpg",
               },
               new Brand
               {
                   Id = 6,
                   Name = "Norcold",
                   ImageUrl = "brand-6.jpg"
               },
               new Brand
               {
                   Id = 7,
                   Name = "Apple",
                   ImageUrl = "brand-7.png"
               }
          );
               builder.Entity<ProductImage>().HasData(
               new ProductImage
               {
                   Id = 1,
                   ProductId = 1,
                   ImageUrl = "product-1.jpg",
                   IsMain = true,
               },
               new ProductImage
               {
                   Id = 2,
                   ProductId = 1,
                   ImageUrl = "product-2.jpg",
                   IsMain = false,
               },
               new ProductImage
               {
                   Id = 3,
                   ProductId = 1,
                   ImageUrl = "product-3.jpg",
                   IsMain = false,
               },
               new ProductImage
               {
                   Id = 4,
                   ProductId = 1,
                   ImageUrl = "product-4.jpg",
                   IsMain = false,
               },
               new ProductImage
               {
                   Id = 5,
                   ProductId = 1,
                   ImageUrl = "product-5.jpg",
                   IsMain = false,
               } );
            builder.Entity<ProductTags>().HasData(
              new ProductTags
              {
                  Id = 1,
                  ProductId = 1,
                  TagId = 6,
              }
         );
            builder.Entity<Slider>().HasData(
                new Slider
                {
                    Id= 1,
                    ImageUrl = "slider-1.jpg",
                    Subtitle = "Save $120 when you buy",
                    MainTitle = "<span>2020 Virtual Reality </span> Fulldive VR.",
                    Description = "Explore and immerse in exciting 360 content with Fulldive’s all-in-one virtual reality platform"
                },
                new Slider
                {
                    Id = 2,
                    ImageUrl = "slider-2.jpg",
                    Subtitle = "Save $120 when you buy",
                    MainTitle = "<span>4K HDR Smart TV 43 </span> Sony Bravia.",
                    Description = "Explore and immerse in exciting 360 content with Fulldive’s all-in-one virtual reality platform"
                }
                );
        }
    }
}