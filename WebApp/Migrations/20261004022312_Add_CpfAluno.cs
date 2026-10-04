using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EscolaDeCursos.WebApp.Migrations
{
    /// <inheritdoc />
    public partial class Add_CpfAluno : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "TBAlunos",
                type: "nvarchar(14)",
                maxLength: 14,
                nullable: false,
                defaultValue: "");

            // Alunos já existentes recebem um valor provisório único (final do Id)
            // para não violar o índice único; o CPF real deve ser informado na edição
            migrationBuilder.Sql(
                "UPDATE TBAlunos SET Cpf = RIGHT(REPLACE(CONVERT(nvarchar(36), Id), '-', ''), 14) WHERE Cpf = ''"
            );

            migrationBuilder.CreateIndex(
                name: "IX_TBAlunos_Cpf",
                table: "TBAlunos",
                column: "Cpf",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_TBAlunos_Cpf",
                table: "TBAlunos");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "TBAlunos");
        }
    }
}
