using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisRanking.Data.Migrations
{
    public partial class SeedHorarioHabilitadoDesafio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "HorariosHabilitadoDesafio",
                columns: new[] { "Id", "DiaSemana", "HorarioFinal", "HorarioInicial", "QuadraId" },
                values: new object[,]
                {
                    { 1, (byte)4, new DateTime(2020, 12, 27, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 27, 19, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 2, (byte)6, new DateTime(2020, 12, 27, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 27, 19, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 3, (byte)7, new DateTime(2020, 12, 27, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 27, 15, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 4, (byte)1, new DateTime(2020, 12, 27, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), 1 },
                    { 6, (byte)6, new DateTime(2020, 12, 27, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 27, 19, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, (byte)7, new DateTime(2020, 12, 27, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 27, 15, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, (byte)1, new DateTime(2020, 12, 27, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 9, (byte)4, new DateTime(2020, 12, 27, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 27, 19, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 10, (byte)6, new DateTime(2020, 12, 27, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 27, 19, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 11, (byte)7, new DateTime(2020, 12, 27, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 27, 15, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, (byte)1, new DateTime(2020, 12, 27, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2020, 12, 27, 9, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 12);
        }
    }
}
