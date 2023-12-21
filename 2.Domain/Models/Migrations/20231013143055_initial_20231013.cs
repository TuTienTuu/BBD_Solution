using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initial_20231013 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Soles",
                newName: "Soles",
                newSchema: "Paper");

            migrationBuilder.AlterColumn<string>(
                name: "SoleInfomation",
                schema: "Paper",
                table: "Soles",
                type: "NVARCHAR(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SoleCode",
                schema: "Paper",
                table: "Soles",
                type: "NVARCHAR(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Soles",
                schema: "Paper",
                newName: "Soles");

            migrationBuilder.AlterColumn<string>(
                name: "SoleInfomation",
                table: "Soles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(250)");

            migrationBuilder.AlterColumn<string>(
                name: "SoleCode",
                table: "Soles",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(250)");
        }
    }
}
