using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySqlTestRazor.Migrations
{
    public partial class AddMembershipTypeToPlayerTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MembershipTypeId",
                table: "Players",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Players_MembershipTypeId",
                table: "Players",
                column: "MembershipTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Players_MembershipTypes_MembershipTypeId",
                table: "Players",
                column: "MembershipTypeId",
                principalTable: "MembershipTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Players_MembershipTypes_MembershipTypeId",
                table: "Players");

            migrationBuilder.DropIndex(
                name: "IX_Players_MembershipTypeId",
                table: "Players");

            migrationBuilder.DropColumn(
                name: "MembershipTypeId",
                table: "Players");
        }
    }
}
