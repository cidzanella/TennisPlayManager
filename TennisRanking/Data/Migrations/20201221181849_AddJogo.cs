using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisRanking.Data.Migrations
{
    public partial class AddJogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Jogos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JogoOriginalId = table.Column<int>(nullable: false),
                    TenistaAId = table.Column<int>(nullable: false),
                    TenistaBId = table.Column<int>(nullable: false),
                    AgendaId = table.Column<int>(nullable: false),
                    EhDesafio = table.Column<bool>(nullable: false),
                    DataConvite = table.Column<DateTime>(nullable: false),
                    DataRespostaConvite = table.Column<DateTime>(nullable: false),
                    ConviteAceito = table.Column<bool>(nullable: false),
                    TenistaVencedorId = table.Column<int>(nullable: false),
                    TenistaDesistenteId = table.Column<int>(nullable: false),
                    CancelamentoId = table.Column<int>(nullable: false),
                    PlacarId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jogos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Jogos");
        }
    }
}
