using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisRanking.Data.Migrations
{
    public partial class SeedRegrasGerais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "RegrasGerais",
                columns: new[] { "Id", "AquecimentoMinutos", "JogosNoAd", "MaximoDesafiosSemana", "MaximoRecusas", "MinimoDesafiosMes", "MultaWO", "NumeroJogadoresTorneioFinalsFeminino", "NumeroJogadoresTorneioFinalsMasculino", "PosicoesAcima", "PrazoDiasRevanche", "PrazoHorasCancelamentoSemMulta", "PrazoHorasRespostaDesafio", "ToleranciaMinutosWO" },
                values: new object[] { 1, (byte)10, true, (byte)1, (byte)2, (byte)1, (byte)20, (byte)4, (byte)8, (byte)2, (byte)15, (byte)4, (byte)12, (byte)15 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "RegrasGerais",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
