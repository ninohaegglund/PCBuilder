using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Service.ComponentsAPI.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cases_Colors_ColorId",
                table: "Cases");

            migrationBuilder.DropForeignKey(
                name: "FK_ChassiCooling_Colors_ColorId",
                table: "ChassiCooling");

            migrationBuilder.DropForeignKey(
                name: "FK_CPUCoolers_Colors_ColorId",
                table: "CPUCoolers");

            migrationBuilder.DropForeignKey(
                name: "FK_ExternalStorages_Colors_ColorId",
                table: "ExternalStorages");

            migrationBuilder.DropForeignKey(
                name: "FK_FanControllers_Colors_ColorId",
                table: "FanControllers");

            migrationBuilder.DropForeignKey(
                name: "FK_GPUs_Colors_ColorId",
                table: "GPUs");

            migrationBuilder.DropForeignKey(
                name: "FK_Headsets_Colors_ColorId",
                table: "Headsets");

            migrationBuilder.DropForeignKey(
                name: "FK_Keyboards_Colors_ColorId",
                table: "Keyboards");

            migrationBuilder.DropForeignKey(
                name: "FK_Mice_Colors_ColorId",
                table: "Mice");

            migrationBuilder.DropForeignKey(
                name: "FK_Motherboards_Colors_ColorId",
                table: "Motherboards");

            migrationBuilder.DropForeignKey(
                name: "FK_PSUs_Colors_ColorId",
                table: "PSUs");

            migrationBuilder.DropForeignKey(
                name: "FK_RAMModules_Colors_ColorId",
                table: "RAMModules");

            migrationBuilder.DropForeignKey(
                name: "FK_Speakers_Colors_ColorId",
                table: "Speakers");

            migrationBuilder.DropTable(
                name: "Colors");

            migrationBuilder.DropIndex(
                name: "IX_Speakers_ColorId",
                table: "Speakers");

            migrationBuilder.DropIndex(
                name: "IX_RAMModules_ColorId",
                table: "RAMModules");

            migrationBuilder.DropIndex(
                name: "IX_PSUs_ColorId",
                table: "PSUs");

            migrationBuilder.DropIndex(
                name: "IX_Motherboards_ColorId",
                table: "Motherboards");

            migrationBuilder.DropIndex(
                name: "IX_Mice_ColorId",
                table: "Mice");

            migrationBuilder.DropIndex(
                name: "IX_Keyboards_ColorId",
                table: "Keyboards");

            migrationBuilder.DropIndex(
                name: "IX_Headsets_ColorId",
                table: "Headsets");

            migrationBuilder.DropIndex(
                name: "IX_GPUs_ColorId",
                table: "GPUs");

            migrationBuilder.DropIndex(
                name: "IX_FanControllers_ColorId",
                table: "FanControllers");

            migrationBuilder.DropIndex(
                name: "IX_ExternalStorages_ColorId",
                table: "ExternalStorages");

            migrationBuilder.DropIndex(
                name: "IX_CPUCoolers_ColorId",
                table: "CPUCoolers");

            migrationBuilder.DropIndex(
                name: "IX_ChassiCooling_ColorId",
                table: "ChassiCooling");

            migrationBuilder.DropIndex(
                name: "IX_Cases_ColorId",
                table: "Cases");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Speakers");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "RAMModules");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "PSUs");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Motherboards");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Mice");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Keyboards");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Headsets");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "GPUs");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "FanControllers");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "ExternalStorages");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "CPUCoolers");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "ChassiCooling");

            migrationBuilder.DropColumn(
                name: "ColorId",
                table: "Cases");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Speakers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "RAMModules",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "PSUs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Motherboards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Mice",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Keyboards",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Headsets",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "GPUs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "FanControllers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "ExternalStorages",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "CPUCoolers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "ChassiCooling",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ColorId",
                table: "Cases",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Speakers_ColorId",
                table: "Speakers",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_RAMModules_ColorId",
                table: "RAMModules",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_PSUs_ColorId",
                table: "PSUs",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Motherboards_ColorId",
                table: "Motherboards",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Mice_ColorId",
                table: "Mice",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Keyboards_ColorId",
                table: "Keyboards",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Headsets_ColorId",
                table: "Headsets",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_GPUs_ColorId",
                table: "GPUs",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_FanControllers_ColorId",
                table: "FanControllers",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ExternalStorages_ColorId",
                table: "ExternalStorages",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_CPUCoolers_ColorId",
                table: "CPUCoolers",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_ChassiCooling_ColorId",
                table: "ChassiCooling",
                column: "ColorId");

            migrationBuilder.CreateIndex(
                name: "IX_Cases_ColorId",
                table: "Cases",
                column: "ColorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cases_Colors_ColorId",
                table: "Cases",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChassiCooling_Colors_ColorId",
                table: "ChassiCooling",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CPUCoolers_Colors_ColorId",
                table: "CPUCoolers",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ExternalStorages_Colors_ColorId",
                table: "ExternalStorages",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FanControllers_Colors_ColorId",
                table: "FanControllers",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_GPUs_Colors_ColorId",
                table: "GPUs",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Headsets_Colors_ColorId",
                table: "Headsets",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Keyboards_Colors_ColorId",
                table: "Keyboards",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Mice_Colors_ColorId",
                table: "Mice",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Motherboards_Colors_ColorId",
                table: "Motherboards",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PSUs_Colors_ColorId",
                table: "PSUs",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RAMModules_Colors_ColorId",
                table: "RAMModules",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Speakers_Colors_ColorId",
                table: "Speakers",
                column: "ColorId",
                principalTable: "Colors",
                principalColumn: "Id");
        }
    }
}
