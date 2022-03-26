using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MySqlTestRazor.Migrations
{
    public partial class BeerResponsibleOfMatchDayTableIsNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateTime",
                table: "MatchDays",
                newName: "Date");

            migrationBuilder.AlterColumn<int>(
                name: "BeerResponsibleId",
                table: "MatchDays",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Date",
                table: "MatchDays",
                newName: "DateTime");

            migrationBuilder.AlterColumn<int>(
                name: "BeerResponsibleId",
                table: "MatchDays",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}
