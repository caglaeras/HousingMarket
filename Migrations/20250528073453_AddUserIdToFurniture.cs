using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Housing.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToFurniture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Furniture");

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Furniture",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Furniture");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Furniture",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
