using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initial_20231102 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "Quotation",
                table: "MachineConfigs",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Datetime",
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Quotation",
                table: "MachineConfigs",
                type: "bit",
                nullable: false,
                oldClrType: typeof(bool),
                oldType: "Bit",
                oldDefaultValue: false);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Deleted",
                schema: "Quotation",
                table: "MachineConfigs",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "Datetime",
                oldDefaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "Modified",
                schema: "Quotation",
                table: "MachineConfigs",
                type: "Datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<bool>(
                name: "IsDeleted",
                schema: "Quotation",
                table: "MachineConfigs",
                type: "Bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Deleted",
                schema: "Quotation",
                table: "MachineConfigs",
                type: "Datetime",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }
    }
}
