using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escola.Infra.Migrations
{
    public partial class AddRemainingEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Matricula",
                table: "ALUNO",
                newName: "MATRICULA");

            migrationBuilder.AlterColumn<string>(
                name: "SOBRENOME",
                table: "ALUNO",
                type: "VARCHAR(150)",
                maxLength: 150,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)",
                oldMaxLength: 150);

            migrationBuilder.AlterColumn<string>(
                name: "NOME",
                table: "ALUNO",
                type: "VARCHAR(80)",
                maxLength: 80,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(80)",
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "ALUNO",
                type: "VARCHAR(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(200)",
                oldMaxLength: 200);

            migrationBuilder.CreateTable(
                name: "BOLETIM",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlunoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BoletimID", x => x.ID);
                    table.ForeignKey(
                        name: "FK_BOLETIM_ALUNO_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "ALUNO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MATERIA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "VARCHAR", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MateriaID", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "NOTAS_MATERIA",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    BoletimId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    MateriaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOTA = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotasMateriaID", x => x.ID);
                    table.ForeignKey(
                        name: "FK_NOTAS_MATERIA_BOLETIM_BoletimId",
                        column: x => x.BoletimId,
                        principalTable: "BOLETIM",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_NOTAS_MATERIA_MATERIA_MateriaId",
                        column: x => x.MateriaId,
                        principalTable: "MATERIA",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ALUNO_MATRICULA",
                table: "ALUNO",
                column: "MATRICULA",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BOLETIM_AlunoId",
                table: "BOLETIM",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTAS_MATERIA_BoletimId",
                table: "NOTAS_MATERIA",
                column: "BoletimId");

            migrationBuilder.CreateIndex(
                name: "IX_NOTAS_MATERIA_MateriaId",
                table: "NOTAS_MATERIA",
                column: "MateriaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NOTAS_MATERIA");

            migrationBuilder.DropTable(
                name: "BOLETIM");

            migrationBuilder.DropTable(
                name: "MATERIA");

            migrationBuilder.DropIndex(
                name: "IX_ALUNO_MATRICULA",
                table: "ALUNO");

            migrationBuilder.RenameColumn(
                name: "MATRICULA",
                table: "ALUNO",
                newName: "Matricula");

            migrationBuilder.AlterColumn<string>(
                name: "SOBRENOME",
                table: "ALUNO",
                type: "VARCHAR(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(150)",
                oldMaxLength: 150,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "NOME",
                table: "ALUNO",
                type: "VARCHAR(80)",
                maxLength: 80,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(80)",
                oldMaxLength: 80,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EMAIL",
                table: "ALUNO",
                type: "VARCHAR(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "VARCHAR(200)",
                oldMaxLength: 200,
                oldNullable: true);
        }
    }
}
