using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace InventoryControl.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class icontrol2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "Usuarios",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "Proveedores",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "Personas",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Habilitado",
                table: "Articulos",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "Gasto",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Descripcion = table.Column<string>(type: "text", nullable: true),
                    Valor = table.Column<string>(type: "text", nullable: true),
                    PersonaId = table.Column<int>(type: "integer", nullable: true),
                    EsConstante = table.Column<bool>(type: "boolean", nullable: false),
                    Habilitado = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gasto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Gasto_Personas_PersonaId",
                        column: x => x.PersonaId,
                        principalTable: "Personas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Gasto_PersonaId",
                table: "Gasto",
                column: "PersonaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Gasto");

            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "Proveedores");

            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Habilitado",
                table: "Articulos");
        }
    }
}
