using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class v12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enferemdad",
                table: "Cliente");

            migrationBuilder.AddColumn<string>(
                name: "Enfermedad",
                table: "Cliente",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enfermedad",
                table: "Cliente");

            migrationBuilder.AddColumn<string>(
                name: "Enferemdad",
                table: "Cliente",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
