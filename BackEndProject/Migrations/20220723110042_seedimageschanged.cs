using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndProject.Migrations
{
    public partial class seedimageschanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 31,
                column: "ImageUrl",
                value: "vg.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 32,
                column: "ImageUrl",
                value: "acc.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 33,
                column: "ImageUrl",
                value: "hand.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 31,
                column: "ImageUrl",
                value: "category-8.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 32,
                column: "ImageUrl",
                value: "category-8.jpg");

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 33,
                column: "ImageUrl",
                value: "category-13.jpg");
        }
    }
}
