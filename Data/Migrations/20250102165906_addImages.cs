using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class addImages : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ResidentialPlot",
                table: "ResidentialPlot");

            migrationBuilder.RenameTable(
                name: "ResidentialPlot",
                newName: "ResidentialPlots");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResidentialPlots",
                table: "ResidentialPlots",
                column: "ID");

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Path = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ResidentialPlots",
                table: "ResidentialPlots");

            migrationBuilder.RenameTable(
                name: "ResidentialPlots",
                newName: "ResidentialPlot");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ResidentialPlot",
                table: "ResidentialPlot",
                column: "ID");
        }
    }
}
