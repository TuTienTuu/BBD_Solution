using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initial_20231201 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Remake",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                newName: "Remark");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Remark",
                schema: "BDST",
                table: "STA0030_Material_Supplier_RAWNOs",
                newName: "Remake");
        }
    }
}
