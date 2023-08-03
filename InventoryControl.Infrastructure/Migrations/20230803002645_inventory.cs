using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InventoryControl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class inventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Rol",
                table: "Usuarios",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<long>(
                name: "CajaId",
                table: "Facturas",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Facturas_CajaId",
                table: "Facturas",
                column: "CajaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Facturas_Cajas_CajaId",
                table: "Facturas",
                column: "CajaId",
                principalTable: "Cajas",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Facturas_Cajas_CajaId",
                table: "Facturas");

            migrationBuilder.DropIndex(
                name: "IX_Facturas_CajaId",
                table: "Facturas");

            migrationBuilder.DropColumn(
                name: "Rol",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "CajaId",
                table: "Facturas");
        }
    }
}
