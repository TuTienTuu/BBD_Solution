using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initital_20231127 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "STB0010_Material_Export_Trackings",
                schema: "BDST",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LOTNO = table.Column<string>(type: "CHAR(11)", nullable: false),
                    MATCD = table.Column<string>(type: "CHAR(5)", nullable: false),
                    STA0020_Material_Supplier_LotnoID = table.Column<int>(type: "INT", nullable: false),
                    MaterialCode = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    IDEmp = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    STRNO = table.Column<int>(type: "INT", nullable: false),
                    ENDNO = table.Column<int>(type: "INT", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STB0010_Material_Export_Trackings", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STB0010_Material_Export_Trackings",
                schema: "BDST");
        }
    }
}
