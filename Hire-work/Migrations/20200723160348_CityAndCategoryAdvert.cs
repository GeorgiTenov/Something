using Microsoft.EntityFrameworkCore.Migrations;

namespace Hire_work.Migrations
{
    public partial class CityAndCategoryAdvert : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "City",
                table: "Adverts",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MainCategory",
                table: "Adverts",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "City",
                table: "Adverts");

            migrationBuilder.DropColumn(
                name: "MainCategory",
                table: "Adverts");
        }
    }
}
