using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisRanking.Data.Migrations
{
    public partial class AddRegrasGerais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "RegrasGerais",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PosicoesAcima = table.Column<byte>(nullable: false),
                    MinimoDesafiosMes = table.Column<byte>(nullable: false),
                    MaximoDesafiosSemana = table.Column<byte>(nullable: false),
                    MaximoRecusas = table.Column<byte>(nullable: false),
                    MultaWO = table.Column<byte>(nullable: false),
                    PrazoHorasCancelamentoSemMulta = table.Column<byte>(nullable: false),
                    PrazoHorasRespostaDesafio = table.Column<byte>(nullable: false),
                    PrazoDiasRevanche = table.Column<byte>(nullable: false),
                    JogosNoAd = table.Column<bool>(nullable: false),
                    NumeroJogadoresTorneioFinalsMasculino = table.Column<byte>(nullable: false),
                    NumeroJogadoresTorneioFinalsFeminino = table.Column<byte>(nullable: false),
                    ToleranciaMinutosWO = table.Column<byte>(nullable: false),
                    AquecimentoMinutos = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegrasGerais", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RegrasGerais");
        }
    }
}
