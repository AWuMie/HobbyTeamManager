using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySqlTestRazor.Migrations
{
    public partial class AddScoreFromPlayerToPlayerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ScoreFromPlayerId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Players_ScoreFromPlayerId",
                table: "Players",
                column: "ScoreFromPlayerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_Players_ScoreFromPlayerId",
                table: "Players",
                column: "ScoreFromPlayerId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_Players_ScoreFromPlayerId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_ScoreFromPlayerId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "ScoreFromPlayerId",
                table: "Players");
        }
    }
}
