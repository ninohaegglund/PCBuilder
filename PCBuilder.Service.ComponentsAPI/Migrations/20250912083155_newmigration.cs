using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PCBuilder.Service.ComponentsAPI.Migrations
{
    /// <inheritdoc />
    public partial class newmigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "CaseFans",
                columns: new[] { "Id", "ComputerId", "CoolingCapacityW", "FanSizeMm", "Manufacturer", "ModelName", "Rpm" },
                values: new object[] { 1, null, 40, 120, "Noctua", "Noctua NF-A12x25 PWM", 2000 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CaseFans",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}
