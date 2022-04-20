using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HobbyTeamManager.Migrations
{
    public partial class AddTeamRedAndWhiteToMatchDayTableAndTeamTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatchDayIdForTeamRed",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MatchDayIdForTeamWhite",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_MatchDayIdForTeamRed",
                table: "Teams",
                column: "MatchDayIdForTeamRed",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_MatchDayIdForTeamWhite",
                table: "Teams",
                column: "MatchDayIdForTeamWhite",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_MatchDays_MatchDayIdForTeamRed",
                table: "Teams",
                column: "MatchDayIdForTeamRed",
                principalTable: "MatchDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_MatchDays_MatchDayIdForTeamWhite",
                table: "Teams",
                column: "MatchDayIdForTeamWhite",
                principalTable: "MatchDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_MatchDays_MatchDayIdForTeamRed",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_MatchDays_MatchDayIdForTeamWhite",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_MatchDayIdForTeamRed",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_MatchDayIdForTeamWhite",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "MatchDayIdForTeamRed",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "MatchDayIdForTeamWhite",
                table: "Teams");
        }
    }
}
