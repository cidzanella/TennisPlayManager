using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisRanking.Data.Migrations
{
    public partial class AddRegrasAgendaAmistoso : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DropColumn(
                name: "PrazoHorasCancelamentoSemMulta",
                table: "RegrasGerais");

            migrationBuilder.AddColumn<byte>(
                name: "PrazoMinutosCancelamentoSemMulta",
                table: "RegrasGerais",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "PrazoMinutosReagendamentoSemWO",
                table: "RegrasGerais",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.CreateTable(
                name: "HorariosHabilitadoAmistoso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DiaSemana = table.Column<byte>(nullable: false),
                    HorarioInicial = table.Column<DateTime>(nullable: false),
                    HorarioFinal = table.Column<DateTime>(nullable: false),
                    QuadraId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HorariosHabilitadoAmistoso", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RegrasAgendaAmistoso",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MinimoDiasEntreAmistosos = table.Column<byte>(nullable: false),
                    AntecedenciaMaximaDias = table.Column<byte>(nullable: false),
                    PrazoMinutosCancelamentoSemMulta = table.Column<byte>(nullable: false),
                    PrazoMinutosReagendamentoSemWO = table.Column<byte>(nullable: false),
                    MultaWO = table.Column<byte>(nullable: false),
                    HorarioLiberarAgendamento = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RegrasAgendaAmistoso", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 2, 2, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 2, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 2, 2, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 2, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 2, 2, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 2, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 2, 2, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 2, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 2, 2, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 2, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 2, 2, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 2, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "RegrasAgendaAmistoso",
                columns: new[] { "Id", "AntecedenciaMaximaDias", "HorarioLiberarAgendamento", "MinimoDiasEntreAmistosos", "MultaWO", "PrazoMinutosCancelamentoSemMulta", "PrazoMinutosReagendamentoSemWO" },
                values: new object[] { 1, (byte)2, new DateTime(2021, 2, 2, 13, 0, 0, 0, DateTimeKind.Unspecified), (byte)2, (byte)20, (byte)60, (byte)60 });

            migrationBuilder.UpdateData(
                table: "RegrasGerais",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PrazoHorasRespostaDesafio", "PrazoMinutosCancelamentoSemMulta", "PrazoMinutosReagendamentoSemWO" },
                values: new object[] { (byte)24, (byte)60, (byte)60 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HorariosHabilitadoAmistoso");

            migrationBuilder.DropTable(
                name: "RegrasAgendaAmistoso");

            migrationBuilder.DropColumn(
                name: "PrazoMinutosCancelamentoSemMulta",
                table: "RegrasGerais");

            migrationBuilder.DropColumn(
                name: "PrazoMinutosReagendamentoSemWO",
                table: "RegrasGerais");

            migrationBuilder.AddColumn<byte>(
                name: "PrazoHorasCancelamentoSemMulta",
                table: "RegrasGerais",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 2, 1, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 1, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 2, 1, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 1, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 2, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 1, 15, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 2, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 1, 9, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 2, 1, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 1, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "HorariosHabilitadoDesafio",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "HorarioFinal", "HorarioInicial" },
                values: new object[] { new DateTime(2021, 2, 1, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 1, 19, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "HorariosHabilitadoDesafio",
                columns: new[] { "Id", "DiaSemana", "HorarioFinal", "HorarioInicial", "QuadraId" },
                values: new object[,]
                {
                    { 6, (byte)6, new DateTime(2021, 2, 1, 22, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 1, 19, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 7, (byte)7, new DateTime(2021, 2, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 8, (byte)1, new DateTime(2021, 2, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 11, (byte)7, new DateTime(2021, 2, 1, 20, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 1, 15, 0, 0, 0, DateTimeKind.Unspecified), 3 },
                    { 12, (byte)1, new DateTime(2021, 2, 1, 12, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2021, 2, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), 3 }
                });

            migrationBuilder.UpdateData(
                table: "RegrasGerais",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "PrazoHorasCancelamentoSemMulta", "PrazoHorasRespostaDesafio" },
                values: new object[] { (byte)4, (byte)12 });
        }
    }
}
