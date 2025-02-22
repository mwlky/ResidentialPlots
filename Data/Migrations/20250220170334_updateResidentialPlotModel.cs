using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class updateResidentialPlotModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ResidentialPlots",
                keyColumn: "ID",
                keyValue: 1);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ResidentialPlots",
                columns: new[] { "ID", "Description", "Location", "Name", "Price", "Size" },
                values: new object[] { 1, "Test", "Warszawa", "Test", 999, 1000 });
        }
    }
}
