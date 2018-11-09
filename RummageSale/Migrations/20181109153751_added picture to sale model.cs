using Microsoft.EntityFrameworkCore.Migrations;

namespace RummageSale.Migrations
{
    public partial class addedpicturetosalemodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Picture",
                table: "Sale",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Picture",
                table: "Sale");
        }
    }
}
