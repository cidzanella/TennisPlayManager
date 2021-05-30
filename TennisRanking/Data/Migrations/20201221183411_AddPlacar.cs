        using Microsoft.EntityFrameworkCore.Migrations;

namespace TennisRanking.Data.Migrations
{
    public partial class AddPlacar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Placares",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Set = table.Column<byte>(nullable: false),
                    GamesTenistaA = table.Column<byte>(nullable: false),
                    GamesTenistaB = table.Column<byte>(nullable: false),
                    TieBreakTenistaA = table.Column<byte>(nullable: false),
                    TieBreakTenistaB = table.Column<byte>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placares", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Placares");
        }
    }
}
