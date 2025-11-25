using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Service.ComponentsAPI.Migrations
{
    /// <inheritdoc />
    public partial class Components : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CaseAccessories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FormFactor = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaseAccessories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormFactors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormFactors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Manufacturers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Manufacturers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperatingSystems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Architecture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxMemoryGB = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatingSystems", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoundCards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Channels = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DigitalAudioBits = table.Column<int>(type: "int", nullable: true),
                    SnrDb = table.Column<int>(type: "int", nullable: true),
                    SampleRateKhz = table.Column<int>(type: "int", nullable: true),
                    Chipset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interface = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoundCards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CapacityGB = table.Column<long>(type: "bigint", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FormFactor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interface = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CacheMB = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UPS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    CapacityWatts = table.Column<int>(type: "int", nullable: true),
                    CapacityVa = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UPS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ExternalStorages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Interface = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CapacityGB = table.Column<long>(type: "bigint", nullable: false),
                    PricePerGB = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExternalStorages", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExternalStorages_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Cases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    IncludedPowerSupplyWatts = table.Column<int>(type: "int", nullable: true),
                    SidePanel = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExternalVolumeLiters = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Internal35Bays = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ManufacturerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cases", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cases_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Cases_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ChassiCooling",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SizeMM = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    RpmMin = table.Column<int>(type: "int", nullable: true),
                    RpmMax = table.Column<int>(type: "int", nullable: true),
                    AirflowMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    AirflowMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NoiseLevelMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NoiseLevelMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Pwm = table.Column<bool>(type: "bit", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ManufacturerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ChassiCooling", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ChassiCooling_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ChassiCooling_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CPUCoolers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAio = table.Column<bool>(type: "bit", nullable: false),
                    RadiatorSize = table.Column<int>(type: "int", nullable: true),
                    RpmMin = table.Column<int>(type: "int", nullable: true),
                    RpmMax = table.Column<int>(type: "int", nullable: true),
                    NoiseLevelMin = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    NoiseLevelMax = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ManufacturerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUCoolers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CPUCoolers_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CPUCoolers_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "CPUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: true),
                    CoreCount = table.Column<int>(type: "int", nullable: true),
                    CoreClock = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    BoostClock = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Microarchitecture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tdp = table.Column<int>(type: "int", nullable: true),
                    IntegratedGraphics = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CPUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CPUs_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FanControllers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Channels = table.Column<int>(type: "int", nullable: true),
                    ChannelWattage = table.Column<int>(type: "int", nullable: true),
                    Pwm = table.Column<bool>(type: "bit", nullable: false),
                    FormFactor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    ManufacturerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FanControllers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FanControllers_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_FanControllers_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "GPUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: true),
                    Chipset = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MemoryGB = table.Column<int>(type: "int", nullable: true),
                    CoreClock = table.Column<int>(type: "int", nullable: true),
                    BoostClock = table.Column<int>(type: "int", nullable: true),
                    LengthMM = table.Column<int>(type: "int", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GPUs_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_GPUs_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Headsets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FrequencyMinHz = table.Column<int>(type: "int", nullable: true),
                    FrequencyMaxKhz = table.Column<int>(type: "int", nullable: true),
                    Microphone = table.Column<bool>(type: "bit", nullable: false),
                    Wireless = table.Column<bool>(type: "bit", nullable: false),
                    EnclosureType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    ManufacturerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Headsets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Headsets_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Headsets_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Keyboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Style = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Switches = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Backlit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tenkeyless = table.Column<bool>(type: "bit", nullable: false),
                    Connection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    ManufacturerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Keyboards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Keyboards_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Keyboards_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Mice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    TrackingMethod = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Connection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaxDpi = table.Column<int>(type: "int", nullable: true),
                    HandOrientation = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    ManufacturerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mice_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Mice_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Monitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ScreenSizeInches = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ResolutionWidth = table.Column<int>(type: "int", nullable: false),
                    ResolutionHeight = table.Column<int>(type: "int", nullable: false),
                    RefreshRateHz = table.Column<int>(type: "int", nullable: false),
                    ResponseTimeMs = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    PanelType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AspectRatio = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ManufacturerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Monitors_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Motherboards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ManufacturerId = table.Column<int>(type: "int", nullable: true),
                    Socket = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    FormFactorId = table.Column<int>(type: "int", nullable: true),
                    MaxMemoryGB = table.Column<int>(type: "int", nullable: true),
                    MemorySlots = table.Column<int>(type: "int", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    HasWiFi = table.Column<bool>(type: "bit", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motherboards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motherboards_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Motherboards_FormFactors_FormFactorId",
                        column: x => x.FormFactorId,
                        principalTable: "FormFactors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Motherboards_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PSUs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EfficiencyRating = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wattage = table.Column<int>(type: "int", nullable: false),
                    Modular = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ManufacturerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PSUs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PSUs_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_PSUs_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RAMModules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalCapacityGB = table.Column<int>(type: "int", nullable: false),
                    SpeedMTs = table.Column<int>(type: "int", nullable: false),
                    CasLatency = table.Column<int>(type: "int", nullable: true),
                    FirstWordLatency = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ManufacturerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RAMModules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RAMModules_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RAMModules_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Speakers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Configuration = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Wattage = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    FrequencyMinHz = table.Column<int>(type: "int", nullable: true),
                    FrequencyMaxKhz = table.Column<int>(type: "int", nullable: true),
                    ColorId = table.Column<int>(type: "int", nullable: true),
                    ManufacturerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speakers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Speakers_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Speakers_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Webcams",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    Resolutions = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Connection = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FocusType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupportedOs = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FovDegrees = table.Column<int>(type: "int", nullable: true),
                    ManufacturerId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Webcams", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Webcams_Manufacturers_ManufacturerId",
                        column: x => x.ManufacturerId,
                        principalTable: "Manufacturers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ColorId",
                table: "Cases",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ManufacturerId",
                table: "Cases",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_ChassiCooling_ColorId",
                table: "ChassiCooling",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ChassiCooling_ManufacturerId",
                table: "ChassiCooling",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUCoolers_ColorId",
                table: "CPUCoolers",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUCoolers_ManufacturerId",
                table: "CPUCoolers",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_ManufacturerId",
                table: "CPUs",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalStorages_ColorId",
                table: "ExternalStorages",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_FanControllers_ColorId",
                table: "FanControllers",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_FanControllers_ManufacturerId",
                table: "FanControllers",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_GPUs_ColorId",
                table: "GPUs",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_GPUs_ManufacturerId",
                table: "GPUs",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Headsets_ColorId",
                table: "Headsets",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Headsets_ManufacturerId",
                table: "Headsets",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Keyboards_ColorId",
                table: "Keyboards",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Keyboards_ManufacturerId",
                table: "Keyboards",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Mice_ColorId",
                table: "Mice",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Mice_ManufacturerId",
                table: "Mice",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Monitors_ManufacturerId",
                table: "Monitors",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_ColorId",
                table: "Motherboards",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_FormFactorId",
                table: "Motherboards",
                column: "FormFactorId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_ManufacturerId",
                table: "Motherboards",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_Socket",
                table: "Motherboards",
                column: "Socket");

            migrationBuilder.CreateIndex(
                name: "IX_PSUs_ColorId",
                table: "PSUs",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_PSUs_ManufacturerId",
                table: "PSUs",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_RAMModules_ColorId",
                table: "RAMModules",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_RAMModules_ManufacturerId",
                table: "RAMModules",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Speakers_ColorId",
                table: "Speakers",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Speakers_ManufacturerId",
                table: "Speakers",
                column: "ManufacturerId");

            migrationBuilder.CreateIndex(
                name: "IX_Webcams_ManufacturerId",
                table: "Webcams",
                column: "ManufacturerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaseAccessories");

            migrationBuilder.DropTable(
                name: "Cases");

            migrationBuilder.DropTable(
                name: "ChassiCooling");

            migrationBuilder.DropTable(
                name: "CPUCoolers");

            migrationBuilder.DropTable(
                name: "CPUs");

            migrationBuilder.DropTable(
                name: "ExternalStorages");

            migrationBuilder.DropTable(
                name: "FanControllers");

            migrationBuilder.DropTable(
                name: "GPUs");

            migrationBuilder.DropTable(
                name: "Headsets");

            migrationBuilder.DropTable(
                name: "Keyboards");

            migrationBuilder.DropTable(
                name: "Mice");

            migrationBuilder.DropTable(
                name: "Monitors");

            migrationBuilder.DropTable(
                name: "Motherboards");

            migrationBuilder.DropTable(
                name: "OperatingSystems");

            migrationBuilder.DropTable(
                name: "PSUs");

            migrationBuilder.DropTable(
                name: "RAMModules");

            migrationBuilder.DropTable(
                name: "SoundCards");

            migrationBuilder.DropTable(
                name: "Speakers");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropTable(
                name: "UPS");

            migrationBuilder.DropTable(
                name: "Webcams");

            migrationBuilder.DropTable(
                name: "FormFactors");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropTable(
                name: "Manufacturers");
        }
    }
}
