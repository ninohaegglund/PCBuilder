using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Service.ComponentsAPI.Migrations
{
    /// <inheritdoc />
    public partial class ChangedComputerRelationsToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Computers_CaseId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_CpuCoolerId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_CPUId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_HeadsetId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_KeyboardId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_MotherboardId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_MouseId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_PSUId",
                table: "Computers");

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Computers_CaseId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_CpuCoolerId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_CPUId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_HeadsetId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_KeyboardId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_MotherboardId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_MouseId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_PSUId",
                table: "Computers");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_CaseId",
                table: "Computers",
                column: "CaseId",
                unique: true,
                filter: "[CaseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_CpuCoolerId",
                table: "Computers",
                column: "CpuCoolerId",
                unique: true,
                filter: "[CpuCoolerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_CPUId",
                table: "Computers",
                column: "CPUId",
                unique: true,
                filter: "[CPUId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_HeadsetId",
                table: "Computers",
                column: "HeadsetId",
                unique: true,
                filter: "[HeadsetId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_KeyboardId",
                table: "Computers",
                column: "KeyboardId",
                unique: true,
                filter: "[KeyboardId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_MotherboardId",
                table: "Computers",
                column: "MotherboardId",
                unique: true,
                filter: "[MotherboardId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_MouseId",
                table: "Computers",
                column: "MouseId",
                unique: true,
                filter: "[MouseId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_PSUId",
                table: "Computers",
                column: "PSUId",
                unique: true,
                filter: "[PSUId] IS NOT NULL");
        }
    }
}
