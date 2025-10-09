using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Service.ComponentsAPI.Migrations
{
    /// <inheritdoc />
    public partial class deletablecomponents : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChassiCooling_Computers_ComputerId",
                table: "ChassiCooling");

            migrationBuilder.DropForeignKey(
                name: "FK_GPUs_Computers_ComputerId",
                table: "GPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_Monitors_Computers_ComputerId",
                table: "Monitors");

            migrationBuilder.DropForeignKey(
                name: "FK_PCIeCables_Computers_ComputerId",
                table: "PCIeCables");

            migrationBuilder.DropForeignKey(
                name: "FK_PowerCables_Computers_ComputerId",
                table: "PowerCables");

            migrationBuilder.DropForeignKey(
                name: "FK_RAMModules_Computers_ComputerId",
                table: "RAMModules");

            migrationBuilder.DropForeignKey(
                name: "FK_SataCables_Computers_ComputerId",
                table: "SataCables");

            migrationBuilder.DropForeignKey(
                name: "FK_Speakers_Computers_ComputerId",
                table: "Speakers");

            migrationBuilder.DropForeignKey(
                name: "FK_Storages_Computers_ComputerId",
                table: "Storages");

            migrationBuilder.AddForeignKey(
                name: "FK_ChassiCooling_Computers_ComputerId",
                table: "ChassiCooling",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_GPUs_Computers_ComputerId",
                table: "GPUs",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Monitors_Computers_ComputerId",
                table: "Monitors",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_PCIeCables_Computers_ComputerId",
                table: "PCIeCables",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_PowerCables_Computers_ComputerId",
                table: "PowerCables",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_RAMModules_Computers_ComputerId",
                table: "RAMModules",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_SataCables_Computers_ComputerId",
                table: "SataCables",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Speakers_Computers_ComputerId",
                table: "Speakers",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Storages_Computers_ComputerId",
                table: "Storages",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChassiCooling_Computers_ComputerId",
                table: "ChassiCooling");

            migrationBuilder.DropForeignKey(
                name: "FK_GPUs_Computers_ComputerId",
                table: "GPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_Monitors_Computers_ComputerId",
                table: "Monitors");

            migrationBuilder.DropForeignKey(
                name: "FK_PCIeCables_Computers_ComputerId",
                table: "PCIeCables");

            migrationBuilder.DropForeignKey(
                name: "FK_PowerCables_Computers_ComputerId",
                table: "PowerCables");

            migrationBuilder.DropForeignKey(
                name: "FK_RAMModules_Computers_ComputerId",
                table: "RAMModules");

            migrationBuilder.DropForeignKey(
                name: "FK_SataCables_Computers_ComputerId",
                table: "SataCables");

            migrationBuilder.DropForeignKey(
                name: "FK_Speakers_Computers_ComputerId",
                table: "Speakers");

            migrationBuilder.DropForeignKey(
                name: "FK_Storages_Computers_ComputerId",
                table: "Storages");

            migrationBuilder.AddForeignKey(
                name: "FK_ChassiCooling_Computers_ComputerId",
                table: "ChassiCooling",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GPUs_Computers_ComputerId",
                table: "GPUs",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Monitors_Computers_ComputerId",
                table: "Monitors",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PCIeCables_Computers_ComputerId",
                table: "PCIeCables",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PowerCables_Computers_ComputerId",
                table: "PowerCables",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RAMModules_Computers_ComputerId",
                table: "RAMModules",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SataCables_Computers_ComputerId",
                table: "SataCables",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Speakers_Computers_ComputerId",
                table: "Speakers",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Storages_Computers_ComputerId",
                table: "Storages",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id");
        }
    }
}
