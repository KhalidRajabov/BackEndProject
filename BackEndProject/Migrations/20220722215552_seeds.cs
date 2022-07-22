using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndProject.Migrations
{
    public partial class seeds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Bios",
                columns: new[] { "Id", "Address", "Author", "CardsImageUrl", "CouponCode", "Email", "Logo", "Phone", "SupportNumber", "WorkTimes" },
                values: new object[] { 1, "45 Grand Central Terminal New York,NY 1017 United State USA", "Me Myself", "payment.png", "<p>Get FREE Shipping with <b>$35!</b> Code: FREESHIPPING</p>", "email@yourwebsitename.com", "logo.png", 123456789, 500500500, "Mon-Sat 9:00pm - 5:00pm Sun:Closed" });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedTime", "DeletedAt", "ImageUrl", "IsDeleted", "LastUpdatedAt", "Name", "ParentId" },
                values: new object[,]
                {
                    { 18, null, null, "category-18.jpg", null, null, "Space Ships", null },
                    { 17, null, null, "category-17.jpg", null, null, "SuperCars", null },
                    { 16, null, null, "category-16.jpg", null, null, "Nuclear Weapons", null },
                    { 15, null, null, "category-15.jpg", null, null, "Pets", null },
                    { 14, null, null, "category-14.jpg", null, null, "Gerenade Laucnhers", null },
                    { 13, null, null, "category-13.jpg", null, null, "Implants", null },
                    { 12, null, null, "category-8.jpg", null, null, "Accessories", null },
                    { 11, null, null, "category-8.jpg", null, null, "Video Games", null },
                    { 19, null, null, "category-19.jpg", null, null, "Tanks", null },
                    { 10, null, null, "category-11.jpg", null, null, "Accessories", null },
                    { 8, null, null, "category-10.jpg", null, null, "Cameras", null },
                    { 7, null, null, "category-12.jpg", null, null, "Batteries", null },
                    { 6, null, null, "category-9.jpg", null, null, "Washing Machine", null },
                    { 5, null, null, "category-4.jpg", null, null, "Game Consoles", null },
                    { 4, null, null, "category-1.jpg", null, null, "Notebooks", null },
                    { 3, null, null, "category-8.jpg", null, null, "Watches", null },
                    { 2, null, null, "category-2.jpg", null, null, "Monitors", null },
                    { 1, null, null, "category-6.jpg", null, null, "Computers", null },
                    { 9, null, null, "category-7.jpg", null, null, "Printers", null },
                    { 20, null, null, "category-20.jpg", null, null, "Automatic Assault Rifles", null }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Bios",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 20);
        }
    }
}
