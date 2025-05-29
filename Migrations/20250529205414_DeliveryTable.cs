using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Housing.Migrations
{
    /// <inheritdoc />
    public partial class DeliveryTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AveragePrice",
                table: "DeliveryContacts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AveragePrice",
                table: "DeliveryContacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
