using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initial_20231029 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaperTypeCode",
                schema: "Paper",
                table: "PaperTypeMains");

            migrationBuilder.DropColumn(
                name: "PaperTypeID",
                schema: "Paper",
                table: "PaperTypeMains");

            migrationBuilder.DropColumn(
                name: "PaperTypeName",
                schema: "Paper",
                table: "PaperTypeMains");

            migrationBuilder.AddColumn<string>(
                name: "PaperTypeMainCode",
                schema: "Paper",
                table: "PaperTypes",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaperTypeMainID",
                schema: "Paper",
                table: "PaperTypes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PaperTypeMainName",
                schema: "Paper",
                table: "PaperTypes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<string>(
                name: "PaperTypeMainName",
                schema: "Paper",
                table: "PaperTypeMains",
                type: "NVARCHAR(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PaperTypeMainCode",
                schema: "Paper",
                table: "PaperTypeMains",
                type: "NVARCHAR(250)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PaperTypeMainCode",
                schema: "Paper",
                table: "PaperTypes");

            migrationBuilder.DropColumn(
                name: "PaperTypeMainID",
                schema: "Paper",
                table: "PaperTypes");

            migrationBuilder.DropColumn(
                name: "PaperTypeMainName",
                schema: "Paper",
                table: "PaperTypes");

            migrationBuilder.AlterColumn<string>(
                name: "PaperTypeMainName",
                schema: "Paper",
                table: "PaperTypeMains",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(250)");

            migrationBuilder.AlterColumn<string>(
                name: "PaperTypeMainCode",
                schema: "Paper",
                table: "PaperTypeMains",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(250)");

            migrationBuilder.AddColumn<string>(
                name: "PaperTypeCode",
                schema: "Paper",
                table: "PaperTypeMains",
                type: "NVARCHAR(250)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "PaperTypeID",
                schema: "Paper",
                table: "PaperTypeMains",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PaperTypeName",
                schema: "Paper",
                table: "PaperTypeMains",
                type: "NVARCHAR(250)",
                nullable: false,
                defaultValue: "");
        }
    }
}
