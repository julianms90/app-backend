using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class v11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PadeceEnfermedad",
                table: "Cliente");

            migrationBuilder.AddColumn<string>(
                name: "Enferemdad",
                table: "Cliente",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Enferemdad",
                table: "Cliente");

            migrationBuilder.AddColumn<bool>(
                name: "PadeceEnfermedad",
                table: "Cliente",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
