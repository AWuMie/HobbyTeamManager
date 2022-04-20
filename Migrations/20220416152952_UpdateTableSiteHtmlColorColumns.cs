using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HobbyTeamManager.Migrations
{
    public partial class UpdateTableSiteHtmlColorColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "BgColorBody",
                table: "Sites",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "BgColorFooter",
                table: "Sites",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "BgColorHeader",
                table: "Sites",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "BgColorMain",
                table: "Sites",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FgColorBody",
                table: "Sites",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FgColorFooter",
                table: "Sites",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FgColorHeader",
                table: "Sites",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "FgColorMain",
                table: "Sites",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BgColorBody",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "BgColorFooter",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "BgColorHeader",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "BgColorMain",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "FgColorBody",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "FgColorFooter",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "FgColorHeader",
                table: "Sites");

            migrationBuilder.DropColumn(
                name: "FgColorMain",
                table: "Sites");
        }
    }
}
