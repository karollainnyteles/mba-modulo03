using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TelesEducacao.Alunos.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAulasConcluidas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AulasConcluidas",
                columns: table => new
                {
                    MatriculaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AulaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DataCadastro = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AulasConcluidas", x => new { x.AulaId, x.MatriculaId });
                    table.ForeignKey(
                        name: "FK_AulasConcluidas_Matriculas_MatriculaId",
                        column: x => x.MatriculaId,
                        principalTable: "Matriculas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AulasConcluidas_MatriculaId",
                table: "AulasConcluidas",
                column: "MatriculaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AulasConcluidas");
        }
    }
}
