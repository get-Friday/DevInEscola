using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Escola.Infra.Migrations
{
    public partial class DeleteBoletimRestrict : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOLETIM_ALUNO_AlunoId",
                table: "BOLETIM");

            migrationBuilder.AddForeignKey(
                name: "FK_BOLETIM_ALUNO_AlunoId",
                table: "BOLETIM",
                column: "AlunoId",
                principalTable: "ALUNO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BOLETIM_ALUNO_AlunoId",
                table: "BOLETIM");

            migrationBuilder.AddForeignKey(
                name: "FK_BOLETIM_ALUNO_AlunoId",
                table: "BOLETIM",
                column: "AlunoId",
                principalTable: "ALUNO",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
