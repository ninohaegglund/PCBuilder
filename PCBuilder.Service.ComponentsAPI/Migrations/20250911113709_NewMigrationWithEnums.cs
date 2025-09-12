using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Service.ComponentsAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewMigrationWithEnums : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RefreshRateHz",
                table: "Monitors");

            migrationBuilder.RenameColumn(
                name: "SocketType",
                table: "CPUCoolers",
                newName: "Type");

            migrationBuilder.RenameColumn(
                name: "Material",
                table: "Cases",
                newName: "Manufacturer");

            migrationBuilder.RenameColumn(
                name: "Brand",
                table: "Cases",
                newName: "ChassiMaterial");

            migrationBuilder.AddColumn<string>(
                name: "Hz",
                table: "Monitors",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "GPUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "CPUs",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "CompatibleSockets",
                table: "CPUCoolers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "[]");

            migrationBuilder.AddColumn<string>(
                name: "Manufacturer",
                table: "CPUCoolers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hz",
                table: "Monitors");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "GPUs");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "CPUs");

            migrationBuilder.DropColumn(
                name: "CompatibleSockets",
                table: "CPUCoolers");

            migrationBuilder.DropColumn(
                name: "Manufacturer",
                table: "CPUCoolers");

            migrationBuilder.RenameColumn(
                name: "Type",
                table: "CPUCoolers",
                newName: "SocketType");

            migrationBuilder.RenameColumn(
                name: "Manufacturer",
                table: "Cases",
                newName: "Material");

            migrationBuilder.RenameColumn(
                name: "ChassiMaterial",
                table: "Cases",
                newName: "Brand");

            migrationBuilder.AddColumn<int>(
                name: "RefreshRateHz",
                table: "Monitors",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
