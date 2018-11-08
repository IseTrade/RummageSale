using Microsoft.EntityFrameworkCore.Migrations;

namespace RummageSale.Migrations
{
    public partial class movedfks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Category_CategoryId",
                table: "Sale");

            migrationBuilder.DropIndex(
                name: "IX_Sale_CategoryId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "CatId",
                table: "Sale");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Sale");

            migrationBuilder.AddColumn<string>(
                name: "SaleId",
                table: "Category",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SaleId1",
                table: "Category",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Category_SaleId1",
                table: "Category",
                column: "SaleId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Category_Sale_SaleId1",
                table: "Category",
                column: "SaleId1",
                principalTable: "Sale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Category_Sale_SaleId1",
                table: "Category");

            migrationBuilder.DropIndex(
                name: "IX_Category_SaleId1",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "SaleId",
                table: "Category");

            migrationBuilder.DropColumn(
                name: "SaleId1",
                table: "Category");

            migrationBuilder.AddColumn<string>(
                name: "CatId",
                table: "Sale",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Sale",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Sale_CategoryId",
                table: "Sale",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Category_CategoryId",
                table: "Sale",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
