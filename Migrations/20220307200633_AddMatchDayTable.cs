using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySqlTestRazor.Migrations
{
    public partial class AddMatchDayTable : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "MatchDayId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MatchDay",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    DateTime = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MatchDay", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

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

            migrationBuilder.CreateIndex(
                name: "IX_Players_MatchDayId",
                table: "Players",
                column: "MatchDayId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Players_MatchDay_MatchDayId",
                table: "Players",
                column: "MatchDayId",
                principalTable: "MatchDay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_MatchDay_MatchDayIdForTeamRed",
                table: "Teams",
                column: "MatchDayIdForTeamRed",
                principalTable: "MatchDay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_MatchDay_MatchDayIdForTeamWhite",
                table: "Teams",
                column: "MatchDayIdForTeamWhite",
                principalTable: "MatchDay",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_MatchDay_MatchDayId",
                table: "Players");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_MatchDay_MatchDayIdForTeamRed",
                table: "Teams");

            migrationBuilder.DropForeignKey(
                name: "FK_Teams_MatchDay_MatchDayIdForTeamWhite",
                table: "Teams");

            migrationBuilder.DropTable(
                name: "MatchDay");

            migrationBuilder.DropIndex(
                name: "IX_Teams_MatchDayIdForTeamRed",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_MatchDayIdForTeamWhite",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Players_MatchDayId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "MatchDayIdForTeamRed",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "MatchDayIdForTeamWhite",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "MatchDayId",
                table: "Players");
        }
    }
}
