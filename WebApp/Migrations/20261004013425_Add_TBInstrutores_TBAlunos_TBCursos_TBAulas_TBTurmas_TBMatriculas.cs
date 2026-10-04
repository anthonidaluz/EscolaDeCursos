using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDeCursos.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Add_TBInstrutores_TBAlunos_TBCursos_TBAulas_TBTurmas_TBMatriculas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TBAlunos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    NumeroMatricula = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAlunos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBCursos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Nivel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CargaHoraria = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBCursos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBInstrutores",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Cpf = table.Column<string>(type: "nvarchar(14)", maxLength: 14, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBInstrutores", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TBAulas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DuracaoEmMinutos = table.Column<int>(type: "int", nullable: false),
                    Ordem = table.Column<int>(type: "int", nullable: false),
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBAulas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBAulas_TBCurso",
                        column: x => x.CursoId,
                        principalTable: "TBCursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBTurmas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CursoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InstrutorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NumeroMaximoAlunos = table.Column<int>(type: "int", nullable: false),
                    DataInicio = table.Column<DateOnly>(type: "date", nullable: false),
                    DataTermino = table.Column<DateOnly>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBTurmas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBTurmas_TBCursos",
                        column: x => x.CursoId,
                        principalTable: "TBCursos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBTurmas_TBInstrutores",
                        column: x => x.InstrutorId,
                        principalTable: "TBInstrutores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TBMatriculas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AlunoId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TurmaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TBMatriculas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TBMatriculas_TBAlunos",
                        column: x => x.AlunoId,
                        principalTable: "TBAlunos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TBMatriculas_TBTurmas",
                        column: x => x.TurmaId,
                        principalTable: "TBTurmas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TBAlunos_NumeroMatricula",
                table: "TBAlunos",
                column: "NumeroMatricula",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBAulas_CursoId_Nome",
                table: "TBAulas",
                columns: new[] { "CursoId", "Nome" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBAulas_CursoId_Ordem",
                table: "TBAulas",
                columns: new[] { "CursoId", "Ordem" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBInstrutores_Cpf",
                table: "TBInstrutores",
                column: "Cpf",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBInstrutores_Telefone",
                table: "TBInstrutores",
                column: "Telefone",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBMatriculas_AlunoId",
                table: "TBMatriculas",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBMatriculas_TurmaId_AlunoId",
                table: "TBMatriculas",
                columns: new[] { "TurmaId", "AlunoId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TBTurmas_CursoId",
                table: "TBTurmas",
                column: "CursoId");

            migrationBuilder.CreateIndex(
                name: "IX_TBTurmas_InstrutorId",
                table: "TBTurmas",
                column: "InstrutorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TBAulas");

            migrationBuilder.DropTable(
                name: "TBMatriculas");

            migrationBuilder.DropTable(
                name: "TBAlunos");

            migrationBuilder.DropTable(
                name: "TBTurmas");

            migrationBuilder.DropTable(
                name: "TBCursos");

            migrationBuilder.DropTable(
                name: "TBInstrutores");
        }
    }
}
