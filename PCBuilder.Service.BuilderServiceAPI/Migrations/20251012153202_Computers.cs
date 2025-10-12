using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Service.BuilderServiceAPI.Migrations
{
    /// <inheritdoc />
    public partial class Computers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Computers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComputerName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsBuilt = table.Column<bool>(type: "bit", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CPUId = table.Column<int>(type: "int", nullable: true),
                    PSUId = table.Column<int>(type: "int", nullable: true),
                    MotherboardId = table.Column<int>(type: "int", nullable: true),
                    CaseId = table.Column<int>(type: "int", nullable: true),
                    CpuCoolerId = table.Column<int>(type: "int", nullable: true),
                    KeyboardId = table.Column<int>(type: "int", nullable: true),
                    MouseId = table.Column<int>(type: "int", nullable: true),
                    HeadsetId = table.Column<int>(type: "int", nullable: true),
                    GPUIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RAMIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StorageIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CaseFanIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonitorIds = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpeakerIds = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Computers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Inventories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InventoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ComponentId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventories", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Computers");

            migrationBuilder.DropTable(
                name: "Inventories");
        }
    }
}
