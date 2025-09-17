using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Service.ComponentsAPI.Migrations
{
    /// <inheritdoc />
    public partial class components3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CompatibleSockets",
                table: "CPUCoolers");

            migrationBuilder.AddColumn<string>(
                name: "FormFactor",
                table: "Cases",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.DropColumn(
                name: "FormFactor",
                table: "Cases");

            migrationBuilder.AddColumn<string>(
                name: "CompatibleSockets",
                table: "CPUCoolers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
