using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HobbyTeamManager.Migrations
{
    public partial class AddRelationshipOneToManySeasonToSite : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SeasonId",
                table: "Sites",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SiteId",
                table: "Seasons",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Seasons_SiteId",
                table: "Seasons",
                column: "SiteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Seasons_Sites_SiteId",
                table: "Seasons",
                column: "SiteId",
                principalTable: "Sites",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seasons_Sites_SiteId",
                table: "Seasons");

            migrationBuilder.DropIndex(
                name: "IX_Seasons_SiteId",
                table: "Seasons");

            migrationBuilder.DropColumn(
                name: "SeasonId",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "SiteId",
                table: "Seasons");
        }
    }
}
