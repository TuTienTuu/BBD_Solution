using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initial_20231011 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "Created",
                schema: "Paper",
                table: "Glues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "Deleted",
                schema: "Paper",
                table: "Glues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Description",
                schema: "Paper",
                table: "Glues",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                schema: "Paper",
                table: "Glues",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "Modified",
                schema: "Paper",
                table: "Glues",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Created",
                schema: "Paper",
                table: "Glues");

            migrationBuilder.DropColumn(
                name: "Deleted",
                schema: "Paper",
                table: "Glues");

            migrationBuilder.DropColumn(
                name: "Description",
                schema: "Paper",
                table: "Glues");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                schema: "Paper",
                table: "Glues");

            migrationBuilder.DropColumn(
                name: "Modified",
                schema: "Paper",
                table: "Glues");
        }
    }
}
