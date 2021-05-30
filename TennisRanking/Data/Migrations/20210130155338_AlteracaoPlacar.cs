using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisRanking.Data.Migrations
{
    public partial class AlteracaoPlacar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GamesTenistaA",
                table: "Placares");

            migrationBuilder.DropColumn(
                name: "GamesTenistaB",
                table: "Placares");

            migrationBuilder.DropColumn(
                name: "Set",
                table: "Placares");

            migrationBuilder.DropColumn(
                name: "TieBreakTenistaA",
                table: "Placares");

            migrationBuilder.DropColumn(
                name: "TieBreakTenistaB",
                table: "Placares");

            migrationBuilder.AddColumn<byte>(
                name: "Set1GamesTenistaA",
                table: "Placares",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Set1GamesTenistaB",
                table: "Placares",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Set1TieBreakTenistaA",
                table: "Placares",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Set1TieBreakTenistaB",
                table: "Placares",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Set2GamesTenistaA",
                table: "Placares",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Set2GamesTenistaB",
                table: "Placares",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Set2TieBreakTenistaA",
                table: "Placares",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Set2TieBreakTenistaB",
                table: "Placares",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Set3GamesTenistaA",
                table: "Placares",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Set3GamesTenistaB",
                table: "Placares",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Set3TieBreakTenistaA",
                table: "Placares",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Set3TieBreakTenistaB",
                table: "Placares",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 30, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 30, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 30, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 30, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 30, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 30, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 30, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 30, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 30, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 30, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 30, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 30, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 30, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 30, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 30, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 30, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 30, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 30, 9, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Set1GamesTenistaA",
                table: "Placares");

            migrationBuilder.DropColumn(
                name: "Set1GamesTenistaB",
                table: "Placares");

            migrationBuilder.DropColumn(
                name: "Set1TieBreakTenistaA",
                table: "Placares");

            migrationBuilder.DropColumn(
                name: "Set1TieBreakTenistaB",
                table: "Placares");

            migrationBuilder.DropColumn(
                name: "Set2GamesTenistaA",
                table: "Placares");

            migrationBuilder.DropColumn(
                name: "Set2GamesTenistaB",
                table: "Placares");

            migrationBuilder.DropColumn(
                name: "Set2TieBreakTenistaA",
                table: "Placares");

            migrationBuilder.DropColumn(
                name: "Set2TieBreakTenistaB",
                table: "Placares");

            migrationBuilder.DropColumn(
                name: "Set3GamesTenistaA",
                table: "Placares");

            migrationBuilder.DropColumn(
                name: "Set3GamesTenistaB",
                table: "Placares");

            migrationBuilder.DropColumn(
                name: "Set3TieBreakTenistaA",
                table: "Placares");

            migrationBuilder.DropColumn(
                name: "Set3TieBreakTenistaB",
                table: "Placares");

            migrationBuilder.AddColumn<byte>(
                name: "GamesTenistaA",
                table: "Placares",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "GamesTenistaB",
                table: "Placares",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "Set",
                table: "Placares",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "TieBreakTenistaA",
                table: "Placares",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "TieBreakTenistaB",
                table: "Placares",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

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
        }
    }
}
