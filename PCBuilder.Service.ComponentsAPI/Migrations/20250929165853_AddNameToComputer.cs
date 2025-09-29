using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Service.ComponentsAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddNameToComputer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Computers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Computers");
        }
    }
}
