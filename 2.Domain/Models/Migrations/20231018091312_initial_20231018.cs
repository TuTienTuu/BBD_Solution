using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initial_20231018 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Papers",
                schema: "Paper",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Supplier = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaperTypeID = table.Column<int>(type: "int", nullable: false),
                    PaperTypeName = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    PaperTypeMainID = table.Column<int>(type: "int", nullable: false),
                    PaperTypeMainCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoleID = table.Column<int>(type: "int", nullable: false),
                    SoleName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaperName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GlueID = table.Column<int>(type: "int", nullable: false),
                    GlueName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Purpose = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Characteristic = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaperSize = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Unit = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SurfaceThick = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoleBaseThick = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoleThick = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalThick = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    QuantitativePaper = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaperTypeCode = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    Core = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Papers", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Papers",
                schema: "Paper");
        }
    }
}
