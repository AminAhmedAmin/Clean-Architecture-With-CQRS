using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuexyBase.Application.Migrations
{
    /// <inheritdoc />
    public partial class editcategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_SubCategorys_SubcategoryId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategorys_Categorys_CategoryId",
                table: "SubCategorys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategorys",
                table: "SubCategorys");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categorys",
                table: "Categorys");

            migrationBuilder.RenameTable(
                name: "SubCategorys",
                newName: "SubCategories");

            migrationBuilder.RenameTable(
                name: "Categorys",
                newName: "Categories");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategorys_CategoryId",
                table: "SubCategories",
                newName: "IX_SubCategories_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategories",
                table: "SubCategories",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categories",
                table: "Categories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_SubCategories_SubcategoryId",
                table: "Orders",
                column: "SubcategoryId",
                principalTable: "SubCategories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_SubCategories_SubcategoryId",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_SubCategories_Categories_CategoryId",
                table: "SubCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SubCategories",
                table: "SubCategories");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Categories",
                table: "Categories");

            migrationBuilder.RenameTable(
                name: "SubCategories",
                newName: "SubCategorys");

            migrationBuilder.RenameTable(
                name: "Categories",
                newName: "Categorys");

            migrationBuilder.RenameIndex(
                name: "IX_SubCategories_CategoryId",
                table: "SubCategorys",
                newName: "IX_SubCategorys_CategoryId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SubCategorys",
                table: "SubCategorys",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Categorys",
                table: "Categorys",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_SubCategorys_SubcategoryId",
                table: "Orders",
                column: "SubcategoryId",
                principalTable: "SubCategorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SubCategorys_Categorys_CategoryId",
                table: "SubCategorys",
                column: "CategoryId",
                principalTable: "Categorys",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
