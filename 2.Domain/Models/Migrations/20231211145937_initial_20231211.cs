using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initial_20231211 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UnitPrices",
                schema: "Quotation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagermentFeeTotal = table.Column<float>(type: "real", nullable: false),
                    Quantity = table.Column<float>(type: "real", nullable: false),
                    Unit = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    Characteristic = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    Spec = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    WorkshopRentalFee = table.Column<float>(type: "real", nullable: false),
                    DepriciationTotalFee = table.Column<float>(type: "real", nullable: false),
                    ElectricFee = table.Column<float>(type: "real", nullable: false),
                    KnifeUnitFee = table.Column<float>(type: "real", nullable: false),
                    TotalSalary = table.Column<float>(type: "real", nullable: false),
                    DecalTotalPrice = table.Column<float>(type: "real", nullable: false),
                    LaminationTotalPrice = table.Column<float>(type: "real", nullable: false),
                    CorePrice = table.Column<float>(type: "real", nullable: false),
                    ColorPrice = table.Column<float>(type: "real", nullable: false),
                    FilmPrice = table.Column<float>(type: "real", nullable: false),
                    Print_Price = table.Column<float>(type: "real", nullable: false),
                    BoxPrice = table.Column<float>(type: "real", nullable: false),
                    SrinkFilmPrice = table.Column<float>(type: "real", nullable: false),
                    Total = table.Column<double>(type: "float", nullable: false),
                    FinalyTotal = table.Column<double>(type: "float", nullable: false),
                    SaleDiscount = table.Column<int>(type: "int", nullable: false),
                    CustomerDiscount = table.Column<float>(type: "real", nullable: false),
                    ProfitPercent = table.Column<int>(type: "int", nullable: false),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    Deleted = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    Note = table.Column<string>(type: "NVARCHAR(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnitPrices", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UnitPrices",
                schema: "Quotation");
        }
    }
}
