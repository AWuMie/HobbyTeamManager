using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HobbyTeamManager.Migrations
{
    public partial class AddMatchDaysToSeasonTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "MatchDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MatchDays_SeasonId",
                table: "MatchDays",
                column: "SeasonId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchDays_Seasons_SeasonId",
                table: "MatchDays",
                column: "SeasonId",
                principalTable: "Seasons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchDays_Seasons_SeasonId",
                table: "MatchDays");

            migrationBuilder.DropIndex(
                name: "IX_MatchDays_SeasonId",
                table: "MatchDays");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "MatchDays");
        }
    }
}
