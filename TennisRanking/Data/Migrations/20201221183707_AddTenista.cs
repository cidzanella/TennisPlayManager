using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisRanking.Data.Migrations
{
    public partial class AddTenista : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Tenistas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(nullable: false),
                    Sobrenome = table.Column<string>(nullable: false),
                    Nascimento = table.Column<DateTime>(nullable: false),
                    Sexo = table.Column<byte>(maxLength: 1, nullable: false),
                    AlturaCm = table.Column<byte>(nullable: false),
                    Empunhadura = table.Column<byte>(nullable: false),
                    Backhand = table.Column<byte>(nullable: false),
                    FotoFilePath = table.Column<string>(nullable: false),
                    Celular = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Senha = table.Column<string>(maxLength: 10, nullable: false),
                    Cidade = table.Column<byte>(nullable: false),
                    MotivoBloqueioId = table.Column<int>(nullable: false),
                    TipoTenista = table.Column<byte>(nullable: false),
                    JogaRanking = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenistas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tenistas");
        }
    }
}
