using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initital_20231129 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TEST_RESULT",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "CHAR(1)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "CHAR(1)");

            migrationBuilder.AlterColumn<string>(
                name: "TEST_DAT",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(14)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(14)");

            migrationBuilder.AlterColumn<string>(
                name: "Sup_LOT",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(25)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(25)");

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(Max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(Max)");

            migrationBuilder.AlterColumn<string>(
                name: "Remake",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(max)");

            migrationBuilder.AlterColumn<string>(
                name: "PROD_DAT",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(8)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(8)");

            migrationBuilder.AlterColumn<string>(
                name: "MaterialName",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(250)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(250)");

            migrationBuilder.AlterColumn<string>(
                name: "IMPORT_DAT",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(14)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(14)");

            migrationBuilder.AlterColumn<string>(
                name: "EXPORT_DAT",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(14)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(14)");

            migrationBuilder.AlterColumn<string>(
                name: "EXPIRED_DAT",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(14)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "NVARCHAR(14)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "TEST_RESULT",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "CHAR(1)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "CHAR(1)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "TEST_DAT",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(14)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(14)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Sup_LOT",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(25)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(25)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Size",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(Max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(Max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Remake",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PROD_DAT",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(8)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(8)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MaterialName",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(250)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(250)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "IMPORT_DAT",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(14)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(14)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EXPORT_DAT",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(14)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(14)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EXPIRED_DAT",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                type: "NVARCHAR(14)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "NVARCHAR(14)",
                oldNullable: true);
        }
    }
}
