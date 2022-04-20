using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HobbyTeamManager.Migrations
{
    public partial class AddTeamTable2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Team_TeamColors_TeamColorId",
                table: "Team");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Team",
                table: "Team");

            migrationBuilder.RenameTable(
                name: "Team",
                newName: "Teams");

            migrationBuilder.RenameIndex(
                name: "IX_Team_TeamColorId",
                table: "Teams",
                newName: "IX_Teams_TeamColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teams",
                table: "Teams",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_TeamColors_TeamColorId",
                table: "Teams",
                column: "TeamColorId",
                principalTable: "TeamColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_TeamColors_TeamColorId",
                table: "Teams");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teams",
                table: "Teams");

            migrationBuilder.RenameTable(
                name: "Teams",
                newName: "Team");

            migrationBuilder.RenameIndex(
                name: "IX_Teams_TeamColorId",
                table: "Team",
                newName: "IX_Team_TeamColorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Team",
                table: "Team",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Team_TeamColors_TeamColorId",
                table: "Team",
                column: "TeamColorId",
                principalTable: "TeamColors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
