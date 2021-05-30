using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisRanking.Data.Migrations
{
    public partial class SeedMotivoCancelamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MotivosCancelamento",
                columns: new[] { "Id", "Motivo" },
                values: new object[,]
                {
                    { 1, "Chuva" },
                    { 2, "Manutenção" },
                    { 3, "Falta de luz" },
                    { 4, "Solicitação do desafiado" },
                    { 5, "Solicitação do desafiante" },
                    { 6, "Reagendado" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MotivosCancelamento",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MotivosCancelamento",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MotivosCancelamento",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MotivosCancelamento",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "MotivosCancelamento",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "MotivosCancelamento",
                keyColumn: "Id",
                keyValue: 6);
        }
    }
}
