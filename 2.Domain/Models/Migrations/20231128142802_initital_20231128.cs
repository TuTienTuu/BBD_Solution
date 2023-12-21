using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initital_20231128 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "STA0030_Material_Supplier_RAWNOs",
                schema: "BDST",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RAWNO = table.Column<string>(type: "CHAR(14)", nullable: false),
                    LOTNO = table.Column<string>(type: "CHAR(11)", nullable: false),
                    MATCD = table.Column<string>(type: "NVARCHAR(5)", nullable: false),
                    MaterialCode = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    MaterialName = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    Supplier = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    Note = table.Column<string>(type: "NVARCHAR(max)", nullable: false),
                    UNITQTY = table.Column<double>(type: "Float", nullable: false),
                    Unit = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    Size = table.Column<string>(type: "NVARCHAR(Max)", nullable: false),
                    Sup_LOT = table.Column<string>(type: "NVARCHAR(25)", nullable: false),
                    PROD_DAT = table.Column<string>(type: "NVARCHAR(8)", nullable: false),
                    IMPORT_DAT = table.Column<string>(type: "NVARCHAR(8)", nullable: false),
                    TEST_DAT = table.Column<string>(type: "NVARCHAR(8)", nullable: false),
                    TEST_RESULT = table.Column<string>(type: "CHAR(1)", nullable: false),
                    EXPIRED_DAT = table.Column<string>(type: "NVARCHAR(8)", nullable: false),
                    EXPORT_DAT = table.Column<string>(type: "NVARCHAR(8)", nullable: false),
                    USE_DAT = table.Column<string>(type: "NVARCHAR(8)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STA0030_Material_Supplier_RAWNOs", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STA0030_Material_Supplier_RAWNOs",
                schema: "BDST");
        }
    }
}
