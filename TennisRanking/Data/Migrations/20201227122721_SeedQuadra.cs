using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisRanking.Data.Migrations
{
    public partial class SeedQuadra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Quadras",
                columns: new[] { "Id", "FinalidadeUsoQuadraId", "Nome" },
                values: new object[] { 1, 1, "Quadra #1" });

            migrationBuilder.InsertData(
                table: "Quadras",
                columns: new[] { "Id", "FinalidadeUsoQuadraId", "Nome" },
                values: new object[] { 2, 2, "Quadra #2" });

            migrationBuilder.InsertData(
                table: "Quadras",
                columns: new[] { "Id", "FinalidadeUsoQuadraId", "Nome" },
                values: new object[] { 3, 3, "Quadra #3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Quadras",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Quadras",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Quadras",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
