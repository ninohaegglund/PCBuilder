using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Service.ComponentsAPI.Migrations
{
    /// <inheritdoc />
    public partial class updated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CaseFans_Computers_ComputerId",
                table: "CaseFans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaseFans",
                table: "CaseFans");

            migrationBuilder.RenameTable(
                name: "CaseFans",
                newName: "ChassiCooling");

            migrationBuilder.RenameIndex(
                name: "IX_CaseFans_ComputerId",
                table: "ChassiCooling",
                newName: "IX_ChassiCooling_ComputerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ChassiCooling",
                table: "ChassiCooling",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ChassiCooling_Computers_ComputerId",
                table: "ChassiCooling",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ChassiCooling_Computers_ComputerId",
                table: "ChassiCooling");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ChassiCooling",
                table: "ChassiCooling");

            migrationBuilder.RenameTable(
                name: "ChassiCooling",
                newName: "CaseFans");

            migrationBuilder.RenameIndex(
                name: "IX_ChassiCooling_ComputerId",
                table: "CaseFans",
                newName: "IX_CaseFans_ComputerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaseFans",
                table: "CaseFans",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CaseFans_Computers_ComputerId",
                table: "CaseFans",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id");
        }
    }
}
