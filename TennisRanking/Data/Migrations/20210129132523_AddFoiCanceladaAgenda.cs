using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisRanking.Data.Migrations
{
    public partial class AddFoiCanceladaAgenda : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "FoiCancelada",
                table: "Agendas",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 29, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 29, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 29, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 29, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 29, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 29, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 29, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 29, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 29, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 29, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 29, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 29, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 29, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 29, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 29, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 29, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_RankingTenistas_TenistaId",
                table: "RankingTenistas",
                column: "TenistaId");

            migrationBuilder.AddForeignKey(
                name: "FK_RankingTenistas_Tenistas_TenistaId",
                table: "RankingTenistas",
                column: "TenistaId",
                principalTable: "Tenistas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RankingTenistas_Tenistas_TenistaId",
                table: "RankingTenistas");

            migrationBuilder.DropIndex(
                name: "IX_RankingTenistas_TenistaId",
                table: "RankingTenistas");

            migrationBuilder.DropColumn(
                name: "FoiCancelada",
                table: "Agendas");

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 28, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 28, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 28, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 28, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 28, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 28, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 28, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 28, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 28, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 28, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 28, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 28, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 28, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 28, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 28, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 28, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 28, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 28, 9, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
