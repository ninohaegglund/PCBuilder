using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Service.ComponentsAPI.Migrations
{
    /// <inheritdoc />
    public partial class components6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computers_CPUCoolers_Id",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Computers_CPUs_Id",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Cases_Id",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Headsets_Id",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Keyboards_Id",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Mice_Id",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Computers_Motherboards_Id",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_Computers_PSUs_Id",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_PSUs_Computers_ComputerId1",
                table: "PSUs");

            migrationBuilder.DropIndex(
                name: "IX_PSUs_ComputerId1",
                table: "PSUs");

            migrationBuilder.DropIndex(
                name: "IX_Cases_ComputerId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "ComputerId1",
                table: "PSUs");

            migrationBuilder.DropColumn(
                name: "CPUCoolerId",
                table: "CPUCoolers");

            migrationBuilder.DropColumn(
                name: "CaseId",
                table: "Cases");

            migrationBuilder.RenameColumn(
                name: "PSUId",
                table: "PSUs",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MotherboardId",
                table: "Motherboards",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "MouseId",
                table: "Mice",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "KeyboardId",
                table: "Keyboards",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "HeadsetId",
                table: "Headsets",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "CPUId",
                table: "CPUs",
                newName: "Id");

            migrationBuilder.AddColumn<int>(
                name: "ComputerId",
                table: "Mice",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComputerId",
                table: "Keyboards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComputerId",
                table: "Headsets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComputerId",
                table: "CPUs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ComputerId",
                table: "CPUCoolers",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Computers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.CreateIndex(
                name: "IX_PSUs_ComputerId",
                table: "PSUs",
                column: "ComputerId",
                unique: true,
                filter: "[ComputerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Mice_ComputerId",
                table: "Mice",
                column: "ComputerId",
                unique: true,
                filter: "[ComputerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Keyboards_ComputerId",
                table: "Keyboards",
                column: "ComputerId",
                unique: true,
                filter: "[ComputerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Headsets_ComputerId",
                table: "Headsets",
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
                name: "IX_CPUCoolers_ComputerId",
                table: "CPUCoolers",
                column: "ComputerId",
                unique: true,
                filter: "[ComputerId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Computers_MotherboardId",
                table: "Computers",
                column: "MotherboardId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ComputerId",
                table: "Cases",
                column: "ComputerId",
                unique: true,
                filter: "[ComputerId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Motherboards_MotherboardId",
                table: "Computers",
                column: "MotherboardId",
                principalTable: "Motherboards",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CPUCoolers_Computers_ComputerId",
                table: "CPUCoolers",
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
                name: "FK_Headsets_Computers_ComputerId",
                table: "Headsets",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Keyboards_Computers_ComputerId",
                table: "Keyboards",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mice_Computers_ComputerId",
                table: "Mice",
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
                name: "FK_Computers_Motherboards_MotherboardId",
                table: "Computers");

            migrationBuilder.DropForeignKey(
                name: "FK_CPUCoolers_Computers_ComputerId",
                table: "CPUCoolers");

            migrationBuilder.DropForeignKey(
                name: "FK_CPUs_Computers_ComputerId",
                table: "CPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_Headsets_Computers_ComputerId",
                table: "Headsets");

            migrationBuilder.DropForeignKey(
                name: "FK_Keyboards_Computers_ComputerId",
                table: "Keyboards");

            migrationBuilder.DropForeignKey(
                name: "FK_Mice_Computers_ComputerId",
                table: "Mice");

            migrationBuilder.DropForeignKey(
                name: "FK_PSUs_Computers_ComputerId",
                table: "PSUs");

            migrationBuilder.DropIndex(
                name: "IX_PSUs_ComputerId",
                table: "PSUs");

            migrationBuilder.DropIndex(
                name: "IX_Mice_ComputerId",
                table: "Mice");

            migrationBuilder.DropIndex(
                name: "IX_Keyboards_ComputerId",
                table: "Keyboards");

            migrationBuilder.DropIndex(
                name: "IX_Headsets_ComputerId",
                table: "Headsets");

            migrationBuilder.DropIndex(
                name: "IX_CPUs_ComputerId",
                table: "CPUs");

            migrationBuilder.DropIndex(
                name: "IX_CPUCoolers_ComputerId",
                table: "CPUCoolers");

            migrationBuilder.DropIndex(
                name: "IX_Computers_MotherboardId",
                table: "Computers");

            migrationBuilder.DropIndex(
                name: "IX_Cases_ComputerId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "ComputerId",
                table: "Mice");

            migrationBuilder.DropColumn(
                name: "ComputerId",
                table: "Keyboards");

            migrationBuilder.DropColumn(
                name: "ComputerId",
                table: "Headsets");

            migrationBuilder.DropColumn(
                name: "ComputerId",
                table: "CPUs");

            migrationBuilder.DropColumn(
                name: "ComputerId",
                table: "CPUCoolers");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "PSUs",
                newName: "PSUId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Motherboards",
                newName: "MotherboardId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Mice",
                newName: "MouseId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Keyboards",
                newName: "KeyboardId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Headsets",
                newName: "HeadsetId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "CPUs",
                newName: "CPUId");

            migrationBuilder.AddColumn<int>(
                name: "ComputerId1",
                table: "PSUs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CPUCoolerId",
                table: "CPUCoolers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "Id",
                table: "Computers",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "CaseId",
                table: "Cases",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PSUs_ComputerId1",
                table: "PSUs",
                column: "ComputerId1");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ComputerId",
                table: "Cases",
                column: "ComputerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_CPUCoolers_Id",
                table: "Computers",
                column: "Id",
                principalTable: "CPUCoolers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_CPUs_Id",
                table: "Computers",
                column: "Id",
                principalTable: "CPUs",
                principalColumn: "CPUId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Cases_Id",
                table: "Computers",
                column: "Id",
                principalTable: "Cases",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Headsets_Id",
                table: "Computers",
                column: "Id",
                principalTable: "Headsets",
                principalColumn: "HeadsetId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Keyboards_Id",
                table: "Computers",
                column: "Id",
                principalTable: "Keyboards",
                principalColumn: "KeyboardId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Mice_Id",
                table: "Computers",
                column: "Id",
                principalTable: "Mice",
                principalColumn: "MouseId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_Motherboards_Id",
                table: "Computers",
                column: "Id",
                principalTable: "Motherboards",
                principalColumn: "MotherboardId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Computers_PSUs_Id",
                table: "Computers",
                column: "Id",
                principalTable: "PSUs",
                principalColumn: "PSUId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PSUs_Computers_ComputerId1",
                table: "PSUs",
                column: "ComputerId1",
                principalTable: "Computers",
                principalColumn: "Id");
        }
    }
}
