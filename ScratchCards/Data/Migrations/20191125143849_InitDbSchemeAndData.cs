using Microsoft.EntityFrameworkCore.Migrations;

namespace ScratchCards.Data.Migrations
{
    public partial class InitDbSchemeAndData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    SignsNumberOnWheel = table.Column<int>(nullable: false),
                    SignsNumberOnScratchCard = table.Column<int>(nullable: false),
                    MaxNumberOfScratchCards = table.Column<int>(nullable: false),
                    ScratchCardSignsCanRepeat = table.Column<bool>(nullable: false),
                    UseJokerFeature = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                });

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

            migrationBuilder.CreateTable(
                name: "Signs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    ImageUrl = table.Column<string>(nullable: true),
                    Special = table.Column<bool>(nullable: false),
                    GameId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Signs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Signs_Games_GameId",
                        column: x => x.GameId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Games",
                columns: new[] { "Id", "MaxNumberOfScratchCards", "Name", "ScratchCardSignsCanRepeat", "SignsNumberOnScratchCard", "SignsNumberOnWheel", "UseJokerFeature" },
                values: new object[] { 1, 4, "ScratchCards", true, 4, 3, true });

            migrationBuilder.InsertData(
                table: "MatchingConfigurations",
                columns: new[] { "Id", "Factor", "GameId", "MatchingSignsCount" },
                values: new object[,]
                {
                    { 1, 3, 1, 1 },
                    { 2, 5, 1, 2 },
                    { 3, 9, 1, 3 },
                    { 4, 13, 1, 4 }
                });

            migrationBuilder.InsertData(
                table: "Signs",
                columns: new[] { "Id", "GameId", "ImageUrl", "Name", "Special" },
                values: new object[,]
                {
                    { 11, 1, null, "Sign 11", false },
                    { 10, 1, null, "Sign 10", false },
                    { 9, 1, null, "Sign 9", false },
                    { 8, 1, null, "Sign 8", false },
                    { 7, 1, null, "Sign 7", false },
                    { 5, 1, null, "Sign 5", false },
                    { 12, 1, null, "Sign 12", false },
                    { 4, 1, null, "Sign 4", false },
                    { 3, 1, null, "Sign 3", false },
                    { 2, 1, null, "Sign 2", false },
                    { 1, 1, null, "Sign 1", false },
                    { 6, 1, null, "Sign 6", false },
                    { 13, 1, null, "Joker", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MatchingConfigurations_GameId",
                table: "MatchingConfigurations",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_Signs_GameId",
                table: "Signs",
                column: "GameId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MatchingConfigurations");

            migrationBuilder.DropTable(
                name: "Signs");

            migrationBuilder.DropTable(
                name: "Games");
        }
    }
}
