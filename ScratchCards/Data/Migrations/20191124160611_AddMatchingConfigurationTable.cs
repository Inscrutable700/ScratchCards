using Microsoft.EntityFrameworkCore.Migrations;

namespace ScratchCards.Data.Migrations
{
    public partial class AddMatchingConfigurationTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MatchingConfigurations",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MatchingSignsCount = table.Column<int>(nullable: false),
                    Factor = table.Column<int>(nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchingConfigurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MatchingConfigurations_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchingConfigurations_GameId",
                table: "MatchingConfigurations",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchingConfigurations");
        }
    }
}
