using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initial_20231117 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "BDST");

            migrationBuilder.CreateTable(
                name: "STA0010_Material_Masters",
                schema: "BDST",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MATCD = table.Column<string>(type: "NVARCHAR(5)", nullable: false),
                    MATGROUPCD = table.Column<string>(type: "CHAR(1)", nullable: false),
                    MaterialCode = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    MaterialName = table.Column<string>(type: "NVARCHAR(250)", nullable: true),
                    Note = table.Column<string>(type: "NVARCHAR(max)", nullable: true),
                    Unit = table.Column<string>(type: "NVARCHAR(250)", nullable: true),
                    UnitQty = table.Column<int>(type: "Int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified))
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STA0010_Material_Masters", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "STA0010_Material_Masters",
                schema: "BDST");
        }
    }
}
