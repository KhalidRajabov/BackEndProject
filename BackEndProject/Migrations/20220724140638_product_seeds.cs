using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndProject.Migrations
{
    public partial class product_seeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Brands",
                columns: new[] { "Id", "CreatedTime", "DeletedAt", "IsDeleted", "LastUpdatedAt", "Name" },
                values: new object[,]
                {
                    { 4, null, null, false, null, "Panzer" },
                    { 5, null, null, false, null, "Scottish Fold" },
                    { 6, null, null, false, null, "Nikon" }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Bestseller", "BrandId", "CategoryId", "Count", "CreatedTime", "DeletedAt", "DiscountPrice", "ImageUrl", "InStock", "IsDeleted", "IsFeatured", "LastUpdatedAt", "Name", "NewArrival", "Price" },
                values: new object[,]
                {
                    { 2, false, 2, 24, 0, null, null, 0.0, "fdf71496-64a2-4fdb-99ca-39c18da8fe70Feral_cat_1.jpg", false, false, false, null, "Phone", false, 300.0 },
                    { 3, false, 1, 22, 0, null, null, 0.0, "21c4a6bb-640d-4ded-8206-1b5c92099299blog-3.jpg", false, false, false, null, "TV", false, 3060.0 },
                    { 5, false, 3, 25, 0, null, null, 0.0, "1bc92d08-4460-41d0-bc51-76793a323c20product-3.jpg", false, false, false, null, "Gamepad", false, 150.0 },
                    { 6, false, 1, 60, 0, null, null, 0.0, "463153dc-6576-4b71-b441-22ce21b4c93cproduct-5.jpg", false, false, false, null, "Headset", false, 149.0 }
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Bestseller", "BrandId", "CategoryId", "Count", "CreatedTime", "DeletedAt", "DiscountPrice", "ImageUrl", "InStock", "IsDeleted", "IsFeatured", "LastUpdatedAt", "Name", "NewArrival", "Price" },
                values: new object[] { 4, false, 4, 39, 0, null, null, 0.0, "6bebb419-b65c-483e-9498-59ce14ae04c5category-19.jpg", false, false, false, null, "Tank", false, 1000000.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Bestseller", "BrandId", "CategoryId", "Count", "CreatedTime", "DeletedAt", "DiscountPrice", "ImageUrl", "InStock", "IsDeleted", "IsFeatured", "LastUpdatedAt", "Name", "NewArrival", "Price" },
                values: new object[] { 1, false, 5, 35, 0, null, null, 0.0, "ae5f144e-f4ac-4cdf-b766-d84abe2144e2cutie.jpg", false, false, false, null, "Cat", false, 45.0 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Bestseller", "BrandId", "CategoryId", "Count", "CreatedTime", "DeletedAt", "DiscountPrice", "ImageUrl", "InStock", "IsDeleted", "IsFeatured", "LastUpdatedAt", "Name", "NewArrival", "Price" },
                values: new object[] { 7, false, 6, 28, 0, null, null, 0.0, "bd074159-e7c2-4b52-bab8-681949bb0952product-10.jpg", false, false, false, null, "Camera", false, 5000.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2);

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

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Brands",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
