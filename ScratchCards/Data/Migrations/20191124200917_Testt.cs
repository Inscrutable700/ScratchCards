using Microsoft.EntityFrameworkCore.Migrations;

namespace ScratchCards.Data.Migrations
{
    public partial class Testt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Special",
                table: "Signs",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "MaxNumberOfScratchCards",
                table: "Games",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "ScratchCardSignsCanRepeat",
                table: "Games",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "UseJokerFeature",
                table: "Games",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Special",
                table: "Signs");

            migrationBuilder.DropColumn(
                name: "MaxNumberOfScratchCards",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "ScratchCardSignsCanRepeat",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "UseJokerFeature",
                table: "Games");
        }
    }
}
