using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySqlTestRazor.Migrations
{
    public partial class AddBeerResponsibleToMatchDayTableAndPlayerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatchDayId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Players_MatchDayId",
                table: "Players",
                column: "MatchDayId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_MatchDays_MatchDayId",
                table: "Players",
                column: "MatchDayId",
                principalTable: "MatchDays",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_MatchDays_MatchDayId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_MatchDayId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "MatchDayId",
                table: "Players");
        }
    }
}
