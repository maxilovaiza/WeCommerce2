using Microsoft.EntityFrameworkCore.Migrations;

namespace WeCommerce.Migrations
{
    public partial class idusuario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdUsuario",
                table: "VentasDetalles",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdUsuario",
                table: "VentasDetalles");
        }
    }
}
