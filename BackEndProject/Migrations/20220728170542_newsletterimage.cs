using Microsoft.EntityFrameworkCore.Migrations;

namespace BackEndProject.Migrations
{
    public partial class newsletterimage : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "NewsLetterImgUrl",
                table: "Bios",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Bios",
                keyColumn: "Id",
                keyValue: 1,
                column: "NewsLetterImgUrl",
                value: "bg-newletter.jpg");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NewsLetterImgUrl",
                table: "Bios");
        }
    }
}
