using Microsoft.EntityFrameworkCore.Migrations;

namespace ScratchCards.Data.Migrations
{
    public partial class InitialData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "MatchingConfigurations",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MatchingConfigurations",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MatchingConfigurations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "MatchingConfigurations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Signs",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Signs",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Signs",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Signs",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Signs",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Signs",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Signs",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Signs",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Signs",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Signs",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Signs",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Signs",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Signs",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Games",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
