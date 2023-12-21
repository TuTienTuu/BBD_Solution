using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initial_20231110 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "CodeLevel1Managements",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeLevel1 = table.Column<string>(type: "VARCHAR(3)", maxLength: 3, nullable: false),
                    CodeLevel1Description = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    CodeLevel1Lenght = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeLevel1Managements", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CodeLevel2Managements",
                schema: "dbo",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeLevel1 = table.Column<string>(type: "VARCHAR(3)", maxLength: 3, nullable: false),
                    IDLevel1 = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodeLevel2 = table.Column<string>(type: "VARCHAR(20)", maxLength: 20, nullable: false),
                    CodeLevel2Description = table.Column<string>(type: "NVARCHAR(50)", maxLength: 50, nullable: false),
                    CodeLevel2Lenght = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CodeLevel2Managements", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CodeLevel1Managements",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CodeLevel2Managements",
                schema: "dbo");
        }
    }
}
