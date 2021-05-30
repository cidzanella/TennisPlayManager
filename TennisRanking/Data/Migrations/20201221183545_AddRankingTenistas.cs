using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisRanking.Data.Migrations
{
    public partial class AddRankingTenistas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RankingTenistas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Posicao = table.Column<byte>(nullable: false),
                    TenistaId = table.Column<int>(nullable: false),
                    DataPosicaoAtual = table.Column<DateTime>(nullable: false),
                    PosicaoAnterior = table.Column<byte>(nullable: false),
                    DataPosicaoAnterior = table.Column<DateTime>(nullable: false),
                    PosicaoInicial = table.Column<byte>(nullable: false),
                    DataPosicaoInicial = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RankingTenistas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RankingTenistas");
        }
    }
}
