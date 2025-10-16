using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Service.ComponentsAPI.Migrations
{
    /// <inheritdoc />
    public partial class InitComponents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Components",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComponentType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(21)", maxLength: 21, nullable: false),
                    CPU_ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPU_Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPU_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPU_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CPU_PerformanceScore = table.Column<int>(type: "int", nullable: true),
                    Cores = table.Column<int>(type: "int", nullable: true),
                    Threads = table.Column<int>(type: "int", nullable: true),
                    BaseClockGhz = table.Column<double>(type: "float", nullable: true),
                    BoostClockGhz = table.Column<double>(type: "float", nullable: true),
                    CPU_TDP = table.Column<int>(type: "int", nullable: true),
                    CPU_PowerConsumptionW = table.Column<int>(type: "int", nullable: true),
                    Socket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPUCooling_ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPUCooling_Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPUCooling_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPUCooling_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CoolingCapacityW = table.Column<int>(type: "int", nullable: true),
                    NoiseLevelDb = table.Column<int>(type: "int", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayMonitor_ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayMonitor_Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayMonitor_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DisplayMonitor_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    DisplayMonitor_ComputerId = table.Column<int>(type: "int", nullable: true),
                    SizeInches = table.Column<double>(type: "float", nullable: true),
                    Hz = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Resolution = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PerformanceScore = table.Column<int>(type: "int", nullable: true),
                    ComputerId = table.Column<int>(type: "int", nullable: true),
                    VramGb = table.Column<int>(type: "int", nullable: true),
                    VramType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LengthMm = table.Column<int>(type: "int", nullable: true),
                    PowerConsumptionW = table.Column<int>(type: "int", nullable: true),
                    TDP = table.Column<int>(type: "int", nullable: true),
                    Interface = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chassi_Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chassi_ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chassi_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chassi_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FormFactor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChassiMaterial = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxGpuLengthMm = table.Column<int>(type: "int", nullable: true),
                    ChassiCooling_ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChassiCooling_Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChassiCooling_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChassiCooling_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ChassiCooling_ComputerId = table.Column<int>(type: "int", nullable: true),
                    FanSizeMm = table.Column<int>(type: "int", nullable: true),
                    Rpm = table.Column<int>(type: "int", nullable: true),
                    ChassiCooling_CoolingCapacityW = table.Column<int>(type: "int", nullable: true),
                    Headset_ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Headset_Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Headset_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Headset_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsWireless = table.Column<bool>(type: "bit", nullable: true),
                    HasMicrophone = table.Column<bool>(type: "bit", nullable: true),
                    Keyboard_ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keyboard_Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keyboard_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keyboard_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    IsMechanical = table.Column<bool>(type: "bit", nullable: true),
                    SwitchType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Keyboard_IsWireless = table.Column<bool>(type: "bit", nullable: true),
                    HasBacklight = table.Column<bool>(type: "bit", nullable: true),
                    Layout = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizePercent = table.Column<int>(type: "int", nullable: true),
                    Mouse_ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mouse_Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mouse_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Mouse_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Dpi = table.Column<int>(type: "int", nullable: true),
                    Mouse_IsWireless = table.Column<bool>(type: "bit", nullable: true),
                    NumberOfButtons = table.Column<int>(type: "int", nullable: true),
                    Speaker_ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speaker_Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speaker_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speaker_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Speaker_ComputerId = table.Column<int>(type: "int", nullable: true),
                    Watt = table.Column<int>(type: "int", nullable: true),
                    Speaker_IsWireless = table.Column<bool>(type: "bit", nullable: true),
                    Motherboard_ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Motherboard_Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Motherboard_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Motherboard_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Motherboard_Socket = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Chipset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RamSlots = table.Column<int>(type: "int", nullable: true),
                    SupportedRamType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxRamCapacityGb = table.Column<int>(type: "int", nullable: true),
                    PcieSlots = table.Column<int>(type: "int", nullable: true),
                    PSU_ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PSU_Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PSU_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PSU_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Wattage = table.Column<int>(type: "int", nullable: true),
                    EfficiencyRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PSU_PowerConsumptionW = table.Column<int>(type: "int", nullable: true),
                    RAM_ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RAM_Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RAM_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RAM_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    RAM_ComputerId = table.Column<int>(type: "int", nullable: true),
                    CapacityGb = table.Column<int>(type: "int", nullable: true),
                    SpeedMHz = table.Column<int>(type: "int", nullable: true),
                    RAM_Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageDevice_ModelName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageDevice_Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageDevice_Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageDevice_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    StorageDevice_ComputerId = table.Column<int>(type: "int", nullable: true),
                    StorageDevice_CapacityGb = table.Column<int>(type: "int", nullable: true),
                    StorageDevice_Interface = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StorageDevice_PowerConsumptionW = table.Column<int>(type: "int", nullable: true),
                    ReadSpeedMb = table.Column<int>(type: "int", nullable: true),
                    WriteSpeedMb = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Components", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoolerSocketCompatibility",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Socket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CPUCoolingId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoolerSocketCompatibility", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoolerSocketCompatibility_Components_CPUCoolingId",
                        column: x => x.CPUCoolingId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CoolerSocketCompatibility_CPUCoolingId",
                table: "CoolerSocketCompatibility",
                column: "CPUCoolingId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CoolerSocketCompatibility");

            migrationBuilder.DropTable(
                name: "Components");
        }
    }
}
