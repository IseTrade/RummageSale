using Microsoft.EntityFrameworkCore.Migrations;

namespace RummageSale.Migrations
{
    public partial class addedanddeletedsomedbsets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_1_Category_1_CategoryId",
                table: "Sale_1");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_1_RummageUser_UserId",
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

            migrationBuilder.RenameIndex(
                name: "IX_Sale_1_UserId",
                table: "Sale",
                newName: "IX_Sale_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Sale_1_CategoryId",
                table: "Sale",
                newName: "IX_Sale_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sale",
                table: "Sale",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category",
                table: "Category",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_Category_CategoryId",
                table: "Sale",
                column: "CategoryId",
                principalTable: "Category",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_RummageUser_UserId",
                table: "Sale",
                column: "UserId",
                principalTable: "RummageUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sale_Category_CategoryId",
                table: "Sale");

            migrationBuilder.DropForeignKey(
                name: "FK_Sale_RummageUser_UserId",
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

            migrationBuilder.RenameIndex(
                name: "IX_Sale_UserId",
                table: "Sale_1",
                newName: "IX_Sale_1_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Sale_CategoryId",
                table: "Sale_1",
                newName: "IX_Sale_1_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Sale_1",
                table: "Sale_1",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Category_1",
                table: "Category_1",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_1_Category_1_CategoryId",
                table: "Sale_1",
                column: "CategoryId",
                principalTable: "Category_1",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Sale_1_RummageUser_UserId",
                table: "Sale_1",
                column: "UserId",
                principalTable: "RummageUser",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
