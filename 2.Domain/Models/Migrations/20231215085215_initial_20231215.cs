using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initial_20231215 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "StandardQuantity",
                schema: "BDST",
                table: "STA0020_Material_Supplier_LOTNOs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StandardQuantity",
                schema: "BDST",
                table: "STA0020_Material_Supplier_LOTNOs");
        }
    }
}
