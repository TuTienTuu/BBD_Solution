using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    public partial class initial_20231031 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Quotation");

            migrationBuilder.CreateTable(
                name: "ConfigFees",
                schema: "Quotation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ManagerFee = table.Column<decimal>(type: "Decimal(18,4)", nullable: false, defaultValue: 0m),
                    WorkshopRentalFee = table.Column<decimal>(type: "Decimal(18,4)", nullable: false, defaultValue: 0m),
                    ElectricFee = table.Column<decimal>(type: "Decimal(18,4)", nullable: false, defaultValue: 0m),
                    DepreciationFee = table.Column<decimal>(type: "Decimal(18,4)", nullable: false, defaultValue: 0m),
                    ManagerFeePerMachine = table.Column<decimal>(type: "Decimal(18,4)", nullable: false, defaultValue: 0m),
                    WorkshopRentalFeePerMachine = table.Column<decimal>(type: "Decimal(18,4)", nullable: false, defaultValue: 0m),
                    ElectricFeePerMachine = table.Column<decimal>(type: "Decimal(18,4)", nullable: false, defaultValue: 0m),
                    DepreciationFeePerMachineHours = table.Column<decimal>(type: "Decimal(18,4)", nullable: false, defaultValue: 0m),
                    DepreciationFeePerMachineDay = table.Column<decimal>(type: "Decimal(18,4)", nullable: false, defaultValue: 0m),
                    MaintainFee = table.Column<decimal>(type: "Decimal(18,4)", nullable: false, defaultValue: 0m),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "Datetime", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    IsDeleted = table.Column<bool>(type: "Bit", nullable: false, defaultValue: false),
                    Deleted = table.Column<DateTime>(type: "Datetime", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    Note = table.Column<string>(type: "NVARCHAR(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigFees", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "MachineConfigs",
                schema: "Quotation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineName = table.Column<string>(type: "NVARCHAR(50)", nullable: true),
                    ChangeRoll = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Color = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Compensation = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Risk = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    ChangeSpec = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    WhiteCarry = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Target = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Power = table.Column<decimal>(type: "Decimal(18,4)", nullable: false, defaultValue: 0m),
                    KWPerHour = table.Column<decimal>(type: "Decimal(18,4)", nullable: false, defaultValue: 0m),
                    ElectricPrice = table.Column<decimal>(type: "Decimal(18,4)", nullable: false, defaultValue: 0m),
                    Change = table.Column<decimal>(type: "Decimal(18,4)", nullable: false, defaultValue: 0m),
                    ChangeSpec_H = table.Column<decimal>(type: "Decimal(18,4)", nullable: false, defaultValue: 0m),
                    ChangeRoll_H = table.Column<decimal>(type: "Decimal(18,4)", nullable: false, defaultValue: 0m),
                    OperatorNumber = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    OperatorSalary_1 = table.Column<decimal>(type: "Decimal(18,4)", nullable: false, defaultValue: 0m),
                    OperatorSalary_2 = table.Column<decimal>(type: "Decimal(18,4)", nullable: false, defaultValue: 0m),
                    HourlySalary = table.Column<decimal>(type: "Decimal(18,4)", nullable: false, defaultValue: 0m),
                    CostAllocationPercent = table.Column<int>(type: "int", nullable: false, defaultValue: 0),
                    Created = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Modified = table.Column<DateTime>(type: "Datetime", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    IsDeleted = table.Column<bool>(type: "Bit", nullable: false, defaultValue: false),
                    Deleted = table.Column<DateTime>(type: "Datetime", nullable: false, defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified)),
                    Note = table.Column<string>(type: "NVARCHAR(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineConfigs", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigFees",
                schema: "Quotation");

            migrationBuilder.DropTable(
                name: "MachineConfigs",
                schema: "Quotation");
        }
    }
}
