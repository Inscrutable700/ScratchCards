using Microsoft.EntityFrameworkCore.Migrations;

namespace ScratchCards.Data.Migrations
{
    public partial class AddGameTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Signs",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Game",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    SignsNumberOnWheel = table.Column<int>(nullable: false),
                    SignsNumberOnScratchCard = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Game", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Signs_GameId",
                table: "Signs",
                column: "GameId");

            migrationBuilder.AddForeignKey(
                name: "FK_Signs_Game_GameId",
                table: "Signs",
                column: "GameId",
                principalTable: "Game",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Signs_Game_GameId",
                table: "Signs");

            migrationBuilder.DropTable(
                name: "Game");

            migrationBuilder.DropIndex(
                name: "IX_Signs_GameId",
                table: "Signs");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Signs");
        }
    }
}
