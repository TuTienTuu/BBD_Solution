using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initital_20231128_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Note",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                newName: "Remake");

            migrationBuilder.AlterColumn<string>(
                name: "USE_DAT",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(14)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(8)");

            migrationBuilder.AlterColumn<string>(
                name: "TEST_DAT",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(14)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(8)");

            migrationBuilder.AlterColumn<string>(
                name: "IMPORT_DAT",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(14)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(8)");

            migrationBuilder.AlterColumn<string>(
                name: "EXPORT_DAT",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(14)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(8)");

            migrationBuilder.AlterColumn<string>(
                name: "EXPIRED_DAT",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(14)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(8)");

            migrationBuilder.AddColumn<float>(
                name: "QTY",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QTY",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs");

            migrationBuilder.RenameColumn(
                name: "Remake",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                newName: "Note");

            migrationBuilder.AlterColumn<string>(
                name: "USE_DAT",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(8)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(14)");

            migrationBuilder.AlterColumn<string>(
                name: "TEST_DAT",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(8)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(14)");

            migrationBuilder.AlterColumn<string>(
                name: "IMPORT_DAT",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(8)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(14)");

            migrationBuilder.AlterColumn<string>(
                name: "EXPORT_DAT",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(8)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(14)");

            migrationBuilder.AlterColumn<string>(
                name: "EXPIRED_DAT",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(8)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(14)");
        }
    }
}
