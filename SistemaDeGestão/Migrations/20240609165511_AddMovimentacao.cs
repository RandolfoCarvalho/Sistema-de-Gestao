using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaDeGestão.Migrations
{
    /// <inheritdoc />
    public partial class AddMovimentacao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Movimentacaos",
                table: "Movimentacaos");

            migrationBuilder.RenameTable(
                name: "Movimentacaos",
                newName: "Movimentacoes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movimentacoes",
                table: "Movimentacoes",
                column: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Movimentacoes",
                table: "Movimentacoes");

            migrationBuilder.RenameTable(
                name: "Movimentacoes",
                newName: "Movimentacaos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Movimentacaos",
                table: "Movimentacaos",
                column: "Id");
        }
    }
}
