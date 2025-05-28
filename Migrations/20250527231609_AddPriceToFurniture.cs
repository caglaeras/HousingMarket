using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Housing.Migrations
{
    /// <inheritdoc />
    public partial class AddPriceToFurniture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImagePath",
                table: "Furniture",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Furniture",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "Furniture",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImagePath",
                table: "Furniture");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Furniture");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "Furniture");
        }
    }
}
