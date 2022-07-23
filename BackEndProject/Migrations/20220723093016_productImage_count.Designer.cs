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
    [Migration("20220723093016_productImage_count")]
    partial class productImage_count
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

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Brands");
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
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("ParentId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 21,
                            ImageUrl = "category-6.jpg",
                            Name = "Computers"
                        },
                        new
                        {
                            Id = 22,
                            ImageUrl = "category-2.jpg",
                            Name = "Monitors"
                        },
                        new
                        {
                            Id = 23,
                            ImageUrl = "category-8.jpg",
                            Name = "Watches"
                        },
                        new
                        {
                            Id = 24,
                            ImageUrl = "category-1.jpg",
                            Name = "Notebooks"
                        },
                        new
                        {
                            Id = 25,
                            ImageUrl = "category-4.jpg",
                            Name = "Game Consoles"
                        },
                        new
                        {
                            Id = 26,
                            ImageUrl = "category-9.jpg",
                            Name = "Washing Machine"
                        },
                        new
                        {
                            Id = 27,
                            ImageUrl = "category-12.jpg",
                            Name = "Batteries"
                        },
                        new
                        {
                            Id = 28,
                            ImageUrl = "category-10.jpg",
                            Name = "Cameras"
                        },
                        new
                        {
                            Id = 29,
                            ImageUrl = "category-7.jpg",
                            Name = "Printers"
                        },
                        new
                        {
                            Id = 31,
                            ImageUrl = "category-8.jpg",
                            Name = "Video Games"
                        },
                        new
                        {
                            Id = 32,
                            ImageUrl = "category-8.jpg",
                            Name = "Accessories"
                        },
                        new
                        {
                            Id = 33,
                            ImageUrl = "category-13.jpg",
                            Name = "Implants"
                        },
                        new
                        {
                            Id = 34,
                            ImageUrl = "category-14.jpg",
                            Name = "Gerenade Laucnhers"
                        },
                        new
                        {
                            Id = 35,
                            ImageUrl = "category-15.jpg",
                            Name = "Pets"
                        },
                        new
                        {
                            Id = 36,
                            ImageUrl = "category-16.jpg",
                            Name = "Nuclear Weapons"
                        },
                        new
                        {
                            Id = 37,
                            ImageUrl = "category-17.jpg",
                            Name = "SuperCars"
                        },
                        new
                        {
                            Id = 38,
                            ImageUrl = "category-18.jpg",
                            Name = "Space Ships"
                        },
                        new
                        {
                            Id = 39,
                            ImageUrl = "category-19.jpg",
                            Name = "Tanks"
                        },
                        new
                        {
                            Id = 40,
                            ImageUrl = "category-20.jpg",
                            Name = "Automatic Assault Rifles"
                        },
                        new
                        {
                            Id = 41,
                            Name = "Nasa Super Computers",
                            ParentId = 21
                        },
                        new
                        {
                            Id = 42,
                            Name = "Office Computers",
                            ParentId = 21
                        },
                        new
                        {
                            Id = 43,
                            Name = "Gaming Monitor",
                            ParentId = 22
                        },
                        new
                        {
                            Id = 44,
                            Name = "Standart Monitor",
                            ParentId = 22
                        },
                        new
                        {
                            Id = 45,
                            Name = "Digital Watches",
                            ParentId = 23
                        },
                        new
                        {
                            Id = 46,
                            Name = "Analog Watches",
                            ParentId = 23
                        },
                        new
                        {
                            Id = 47,
                            Name = "Gaming Notebook",
                            ParentId = 24
                        },
                        new
                        {
                            Id = 48,
                            Name = "Word Notebook",
                            ParentId = 24
                        },
                        new
                        {
                            Id = 49,
                            Name = "Wired Oldschool",
                            ParentId = 25
                        },
                        new
                        {
                            Id = 50,
                            Name = "Next Generation",
                            ParentId = 25
                        },
                        new
                        {
                            Id = 51,
                            Name = "Large Machine",
                            ParentId = 26
                        },
                        new
                        {
                            Id = 52,
                            Name = "Standart",
                            ParentId = 26
                        },
                        new
                        {
                            Id = 53,
                            Name = "Power Banks",
                            ParentId = 27
                        },
                        new
                        {
                            Id = 54,
                            Name = "Adapters",
                            ParentId = 27
                        },
                        new
                        {
                            Id = 55,
                            Name = "Telescopic Cameras",
                            ParentId = 28
                        },
                        new
                        {
                            Id = 56,
                            Name = "Digital Cameras",
                            ParentId = 28
                        },
                        new
                        {
                            Id = 57,
                            Name = "Laser Printers",
                            ParentId = 29
                        },
                        new
                        {
                            Id = 58,
                            Name = "Inky Printers",
                            ParentId = 29
                        },
                        new
                        {
                            Id = 59,
                            Name = "Bracalet",
                            ParentId = 32
                        },
                        new
                        {
                            Id = 60,
                            Name = "Headsets",
                            ParentId = 32
                        },
                        new
                        {
                            Id = 61,
                            Name = "Pc Video Games",
                            ParentId = 31
                        },
                        new
                        {
                            Id = 62,
                            Name = "Console Video Games",
                            ParentId = 31
                        },
                        new
                        {
                            Id = 63,
                            Name = "Robotic Heart",
                            ParentId = 33
                        },
                        new
                        {
                            Id = 64,
                            Name = "Robotic Eye",
                            ParentId = 33
                        },
                        new
                        {
                            Id = 65,
                            Name = "Electronic",
                            ParentId = 34
                        },
                        new
                        {
                            Id = 66,
                            Name = "Close Range",
                            ParentId = 34
                        },
                        new
                        {
                            Id = 67,
                            Name = "Cats",
                            ParentId = 35
                        },
                        new
                        {
                            Id = 68,
                            Name = "Dogs",
                            ParentId = 35
                        },
                        new
                        {
                            Id = 69,
                            Name = "Hydrogen Bombs",
                            ParentId = 36
                        },
                        new
                        {
                            Id = 70,
                            Name = "Electro Magnetic Bombs",
                            ParentId = 36
                        },
                        new
                        {
                            Id = 71,
                            Name = "Supersports",
                            ParentId = 37
                        },
                        new
                        {
                            Id = 72,
                            Name = "Hyper Cars",
                            ParentId = 37
                        },
                        new
                        {
                            Id = 73,
                            Name = "Orbiter spacecraft",
                            ParentId = 38
                        },
                        new
                        {
                            Id = 74,
                            Name = "Rover Spacecraft",
                            ParentId = 38
                        },
                        new
                        {
                            Id = 75,
                            Name = "Heavy Tanks",
                            ParentId = 39
                        },
                        new
                        {
                            Id = 76,
                            Name = "Artillery Tanks",
                            ParentId = 39
                        },
                        new
                        {
                            Id = 77,
                            Name = "Close Range Rifles",
                            ParentId = 40
                        },
                        new
                        {
                            Id = 78,
                            Name = "Long Range Rifles",
                            ParentId = 40
                        });
                });

            modelBuilder.Entity("BackEndProject.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AppUserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("int");

                    b.Property<DateTime>("OrderedAt")
                        .HasColumnType("datetime2");

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

                    b.Property<double>("DiscountPrice")
                        .HasColumnType("float");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<bool>("IsFeatured")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastUpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("NewArrival")
                        .HasColumnType("bit");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("BrandId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Products");
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
                });

            modelBuilder.Entity("BackEndProject.Models.TagProducts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ProductId")
                        .HasColumnType("int");

                    b.Property<int>("TagId")
                        .HasColumnType("int");

                    b.Property<int?>("TagsId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.HasIndex("TagsId");

                    b.ToTable("TagProducts");
                });

            modelBuilder.Entity("BackEndProject.Models.Tags", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tags");
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

            modelBuilder.Entity("BackEndProject.Models.TagProducts", b =>
                {
                    b.HasOne("BackEndProject.Models.Product", "Product")
                        .WithMany("TagProducts")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BackEndProject.Models.Tags", "Tags")
                        .WithMany("TagProducts")
                        .HasForeignKey("TagsId");
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
