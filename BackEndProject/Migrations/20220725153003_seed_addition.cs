using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndProject.Migrations
{
    public partial class seed_addition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Brands",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "brand-1.jpg", "David Smith" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "brand-2.jpg", "Avant Garde" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "brand-3.jpg", "Climb The Mountain" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "brand-4.jpg", "Ostrich Cafe" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "brand-5.jpg", "Golden" });

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "ImageUrl", "Name" },
                values: new object[] { "brand-6.jpg", "Norcold" });

            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedTime", "DeletedAt", "ImageUrl", "IsDeleted", "LastUpdatedAt", "Name" },
                values: new object[] { 7, null, null, "brand-7.png", false, null, "Apple" });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Bestseller", "BrandId", "CategoryId", "Count", "CreatedTime", "DeletedAt", "Description", "DiscountPercent", "DiscountPrice", "ImageUrl", "InStock", "IsAvailability", "IsDeleted", "IsFeatured", "IsSpecial", "LastUpdatedAt", "Name", "NewArrival", "Price", "TaxPercent" },
                values: new object[] { 22, true, 2, 22, 20, new DateTime(2022, 7, 23, 0, 46, 20, 31, DateTimeKind.Unspecified).AddTicks(1359), null, "This Model Is Special", 10.0, 1800.0, null, true, true, false, true, true, null, "Macbook Pro", true, 2000.0, 10.0 });

            migrationBuilder.InsertData(
                table: "Tags",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Camera" },
                    { 2, "Drone" },
                    { 3, "Music" },
                    { 4, "Memory" },
                    { 5, "Gaming" },
                    { 6, "Premium" }
                });

            migrationBuilder.InsertData(
                table: "ProductImages",
                columns: new[] { "Id", "ImageUrl", "IsMain", "ProductId" },
                values: new object[,]
                {
                    { 1, "special-product-21.jpg", true, 22 },
                    { 2, "special-product-18.jpg", false, 22 },
                    { 3, "special-product-19.jpg", false, 22 },
                    { 4, "special-product-20.jpg", false, 22 },
                    { 5, "special-product-22.jpg", false, 22 }
                });

            migrationBuilder.InsertData(
                table: "TagProducts",
                columns: new[] { "Id", "ProductId", "TagId", "TagsId" },
                values: new object[] { 1, 22, 6, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProductImages",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TagProducts",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Tags",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Brands");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Sony");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Samsung");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 3,
                column: "Name",
                value: "Apple");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4,
                column: "Name",
                value: "Panzer");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5,
                column: "Name",
                value: "Scottish Fold");

            migrationBuilder.UpdateData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6,
                column: "Name",
                value: "Nikon");

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Bestseller", "BrandId", "CategoryId", "Count", "CreatedTime", "DeletedAt", "Description", "DiscountPercent", "DiscountPrice", "ImageUrl", "InStock", "IsAvailability", "IsDeleted", "IsFeatured", "IsSpecial", "LastUpdatedAt", "Name", "NewArrival", "Price", "TaxPercent" },
                values: new object[,]
                {
                    { 2, true, 2, 22, 20, new DateTime(2022, 7, 23, 0, 46, 20, 31, DateTimeKind.Unspecified).AddTicks(1359), null, "This Model Is Special", 10.0, 1800.0, null, true, true, false, true, true, null, "Macbook Pro", true, 2000.0, 10.0 },
                    { 3, true, 1, 25, 20, new DateTime(2022, 7, 23, 0, 46, 20, 31, DateTimeKind.Unspecified).AddTicks(1359), null, "Phone", 10.0, 100.0, null, true, true, false, true, true, null, "Xperia", true, 1500.0, 10.0 }
                });
        }
    }
}
