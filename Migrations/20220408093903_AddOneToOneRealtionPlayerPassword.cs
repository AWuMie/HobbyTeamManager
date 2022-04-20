using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HobbyTeamManager.Migrations
{
    public partial class AddOneToOneRealtionPlayerPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EmailAdressConfirmed",
                table: "Players",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "PlayerId",
                table: "Passwords",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Passwords_PlayerId",
                table: "Passwords",
                column: "PlayerId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Passwords_Players_PlayerId",
                table: "Passwords",
                column: "PlayerId",
                principalTable: "Players",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Passwords_Players_PlayerId",
                table: "Passwords");

            migrationBuilder.DropIndex(
                name: "IX_Passwords_PlayerId",
                table: "Passwords");

            migrationBuilder.DropColumn(
                name: "EmailAdressConfirmed",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "PlayerId",
                table: "Passwords");
        }
    }
}
