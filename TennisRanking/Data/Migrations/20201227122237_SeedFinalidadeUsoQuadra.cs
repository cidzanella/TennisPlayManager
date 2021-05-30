using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisRanking.Data.Migrations
{
    public partial class SeedFinalidadeUsoQuadra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "FinalidadeUsoQuadras",
                columns: new[] { "Id", "Finalidade", "TempoReservaEmMinutos" },
                values: new object[,]
                {
                    { (byte)1, "Aula", 30 },
                    { (byte)2, "Ranking", 120 },
                    { (byte)3, "Amistoso", 60 },
                    { (byte)4, "Ranking, Amistoso", 0 },
                    { (byte)5, "Todas", 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "FinalidadeUsoQuadras",
                keyColumn: "Id",
                keyValue: (byte)1);

            migrationBuilder.DeleteData(
                table: "FinalidadeUsoQuadras",
                keyColumn: "Id",
                keyValue: (byte)2);

            migrationBuilder.DeleteData(
                table: "FinalidadeUsoQuadras",
                keyColumn: "Id",
                keyValue: (byte)3);

            migrationBuilder.DeleteData(
                table: "FinalidadeUsoQuadras",
                keyColumn: "Id",
                keyValue: (byte)4);

            migrationBuilder.DeleteData(
                table: "FinalidadeUsoQuadras",
                keyColumn: "Id",
                keyValue: (byte)5);
        }
    }
}
