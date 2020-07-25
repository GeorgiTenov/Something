using Microsoft.EntityFrameworkCore.Migrations;

namespace Hire_work.Migrations
{
    public partial class WorkerControlAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLogged",
                table: "Workers",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRegistered",
                table: "Workers",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLogged",
                table: "Workers");

            migrationBuilder.DropColumn(
                name: "IsRegistered",
                table: "Workers");
        }
    }
}
