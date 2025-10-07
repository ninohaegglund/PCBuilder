using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Service.ComponentsAPI.Migrations
{
    /// <inheritdoc />
    public partial class components : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormFactor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ChassiMaterial = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxGpuLengthMm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CPUCoolers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoolingCapacityW = table.Column<int>(type: "int", nullable: false),
                    NoiseLevelDb = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUCoolers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CPUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cores = table.Column<int>(type: "int", nullable: false),
                    Threads = table.Column<int>(type: "int", nullable: false),
                    BaseClockGhz = table.Column<double>(type: "float", nullable: false),
                    BoostClockGhz = table.Column<double>(type: "float", nullable: false),
                    TDP = table.Column<int>(type: "int", nullable: false),
                    PowerConsumptionW = table.Column<int>(type: "int", nullable: false),
                    Socket = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Headsets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsWireless = table.Column<bool>(type: "bit", nullable: false),
                    HasMicrophone = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headsets", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Keyboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsMechanical = table.Column<bool>(type: "bit", nullable: false),
                    SwitchType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsWireless = table.Column<bool>(type: "bit", nullable: false),
                    HasBacklight = table.Column<bool>(type: "bit", nullable: false),
                    Layout = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SizePercent = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keyboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Dpi = table.Column<int>(type: "int", nullable: false),
                    IsWireless = table.Column<bool>(type: "bit", nullable: false),
                    NumberOfButtons = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mice", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motherboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Socket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Chipset = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RamSlots = table.Column<int>(type: "int", nullable: false),
                    SupportedRamType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaxRamCapacityGb = table.Column<int>(type: "int", nullable: false),
                    PcieSlots = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PSUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Wattage = table.Column<int>(type: "int", nullable: false),
                    EfficiencyRating = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PowerConsumptionW = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSUs", x => x.Id);
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
                        name: "FK_CoolerSocketCompatibility_CPUCoolers_CPUCoolingId",
                        column: x => x.CPUCoolingId,
                        principalTable: "CPUCoolers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CPUId = table.Column<int>(type: "int", nullable: true),
                    PSUId = table.Column<int>(type: "int", nullable: true),
                    MotherboardId = table.Column<int>(type: "int", nullable: true),
                    CaseId = table.Column<int>(type: "int", nullable: true),
                    CpuCoolerId = table.Column<int>(type: "int", nullable: true),
                    KeyboardId = table.Column<int>(type: "int", nullable: true),
                    MouseId = table.Column<int>(type: "int", nullable: true),
                    HeadsetId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Computers_CPUCoolers_CpuCoolerId",
                        column: x => x.CpuCoolerId,
                        principalTable: "CPUCoolers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Computers_CPUs_CPUId",
                        column: x => x.CPUId,
                        principalTable: "CPUs",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Computers_Cases_CaseId",
                        column: x => x.CaseId,
                        principalTable: "Cases",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Computers_Headsets_HeadsetId",
                        column: x => x.HeadsetId,
                        principalTable: "Headsets",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Computers_Keyboards_KeyboardId",
                        column: x => x.KeyboardId,
                        principalTable: "Keyboards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Computers_Mice_MouseId",
                        column: x => x.MouseId,
                        principalTable: "Mice",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Computers_Motherboards_MotherboardId",
                        column: x => x.MotherboardId,
                        principalTable: "Motherboards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Computers_PSUs_PSUId",
                        column: x => x.PSUId,
                        principalTable: "PSUs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChassiCooling",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComputerId = table.Column<int>(type: "int", nullable: true),
                    FanSizeMm = table.Column<int>(type: "int", nullable: false),
                    Rpm = table.Column<int>(type: "int", nullable: false),
                    CoolingCapacityW = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChassiCooling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChassiCooling_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GPUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComputerId = table.Column<int>(type: "int", nullable: true),
                    VramGb = table.Column<int>(type: "int", nullable: false),
                    VramType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LengthMm = table.Column<int>(type: "int", nullable: false),
                    PowerConsumptionW = table.Column<int>(type: "int", nullable: false),
                    TDP = table.Column<int>(type: "int", nullable: false),
                    Interface = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GPUs_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Monitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComputerId = table.Column<int>(type: "int", nullable: true),
                    SizeInches = table.Column<double>(type: "float", nullable: false),
                    Hz = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Resolution = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monitors_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PCIeCables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComputerId = table.Column<int>(type: "int", nullable: true),
                    ConnectorType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LengthCm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PCIeCables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PCIeCables_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PowerCables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComputerId = table.Column<int>(type: "int", nullable: true),
                    ConnectorType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LengthCm = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerCables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PowerCables_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RAMModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComputerId = table.Column<int>(type: "int", nullable: true),
                    CapacityGb = table.Column<int>(type: "int", nullable: false),
                    SpeedMHz = table.Column<int>(type: "int", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAMModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RAMModules_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "SataCables",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComputerId = table.Column<int>(type: "int", nullable: true),
                    LengthCm = table.Column<int>(type: "int", nullable: false),
                    IsRightAngled = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SataCables", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SataCables_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComputerId = table.Column<int>(type: "int", nullable: true),
                    Watt = table.Column<int>(type: "int", nullable: false),
                    IsWireless = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Speakers_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModelName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComputerId = table.Column<int>(type: "int", nullable: true),
                    CapacityGb = table.Column<int>(type: "int", nullable: false),
                    Interface = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PowerConsumptionW = table.Column<int>(type: "int", nullable: false),
                    ReadSpeedMb = table.Column<int>(type: "int", nullable: false),
                    WriteSpeedMb = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Storages_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ChassiCooling_ComputerId",
                table: "ChassiCooling",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_CaseId",
                table: "Computers",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_CpuCoolerId",
                table: "Computers",
                column: "CpuCoolerId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_CPUId",
                table: "Computers",
                column: "CPUId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_HeadsetId",
                table: "Computers",
                column: "HeadsetId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_KeyboardId",
                table: "Computers",
                column: "KeyboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_MotherboardId",
                table: "Computers",
                column: "MotherboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_MouseId",
                table: "Computers",
                column: "MouseId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_PSUId",
                table: "Computers",
                column: "PSUId");

            migrationBuilder.CreateIndex(
                name: "IX_CoolerSocketCompatibility_CPUCoolingId",
                table: "CoolerSocketCompatibility",
                column: "CPUCoolingId");

            migrationBuilder.CreateIndex(
                name: "IX_GPUs_ComputerId",
                table: "GPUs",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_Monitors_ComputerId",
                table: "Monitors",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_PCIeCables_ComputerId",
                table: "PCIeCables",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_PowerCables_ComputerId",
                table: "PowerCables",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_RAMModules_ComputerId",
                table: "RAMModules",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_SataCables_ComputerId",
                table: "SataCables",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_Speakers_ComputerId",
                table: "Speakers",
                column: "ComputerId");

            migrationBuilder.CreateIndex(
                name: "IX_Storages_ComputerId",
                table: "Storages",
                column: "ComputerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ChassiCooling");

            migrationBuilder.DropTable(
                name: "CoolerSocketCompatibility");

            migrationBuilder.DropTable(
                name: "GPUs");

            migrationBuilder.DropTable(
                name: "Monitors");

            migrationBuilder.DropTable(
                name: "PCIeCables");

            migrationBuilder.DropTable(
                name: "PowerCables");

            migrationBuilder.DropTable(
                name: "RAMModules");

            migrationBuilder.DropTable(
                name: "SataCables");

            migrationBuilder.DropTable(
                name: "Speakers");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropTable(
                name: "CPUCoolers");

            migrationBuilder.DropTable(
                name: "CPUs");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "Headsets");

            migrationBuilder.DropTable(
                name: "Keyboards");

            migrationBuilder.DropTable(
                name: "Mice");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "PSUs");
        }
    }
}
