using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initial_20231218 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InEAQuantity",
                schema: "BDST",
                table: "STA0020_Material_Supplier_LOTNOs");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "InEAQuantity",
                schema: "BDST",
                table: "STA0020_Material_Supplier_LOTNOs",
                type: "Float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
