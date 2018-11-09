using Microsoft.EntityFrameworkCore.Migrations;

namespace RummageSale.Migrations
{
    public partial class changedsaletable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Clothings",
                table: "Sale",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Electronics",
                table: "Sale",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Furniture",
                table: "Sale",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Toys",
                table: "Sale",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Clothings",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "Electronics",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "Furniture",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "Toys",
                table: "Sale");
        }
    }
}
