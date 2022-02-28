using Microsoft.EntityFrameworkCore.Migrations;

namespace Backend.Migrations
{
    public partial class v14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DatosAdicionales_Cliente_ClienteId",
                table: "DatosAdicionales");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "DatosAdicionales",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_DatosAdicionales_Cliente_ClienteId",
                table: "DatosAdicionales",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DatosAdicionales_Cliente_ClienteId",
                table: "DatosAdicionales");

            migrationBuilder.AlterColumn<int>(
                name: "ClienteId",
                table: "DatosAdicionales",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_DatosAdicionales_Cliente_ClienteId",
                table: "DatosAdicionales",
                column: "ClienteId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
