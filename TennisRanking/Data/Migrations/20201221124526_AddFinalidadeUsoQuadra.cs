using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisRanking.Data.Migrations
{
    public partial class AddFinalidadeUsoQuadra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FinalidadeUsoQuadras",
                columns: table => new
                {
                    Id = table.Column<byte>(nullable: false),
                    Finalidade = table.Column<string>(nullable: false),
                    TempoReservaEmMinutos = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinalidadeUsoQuadras", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FinalidadeUsoQuadras");
        }
    }
}
