using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initial_20231215_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "StandardQuantity",
                schema: "BDST",
                table: "STA0020_Material_Supplier_LOTNOs",
                newName: "StandardUnit");

            migrationBuilder.AddColumn<float>(
                name: "Quantity",
                schema: "BDST",
                table: "STA0020_Material_Supplier_LOTNOs",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                schema: "BDST",
                table: "STA0020_Material_Supplier_LOTNOs");

            migrationBuilder.RenameColumn(
                name: "StandardUnit",
                schema: "BDST",
                table: "STA0020_Material_Supplier_LOTNOs",
                newName: "StandardQuantity");
        }
    }
}
