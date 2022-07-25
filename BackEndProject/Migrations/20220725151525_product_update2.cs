using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndProject.Migrations
{
    public partial class product_update2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 22);

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Bestseller", "BrandId", "CategoryId", "Count", "CreatedTime", "DeletedAt", "Description", "DiscountPercent", "DiscountPrice", "ImageUrl", "InStock", "IsAvailability", "IsDeleted", "IsFeatured", "IsSpecial", "LastUpdatedAt", "Name", "NewArrival", "Price", "TaxPercent" },
                values: new object[] { 3, true, 1, 25, 20, new DateTime(2022, 7, 23, 0, 46, 20, 31, DateTimeKind.Unspecified).AddTicks(1359), null, "Phone", 10.0, 100.0, null, true, true, false, true, true, null, "Xperia", true, 1500.0, 10.0 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                column: "CategoryId",
                value: 2);
        }
    }
}
