using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Housing.Migrations
{
    /// <inheritdoc />
    public partial class AddIsReadOnlyToFurniture : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ImagePath",
                table: "Furniture",
                newName: "ImageUrl");

            migrationBuilder.AddColumn<bool>(
                name: "IsReadOnly",
                table: "Furniture",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "CartItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FurnitureId = table.Column<int>(type: "int", nullable: false),
                    SessionId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CartItems_Furniture_FurnitureId",
                        column: x => x.FurnitureId,
                        principalTable: "Furniture",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_FurnitureId",
                table: "CartItems",
                column: "FurnitureId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartItems");

            migrationBuilder.DropColumn(
                name: "IsReadOnly",
                table: "Furniture");

            migrationBuilder.RenameColumn(
                name: "ImageUrl",
                table: "Furniture",
                newName: "ImagePath");
        }
    }
}
