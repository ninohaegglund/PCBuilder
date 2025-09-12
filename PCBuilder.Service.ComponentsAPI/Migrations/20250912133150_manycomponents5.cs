using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Service.ComponentsAPI.Migrations
{
    /// <inheritdoc />
    public partial class manycomponents5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_CPUs_CpuId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Cases_CaseId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Motherboards_MotherboardId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Computers_PSUs_PSUId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_CaseId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_CpuId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_MotherboardId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_PSUId",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "CaseId",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "CpuId",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "MotherboardId",
                table: "Computers");

            migrationBuilder.DropColumn(
                name: "PSUId",
                table: "Computers");

            migrationBuilder.AddColumn<int>(
                name: "ComputerId",
                table: "PSUs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComputerId",
                table: "Motherboards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComputerId",
                table: "CPUs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComputerId",
                table: "Cases",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PSUs_ComputerId",
                table: "PSUs",
                column: "ComputerId",
                unique: true,
                filter: "[ComputerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_ComputerId",
                table: "Motherboards",
                column: "ComputerId",
                unique: true,
                filter: "[ComputerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_CPUs_ComputerId",
                table: "CPUs",
                column: "ComputerId",
                unique: true,
                filter: "[ComputerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ComputerId",
                table: "Cases",
                column: "ComputerId",
                unique: true,
                filter: "[ComputerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Computers_ComputerId",
                table: "Cases",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CPUs_Computers_ComputerId",
                table: "CPUs",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Motherboards_Computers_ComputerId",
                table: "Motherboards",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PSUs_Computers_ComputerId",
                table: "PSUs",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Computers_ComputerId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_Computers_ComputerId",
                table: "CPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_Motherboards_Computers_ComputerId",
                table: "Motherboards");

            migrationBuilder.DropForeignKey(
                name: "FK_PSUs_Computers_ComputerId",
                table: "PSUs");

            migrationBuilder.DropIndex(
                name: "IX_PSUs_ComputerId",
                table: "PSUs");

            migrationBuilder.DropIndex(
                name: "IX_Motherboards_ComputerId",
                table: "Motherboards");

            migrationBuilder.DropIndex(
                name: "IX_CPUs_ComputerId",
                table: "CPUs");

            migrationBuilder.DropIndex(
                name: "IX_Cases_ComputerId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "ComputerId",
                table: "PSUs");

            migrationBuilder.DropColumn(
                name: "ComputerId",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "ComputerId",
                table: "CPUs");

            migrationBuilder.DropColumn(
                name: "ComputerId",
                table: "Cases");

            migrationBuilder.AddColumn<int>(
                name: "CaseId",
                table: "Computers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CpuId",
                table: "Computers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MotherboardId",
                table: "Computers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PSUId",
                table: "Computers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Computers_CaseId",
                table: "Computers",
                column: "CaseId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_CpuId",
                table: "Computers",
                column: "CpuId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_MotherboardId",
                table: "Computers",
                column: "MotherboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_PSUId",
                table: "Computers",
                column: "PSUId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_CPUs_CpuId",
                table: "Computers",
                column: "CpuId",
                principalTable: "CPUs",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Cases_CaseId",
                table: "Computers",
                column: "CaseId",
                principalTable: "Cases",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Motherboards_MotherboardId",
                table: "Computers",
                column: "MotherboardId",
                principalTable: "Motherboards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_PSUs_PSUId",
                table: "Computers",
                column: "PSUId",
                principalTable: "PSUs",
                principalColumn: "Id");
        }
    }
}
