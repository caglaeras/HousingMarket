using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Housing.Migrations
{
    /// <inheritdoc />
    public partial class AddIsFavoritedToFurniture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsFavorited",
                table: "Furniture",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsFavorited",
                table: "Furniture");
        }
    }
}
