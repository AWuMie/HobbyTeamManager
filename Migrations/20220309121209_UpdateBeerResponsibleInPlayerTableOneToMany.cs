using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySqlTestRazor.Migrations
{
    public partial class UpdateBeerResponsibleInPlayerTableOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "TeamColorId",
                table: "Teams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MatchDayIdForTeamWhite",
                table: "Teams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "MatchDayIdForTeamRed",
                table: "Teams",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "SeasonId",
                table: "MatchDays",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "BeerResponsibleId",
                table: "MatchDays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MatchDays_BeerResponsibleId",
                table: "MatchDays",
                column: "BeerResponsibleId");

            migrationBuilder.AddForeignKey(
                name: "FK_MatchDays_Players_BeerResponsibleId",
                table: "MatchDays",
                column: "BeerResponsibleId",
                principalTable: "Players",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MatchDays_Players_BeerResponsibleId",
                table: "MatchDays");

            migrationBuilder.DropIndex(
                name: "IX_MatchDays_BeerResponsibleId",
                table: "MatchDays");

            migrationBuilder.DropColumn(
                name: "BeerResponsibleId",
                table: "MatchDays");

            migrationBuilder.AlterColumn<int>(
                name: "TeamColorId",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MatchDayIdForTeamWhite",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MatchDayIdForTeamRed",
                table: "Teams",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MatchDayId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "SeasonId",
                table: "MatchDays",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
