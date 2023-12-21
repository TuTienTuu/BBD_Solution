using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initial_20231002_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Paper");

            migrationBuilder.RenameTable(
                name: "Glues",
                newName: "Glues",
                newSchema: "Paper");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "Glues",
                schema: "Paper",
                newName: "Glues");
        }
    }
}
