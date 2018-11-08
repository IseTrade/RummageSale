using Microsoft.EntityFrameworkCore.Migrations;

namespace RummageSale.Migrations
{
    public partial class addedmorepropertiesinsalemodeltable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "Sale",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Sale",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Sale",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "Sale",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PriceRange",
                table: "Sale",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "State",
                table: "Sale",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Zipcode",
                table: "Sale",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "PriceRange",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "State",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "Zipcode",
                table: "Sale");
        }
    }
}
