using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndProject.Migrations
{
    public partial class seedsupdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedTime", "DeletedAt", "ImageUrl", "IsDeleted", "LastUpdatedAt", "Name", "ParentId" },
                values: new object[,]
                {
                    { 21, null, null, "category-6.jpg", null, null, "Computers", null },
                    { 38, null, null, "category-18.jpg", null, null, "Space Ships", null },
                    { 37, null, null, "category-17.jpg", null, null, "SuperCars", null },
                    { 36, null, null, "category-16.jpg", null, null, "Nuclear Weapons", null },
                    { 35, null, null, "category-15.jpg", null, null, "Pets", null },
                    { 34, null, null, "category-14.jpg", null, null, "Gerenade Laucnhers", null },
                    { 33, null, null, "category-13.jpg", null, null, "Implants", null },
                    { 32, null, null, "category-8.jpg", null, null, "Accessories", null },
                    { 39, null, null, "category-19.jpg", null, null, "Tanks", null },
                    { 31, null, null, "category-8.jpg", null, null, "Video Games", null },
                    { 28, null, null, "category-10.jpg", null, null, "Cameras", null },
                    { 27, null, null, "category-12.jpg", null, null, "Batteries", null },
                    { 26, null, null, "category-9.jpg", null, null, "Washing Machine", null },
                    { 25, null, null, "category-4.jpg", null, null, "Game Consoles", null },
                    { 24, null, null, "category-1.jpg", null, null, "Notebooks", null },
                    { 23, null, null, "category-8.jpg", null, null, "Watches", null },
                    { 22, null, null, "category-2.jpg", null, null, "Monitors", null },
                    { 29, null, null, "category-7.jpg", null, null, "Printers", null },
                    { 40, null, null, "category-20.jpg", null, null, "Automatic Assault Rifles", null }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedTime", "DeletedAt", "ImageUrl", "IsDeleted", "LastUpdatedAt", "Name", "ParentId" },
                values: new object[,]
                {
                    { 41, null, null, null, null, null, "Nasa Super Computers", 21 },
                    { 60, null, null, null, null, null, "Headsets", 32 },
                    { 63, null, null, null, null, null, "Robotic Heart", 33 },
                    { 64, null, null, null, null, null, "Robotic Eye", 33 },
                    { 65, null, null, null, null, null, "Electronic", 34 },
                    { 66, null, null, null, null, null, "Close Range", 34 },
                    { 67, null, null, null, null, null, "Cats", 35 },
                    { 68, null, null, null, null, null, "Dogs", 35 },
                    { 69, null, null, null, null, null, "Hydrogen Bombs", 36 },
                    { 70, null, null, null, null, null, "Electro Magnetic Bombs", 36 },
                    { 71, null, null, null, null, null, "Supersports", 37 },
                    { 72, null, null, null, null, null, "Hyper Cars", 37 },
                    { 73, null, null, null, null, null, "Orbiter spacecraft", 38 },
                    { 74, null, null, null, null, null, "Rover Spacecraft", 38 },
                    { 75, null, null, null, null, null, "Heavy Tanks", 39 },
                    { 76, null, null, null, null, null, "Artillery Tanks", 39 },
                    { 59, null, null, null, null, null, "Bracalet", 32 },
                    { 62, null, null, null, null, null, "Console Video Games", 31 },
                    { 61, null, null, null, null, null, "Pc Video Games", 31 },
                    { 58, null, null, null, null, null, "Inky Printers", 29 },
                    { 42, null, null, null, null, null, "Office Computers", 21 },
                    { 43, null, null, null, null, null, "Gaming Monitor", 22 },
                    { 44, null, null, null, null, null, "Standart Monitor", 22 },
                    { 45, null, null, null, null, null, "Digital Watches", 23 },
                    { 46, null, null, null, null, null, "Analog Watches", 23 },
                    { 47, null, null, null, null, null, "Gaming Notebook", 24 },
                    { 48, null, null, null, null, null, "Word Notebook", 24 },
                    { 77, null, null, null, null, null, "Close Range Rifles", 40 },
                    { 49, null, null, null, null, null, "Wired Oldschool", 25 },
                    { 51, null, null, null, null, null, "Large Machine", 26 },
                    { 52, null, null, null, null, null, "Standart", 26 },
                    { 53, null, null, null, null, null, "Power Banks", 27 },
                    { 54, null, null, null, null, null, "Adapters", 27 },
                    { 55, null, null, null, null, null, "Telescopic Cameras", 28 },
                    { 56, null, null, null, null, null, "Digital Cameras", 28 },
                    { 57, null, null, null, null, null, "Laser Printers", 29 },
                    { 50, null, null, null, null, null, "Next Generation", 25 },
                    { 78, null, null, null, null, null, "Long Range Rifles", 40 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedTime", "DeletedAt", "ImageUrl", "IsDeleted", "LastUpdatedAt", "Name", "ParentId" },
                values: new object[,]
                {
                    { 1, null, null, "category-6.jpg", null, null, "Computers", null },
                    { 18, null, null, "category-18.jpg", null, null, "Space Ships", null },
                    { 17, null, null, "category-17.jpg", null, null, "SuperCars", null },
                    { 16, null, null, "category-16.jpg", null, null, "Nuclear Weapons", null },
                    { 15, null, null, "category-15.jpg", null, null, "Pets", null },
                    { 14, null, null, "category-14.jpg", null, null, "Gerenade Laucnhers", null },
                    { 13, null, null, "category-13.jpg", null, null, "Implants", null },
                    { 12, null, null, "category-8.jpg", null, null, "Accessories", null },
                    { 11, null, null, "category-8.jpg", null, null, "Video Games", null },
                    { 10, null, null, "category-11.jpg", null, null, "Accessories", null },
                    { 9, null, null, "category-7.jpg", null, null, "Printers", null },
                    { 8, null, null, "category-10.jpg", null, null, "Cameras", null },
                    { 7, null, null, "category-12.jpg", null, null, "Batteries", null },
                    { 6, null, null, "category-9.jpg", null, null, "Washing Machine", null },
                    { 5, null, null, "category-4.jpg", null, null, "Game Consoles", null },
                    { 4, null, null, "category-1.jpg", null, null, "Notebooks", null },
                    { 3, null, null, "category-8.jpg", null, null, "Watches", null },
                    { 2, null, null, "category-2.jpg", null, null, "Monitors", null },
                    { 19, null, null, "category-19.jpg", null, null, "Tanks", null },
                    { 20, null, null, "category-20.jpg", null, null, "Automatic Assault Rifles", null }
                });
        }
    }
}
