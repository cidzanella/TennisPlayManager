using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisRanking.Data.Migrations
{
    public partial class MudouConviteAceitoParaRespostaConviteId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ConviteAceito",
                table: "Jogos");

            migrationBuilder.AddColumn<int>(
                name: "RespostaConviteId",
                table: "Jogos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RespostaConviteId",
                table: "Jogos");

            migrationBuilder.AddColumn<bool>(
                name: "ConviteAceito",
                table: "Jogos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
