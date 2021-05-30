using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisRanking.Data.Migrations
{
    public partial class AddTokenConfirmacaoJogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TokenConfirmacao",
                table: "Jogos",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 27, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 27, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 27, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 27, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 27, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 27, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 27, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 27, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 27, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 27, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 27, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 27, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 27, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 27, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 27, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 27, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 27, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 27, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 27, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 27, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_Jogos_AgendaId",
                table: "Jogos",
                column: "AgendaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Jogos_Agendas_AgendaId",
                table: "Jogos",
                column: "AgendaId",
                principalTable: "Agendas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Jogos_Agendas_AgendaId",
                table: "Jogos");

            migrationBuilder.DropIndex(
                name: "IX_Jogos_AgendaId",
                table: "Jogos");

            migrationBuilder.DropColumn(
                name: "TokenConfirmacao",
                table: "Jogos");

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 23, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 23, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 23, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 23, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 23, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 23, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 23, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 23, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 23, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 23, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 23, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 23, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 23, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 23, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 11,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 23, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 23, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 12,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 1, 23, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 1, 23, 9, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
