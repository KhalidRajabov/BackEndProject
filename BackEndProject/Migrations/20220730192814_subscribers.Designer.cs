﻿// <auto-generated />
using System;
using BackEndProject.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BackEndProject.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20220730192814_subscribers")]
    partial class subscribers
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BackEndProject.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("Fullname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActivated")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BackEndProject.Models.Bio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CardsImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CouponCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Logo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NewsLetterImgUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Phone")
                        .HasColumnType("int");

                    b.Property<int>("SupportNumber")
                        .HasColumnType("int");

                    b.Property<string>("WorkTimes")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Bios");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "45 Grand Central Terminal New York,NY 1017 United State USA",
                            Author = "Me Myself",
                            CardsImageUrl = "payment.png",
                            CouponCode = "<p>Get FREE Shipping with <b>$35!</b> Code: FREESHIPPING</p>",
                            Email = "email@yourwebsitename.com",
                            Logo = "logo.png",
                            NewsLetterImgUrl = "bg-newletter.jpg",
                            Phone = 123456789,
                            SupportNumber = 500500500,
                            WorkTimes = "Mon-Sat 9:00pm - 5:00pm Sun:Closed"
                        });
                });

            modelBuilder.Entity("BackEndProject.Models.Brand", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "brand-1.jpg",
                            IsDeleted = false,
                            Name = "David Smith"
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "brand-2.jpg",
                            IsDeleted = false,
                            Name = "Avant Garde"
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "brand-3.jpg",
                            IsDeleted = false,
                            Name = "Climb The Mountain"
                        },
                        new
                        {
                            Id = 4,
                            ImageUrl = "brand-4.jpg",
                            IsDeleted = false,
                            Name = "Ostrich Cafe"
                        },
                        new
                        {
                            Id = 5,
                            ImageUrl = "brand-5.jpg",
                            IsDeleted = false,
                            Name = "Golden"
                        },
                        new
                        {
                            Id = 6,
                            ImageUrl = "brand-6.jpg",
                            IsDeleted = false,
                            Name = "Norcold"
                        },
                        new
                        {
                            Id = 7,
                            ImageUrl = "brand-7.png",
                            IsDeleted = false,
                            Name = "Apple"
                        });
                });

            modelBuilder.Entity("BackEndProject.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "category-1.jpg",
                            Name = "Computers"
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "category-2.jpg",
                            Name = "Monitors"
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "category-8.jpg",
                            Name = "Watches"
                        },
                        new
                        {
                            Id = 4,
                            ImageUrl = "category-1.jpg",
                            Name = "Notebooks"
                        },
                        new
                        {
                            Id = 5,
                            ImageUrl = "category-4.jpg",
                            Name = "Game Consoles"
                        },
                        new
                        {
                            Id = 6,
                            ImageUrl = "category-9.jpg",
                            Name = "Washing Machine"
                        },
                        new
                        {
                            Id = 7,
                            ImageUrl = "category-12.jpg",
                            Name = "Batteries"
                        },
                        new
                        {
                            Id = 8,
                            ImageUrl = "category-10.jpg",
                            Name = "Cameras"
                        },
                        new
                        {
                            Id = 9,
                            ImageUrl = "category-7.jpg",
                            Name = "Printers"
                        },
                        new
                        {
                            Id = 10,
                            ImageUrl = "vg.jpg",
                            Name = "Video Games"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Nasa Super Computers",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 12,
                            Name = "Office Computers",
                            ParentId = 1
                        },
                        new
                        {
                            Id = 13,
                            Name = "Gaming Monitor",
                            ParentId = 2
                        },
                        new
                        {
                            Id = 14,
                            Name = "Standart Monitor",
                            ParentId = 2
                        },
                        new
                        {
                            Id = 15,
                            Name = "Digital Watches",
                            ParentId = 3
                        },
                        new
                        {
                            Id = 16,
                            Name = "Analog Watches",
                            ParentId = 3
                        },
                        new
                        {
                            Id = 17,
                            Name = "Gaming Notebook",
                            ParentId = 4
                        },
                        new
                        {
                            Id = 18,
                            Name = "Word Notebook",
                            ParentId = 4
                        },
                        new
                        {
                            Id = 19,
                            Name = "Wired Oldschool",
                            ParentId = 5
                        },
                        new
                        {
                            Id = 20,
                            Name = "Next Generation",
                            ParentId = 5
                        },
                        new
                        {
                            Id = 21,
                            Name = "Large Machine",
                            ParentId = 6
                        },
                        new
                        {
                            Id = 22,
                            Name = "Standart",
                            ParentId = 6
                        },
                        new
                        {
                            Id = 23,
                            Name = "Power Banks",
                            ParentId = 7
                        },
                        new
                        {
                            Id = 24,
                            Name = "Adapters",
                            ParentId = 7
                        },
                        new
                        {
                            Id = 25,
                            Name = "Telescopic Cameras",
                            ParentId = 8
                        },
                        new
                        {
                            Id = 26,
                            Name = "Digital Cameras",
                            ParentId = 8
                        },
                        new
                        {
                            Id = 27,
                            Name = "Laser Printers",
                            ParentId = 9
                        },
                        new
                        {
                            Id = 28,
                            Name = "Inky Printers",
                            ParentId = 9
                        },
                        new
                        {
                            Id = 29,
                            Name = "Bracalet",
                            ParentId = 10
                        },
                        new
                        {
                            Id = 30,
                            Name = "Headsets",
                            ParentId = 10
                        });
                });

            modelBuilder.Entity("BackEndProject.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Companyname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Country")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Firstname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lastname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("Zipcode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AppUserId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("BackEndProject.Models.OrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<int>("OrderId")
                        .HasColumnType("int");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<double>("Total")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("BackEndProject.Models.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Bestseller")
                        .HasColumnType("bit");

                    b.Property<int>("BrandId")
                        .HasColumnType("int");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<int>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeletedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("DiscountPercent")
                        .HasColumnType("float");

                    b.Property<double>("DiscountPrice")
                        .HasColumnType("float");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<bool>("IsAvailability")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFeatured")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSpecial")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NewArrival")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("TaxPercent")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Bestseller = true,
                            BrandId = 2,
                            CategoryId = 1,
                            Count = 20,
                            CreatedTime = new DateTime(2022, 7, 23, 0, 46, 20, 31, DateTimeKind.Unspecified).AddTicks(1359),
                            Description = "This Model Is Special",
                            DiscountPercent = 10.0,
                            DiscountPrice = 1800.0,
                            InStock = true,
                            IsAvailability = true,
                            IsDeleted = false,
                            IsFeatured = true,
                            IsSpecial = true,
                            Name = "Macbook Pro",
                            NewArrival = true,
                            Price = 2000.0,
                            TaxPercent = 10.0
                        });
                });

            modelBuilder.Entity("BackEndProject.Models.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsMain")
                        .HasColumnType("bit");

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("ProductImages");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ImageUrl = "product-1.jpg",
                            IsMain = true,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 2,
                            ImageUrl = "product-2.jpg",
                            IsMain = false,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 3,
                            ImageUrl = "product-3.jpg",
                            IsMain = false,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 4,
                            ImageUrl = "product-4.jpg",
                            IsMain = false,
                            ProductId = 1
                        },
                        new
                        {
                            Id = 5,
                            ImageUrl = "product-5.jpg",
                            IsMain = false,
                            ProductId = 1
                        });
                });

            modelBuilder.Entity("BackEndProject.Models.ProductTags", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("TagId");

                    b.ToTable("ProductTags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ProductId = 1,
                            TagId = 6
                        });
                });

            modelBuilder.Entity("BackEndProject.Models.Slider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MainTitle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Subtitle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sliders");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Explore and immerse in exciting 360 content with Fulldive’s all-in-one virtual reality platform",
                            ImageUrl = "slider-1.jpg",
                            MainTitle = "<span>2020 Virtual Reality </span> Fulldive VR.",
                            Subtitle = "Save $120 when you buy"
                        },
                        new
                        {
                            Id = 2,
                            Description = "Explore and immerse in exciting 360 content with Fulldive’s all-in-one virtual reality platform",
                            ImageUrl = "slider-2.jpg",
                            MainTitle = "<span>4K HDR Smart TV 43 </span> Sony Bravia.",
                            Subtitle = "Save $120 when you buy"
                        });
                });

            modelBuilder.Entity("BackEndProject.Models.Tag", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Camera"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Drone"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Music"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Memory"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Gaming"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Premium"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("BackEndProject.Models.Category", b =>
                {
                    b.HasOne("BackEndProject.Models.Category", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("BackEndProject.Models.Order", b =>
                {
                    b.HasOne("BackEndProject.Models.AppUser", "AppUser")
                        .WithMany("Orders")
                        .HasForeignKey("AppUserId");
                });

            modelBuilder.Entity("BackEndProject.Models.OrderItem", b =>
                {
                    b.HasOne("BackEndProject.Models.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndProject.Models.Product", "Product")
                        .WithMany("OrderItem")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEndProject.Models.Product", b =>
                {
                    b.HasOne("BackEndProject.Models.Brand", "Brand")
                        .WithMany("Products")
                        .HasForeignKey("BrandId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndProject.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEndProject.Models.ProductImage", b =>
                {
                    b.HasOne("BackEndProject.Models.Product", "Product")
                        .WithMany("ProductImages")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BackEndProject.Models.ProductTags", b =>
                {
                    b.HasOne("BackEndProject.Models.Product", "Product")
                        .WithMany("ProductTags")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndProject.Models.Tag", "Tags")
                        .WithMany("ProductTag")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BackEndProject.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BackEndProject.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndProject.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("BackEndProject.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
