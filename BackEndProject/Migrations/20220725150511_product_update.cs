using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndProject.Migrations
{
    public partial class product_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Products",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "DiscountPercent",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<bool>(
                name: "IsAvailability",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsSpecial",
                table: "Products",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<double>(
                name: "TaxPercent",
                table: "Products",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Bestseller", "CategoryId", "Count", "CreatedTime", "Description", "DiscountPercent", "DiscountPrice", "ImageUrl", "InStock", "IsAvailability", "IsFeatured", "IsSpecial", "Name", "NewArrival", "Price", "TaxPercent" },
                values: new object[] { true, 2, 20, new DateTime(2022, 7, 23, 0, 46, 20, 31, DateTimeKind.Unspecified).AddTicks(1359), "This Model Is Special", 10.0, 1800.0, null, true, true, true, true, "Macbook Pro", true, 2000.0, 10.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Description",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "DiscountPercent",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsAvailability",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsSpecial",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "TaxPercent",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Bestseller", "CategoryId", "Count", "CreatedTime", "DiscountPrice", "ImageUrl", "InStock", "IsFeatured", "Name", "NewArrival", "Price" },
                values: new object[] { false, 24, 0, null, 0.0, "fdf71496-64a2-4fdb-99ca-39c18da8fe70Feral_cat_1.jpg", false, false, "Phone", false, 3100.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Bestseller", "BrandId", "CategoryId", "Count", "CreatedTime", "DeletedAt", "DiscountPrice", "ImageUrl", "InStock", "IsDeleted", "IsFeatured", "LastUpdatedAt", "Name", "NewArrival", "Price" },
                values: new object[,]
                {
                    { 1, false, 5, 35, 0, null, null, 0.0, "ae5f144e-f4ac-4cdf-b766-d84abe2144e2cutie.jpg", false, false, false, null, "Cat", false, 145.0 },
                    { 3, false, 1, 22, 0, null, null, 0.0, "21c4a6bb-640d-4ded-8206-1b5c92099299blog-3.jpg", false, false, false, null, "TV", false, 3160.0 },
                    { 4, false, 4, 39, 0, null, null, 0.0, "6bebb419-b65c-483e-9498-59ce14ae04c5category-19.jpg", false, false, false, null, "Tank", false, 11000000.0 },
                    { 5, false, 3, 25, 0, null, null, 0.0, "1bc92d08-4460-41d0-bc51-76793a323c20product-3.jpg", false, false, false, null, "Gamepad", false, 151.0 },
                    { 6, false, 1, 60, 0, null, null, 0.0, "463153dc-6576-4b71-b441-22ce21b4c93cproduct-5.jpg", false, false, false, null, "Headset", false, 150.0 },
                    { 7, false, 6, 28, 0, null, null, 0.0, "bd074159-e7c2-4b52-bab8-681949bb0952product-10.jpg", false, false, false, null, "Camera", false, 5100.0 }
                });
        }
    }
}
