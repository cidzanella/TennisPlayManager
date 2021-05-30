using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisRanking.Data.Migrations
{
    public partial class RenameCidade_CidadeId_emTenista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cidade",
                table: "Tenistas");

            migrationBuilder.AddColumn<int>(
                name: "CidadeId",
                table: "Tenistas",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CidadeId",
                table: "Tenistas");

            migrationBuilder.AddColumn<int>(
                name: "Cidade",
                table: "Tenistas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
