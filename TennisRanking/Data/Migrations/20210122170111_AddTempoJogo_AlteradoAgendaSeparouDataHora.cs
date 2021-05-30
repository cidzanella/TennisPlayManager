using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisRanking.Data.Migrations
{
    public partial class AddTempoJogo_AlteradoAgendaSeparouDataHora : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataFinal",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "DataInicial",
                table: "Agendas");

            migrationBuilder.AddColumn<byte>(
                name: "TempoJogoMinutos",
                table: "HorariosHabilitadoDesafio",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<DateTime>(
                name: "Data",
                table: "Agendas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "HoraFinal",
                table: "Agendas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "HoraInicial",
                table: "Agendas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 22, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 22, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 22, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 22, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 22, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 22, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 22, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 22, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 22, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 22, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 22, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 22, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 22, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 22, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 22, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 22, 9, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TempoJogoMinutos",
                table: "HorariosHabilitadoDesafio");

            migrationBuilder.DropColumn(
                name: "Data",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "HoraFinal",
                table: "Agendas");

            migrationBuilder.DropColumn(
                name: "HoraInicial",
                table: "Agendas");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataFinal",
                table: "Agendas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataInicial",
                table: "Agendas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 21, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 21, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 21, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 21, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 21, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 21, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 21, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 21, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 21, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 21, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 21, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 21, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 21, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 21, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 21, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 21, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 21, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 21, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 21, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 21, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 21, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 21, 9, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
