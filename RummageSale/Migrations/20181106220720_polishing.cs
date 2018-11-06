using Microsoft.EntityFrameworkCore.Migrations;

namespace RummageSale.Migrations
{
    public partial class polishing : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RummageUser_Sale_SaleId",
                table: "RummageUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Category_categoryElectronics",
                table: "Sale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sale",
                table: "Sale");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category",
                table: "Category");

            migrationBuilder.RenameTable(
                name: "Sale",
                newName: "Sale_1");

            migrationBuilder.RenameTable(
                name: "Category",
                newName: "Category_1");

            migrationBuilder.RenameColumn(
                name: "categoryElectronics",
                table: "Sale_1",
                newName: "CategoryElectronics");

            migrationBuilder.RenameIndex(
                name: "IX_Sale_categoryElectronics",
                table: "Sale_1",
                newName: "IX_Sale_1_CategoryElectronics");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sale_1",
                table: "Sale_1",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category_1",
                table: "Category_1",
                column: "Electronics");

            migrationBuilder.AddForeignKey(
                name: "FK_RummageUser_Sale_1_SaleId",
                table: "RummageUser",
                column: "SaleId",
                principalTable: "Sale_1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_1_Category_1_CategoryElectronics",
                table: "Sale_1",
                column: "CategoryElectronics",
                principalTable: "Category_1",
                principalColumn: "Electronics",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RummageUser_Sale_1_SaleId",
                table: "RummageUser");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_1_Category_1_CategoryElectronics",
                table: "Sale_1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Sale_1",
                table: "Sale_1");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Category_1",
                table: "Category_1");

            migrationBuilder.RenameTable(
                name: "Sale_1",
                newName: "Sale");

            migrationBuilder.RenameTable(
                name: "Category_1",
                newName: "Category");

            migrationBuilder.RenameColumn(
                name: "CategoryElectronics",
                table: "Sale",
                newName: "categoryElectronics");

            migrationBuilder.RenameIndex(
                name: "IX_Sale_1_CategoryElectronics",
                table: "Sale",
                newName: "IX_Sale_categoryElectronics");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sale",
                table: "Sale",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Electronics");

            migrationBuilder.AddForeignKey(
                name: "FK_RummageUser_Sale_SaleId",
                table: "RummageUser",
                column: "SaleId",
                principalTable: "Sale",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Category_categoryElectronics",
                table: "Sale",
                column: "categoryElectronics",
                principalTable: "Category",
                principalColumn: "Electronics",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
