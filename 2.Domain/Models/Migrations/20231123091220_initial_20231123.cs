using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initial_20231123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FunctionResults",
                columns: table => new
                {
                    ResultNumber = table.Column<int>(type: "int", nullable: true),
                    ResultString = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ResultBool = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                });

            migrationBuilder.CreateTable(
                name: "STA0020_Material_Supplier_LOTNOs",
                schema: "BDST",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LotNo = table.Column<string>(type: "CHAR(11)", nullable: false),
                    MatCD = table.Column<string>(type: "NVARCHAR(5)", nullable: false),
                    Supplier = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    SupLOT = table.Column<string>(type: "NVARCHAR(25)", nullable: false),
                    InEAQuantity = table.Column<double>(type: "Float", nullable: false),
                    UnitQuantity = table.Column<double>(type: "Float", nullable: false),
                    ProductDate = table.Column<string>(type: "NVARCHAR(8)", nullable: false),
                    ImportDate = table.Column<string>(type: "NVARCHAR(8)", nullable: false),
                    TestDate = table.Column<string>(type: "NVARCHAR(8)", nullable: false),
                    TestResult = table.Column<string>(type: "CHAR(1)", nullable: false),
                    ExpiredDate = table.Column<string>(type: "NVARCHAR(8)", nullable: false),
                    MaterialCode = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    MaterialName = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    Note = table.Column<string>(type: "NVARCHAR(max)", nullable: true),
                    Unit = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    Size = table.Column<string>(type: "NVARCHAR(Max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STA0020_Material_Supplier_LOTNOs", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FunctionResults");

            migrationBuilder.DropTable(
                name: "STA0020_Material_Supplier_LOTNOs",
                schema: "BDST");
        }
    }
}
