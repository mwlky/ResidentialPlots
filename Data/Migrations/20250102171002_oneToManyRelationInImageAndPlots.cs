using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class oneToManyRelationInImageAndPlots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "Images",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<int>(
                name: "ResidentialPlotID",
                table: "Images",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "Images",
                type: "TEXT",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Images_ResidentialPlotID",
                table: "Images",
                column: "ResidentialPlotID");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_ResidentialPlots_ResidentialPlotID",
                table: "Images",
                column: "ResidentialPlotID",
                principalTable: "ResidentialPlots",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_ResidentialPlots_ResidentialPlotID",
                table: "Images");

            migrationBuilder.DropIndex(
                name: "IX_Images_ResidentialPlotID",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "ResidentialPlotID",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "Path",
                table: "Images",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);
        }
    }
}
