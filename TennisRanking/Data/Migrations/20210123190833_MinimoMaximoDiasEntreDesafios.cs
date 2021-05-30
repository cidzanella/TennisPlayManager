using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisRanking.Data.Migrations
{
    public partial class MinimoMaximoDiasEntreDesafios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaximoDesafiosSemana",
                table: "RegrasGerais");

            migrationBuilder.DropColumn(
                name: "MinimoDesafiosMes",
                table: "RegrasGerais");

            migrationBuilder.DropColumn(
                name: "PrazoDiasRevanche",
                table: "RegrasGerais");

            migrationBuilder.AddColumn<byte>(
                name: "MaximoDiasEntreDesafios",
                table: "RegrasGerais",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "MinimoDiasEntreDesafios",
                table: "RegrasGerais",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "MinimoDiasParaRevanche",
                table: "RegrasGerais",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "RegrasGerais",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MaximoDiasEntreDesafios", "MinimoDiasEntreDesafios", "MinimoDiasParaRevanche" },
                values: new object[] { (byte)30, (byte)7, (byte)15 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaximoDiasEntreDesafios",
                table: "RegrasGerais");

            migrationBuilder.DropColumn(
                name: "MinimoDiasEntreDesafios",
                table: "RegrasGerais");

            migrationBuilder.DropColumn(
                name: "MinimoDiasParaRevanche",
                table: "RegrasGerais");

            migrationBuilder.AddColumn<byte>(
                name: "MaximoDesafiosSemana",
                table: "RegrasGerais",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "MinimoDesafiosMes",
                table: "RegrasGerais",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "PrazoDiasRevanche",
                table: "RegrasGerais",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "RegrasGerais",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "MaximoDesafiosSemana", "MinimoDesafiosMes", "PrazoDiasRevanche" },
                values: new object[] { (byte)1, (byte)1, (byte)15 });
        }
    }
}
