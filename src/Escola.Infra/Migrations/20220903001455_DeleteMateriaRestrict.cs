using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escola.Infra.Migrations
{
    public partial class DeleteMateriaRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NOTAS_MATERIA_MATERIA_MateriaId",
                table: "NOTAS_MATERIA");

            migrationBuilder.AddForeignKey(
                name: "FK_NOTAS_MATERIA_MATERIA_MateriaId",
                table: "NOTAS_MATERIA",
                column: "MateriaId",
                principalTable: "MATERIA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_NOTAS_MATERIA_MATERIA_MateriaId",
                table: "NOTAS_MATERIA");

            migrationBuilder.AddForeignKey(
                name: "FK_NOTAS_MATERIA_MATERIA_MateriaId",
                table: "NOTAS_MATERIA",
                column: "MateriaId",
                principalTable: "MATERIA",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
