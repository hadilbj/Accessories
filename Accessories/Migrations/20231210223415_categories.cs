using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Accessories.Migrations
{
    public partial class categories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Photo",
                table: "Categories",
                newName: "CategoryPhoto");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categories",
                newName: "CategoryName");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Categories",
                newName: "CategoryDescription");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Categories",
                newName: "CategoryId");

            migrationBuilder.AddColumn<int>(
                name: "CartId",
                table: "Accessories",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CategoryId",
                table: "Accessories",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_CartId",
                table: "Accessories",
                column: "CartId");

            migrationBuilder.CreateIndex(
                name: "IX_Accessories_CategoryId",
                table: "Accessories",
                column: "CategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accessories_Carts_CartId",
                table: "Accessories",
                column: "CartId",
                principalTable: "Carts",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accessories_Categories_CategoryId",
                table: "Accessories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "CategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accessories_Carts_CartId",
                table: "Accessories");

            migrationBuilder.DropForeignKey(
                name: "FK_Accessories_Categories_CategoryId",
                table: "Accessories");

            migrationBuilder.DropIndex(
                name: "IX_Accessories_CartId",
                table: "Accessories");

            migrationBuilder.DropIndex(
                name: "IX_Accessories_CategoryId",
                table: "Accessories");

            migrationBuilder.DropColumn(
                name: "CartId",
                table: "Accessories");

            migrationBuilder.DropColumn(
                name: "CategoryId",
                table: "Accessories");

            migrationBuilder.RenameColumn(
                name: "CategoryPhoto",
                table: "Categories",
                newName: "Photo");

            migrationBuilder.RenameColumn(
                name: "CategoryName",
                table: "Categories",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "CategoryDescription",
                table: "Categories",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "CategoryId",
                table: "Categories",
                newName: "Id");
        }
    }
}
