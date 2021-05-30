using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisRanking.Data.Migrations
{
    public partial class SeedMotivoBloqueio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "MotivosBloqueio",
                columns: new[] { "Id", "Motivo" },
                values: new object[] { 1, "Pendência Mensalidade" });

            migrationBuilder.InsertData(
                table: "MotivosBloqueio",
                columns: new[] { "Id", "Motivo" },
                values: new object[] { 2, "Pendência Multa" });

            migrationBuilder.InsertData(
                table: "MotivosBloqueio",
                columns: new[] { "Id", "Motivo" },
                values: new object[] { 3, "Decisão CCO" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MotivosBloqueio",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MotivosBloqueio",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MotivosBloqueio",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
