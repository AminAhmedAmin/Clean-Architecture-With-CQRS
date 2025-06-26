using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuexyBase.Application.Migrations
{
    /// <inheritdoc />
    public partial class updatebaseentitiy : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SubCategorys",
                newName: "NameEn");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Categorys",
                newName: "NameEn");

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "SubCategorys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "SubCategorys",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NameAr",
                table: "Categorys",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Categorys",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "SubCategorys");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "SubCategorys");

            migrationBuilder.DropColumn(
                name: "NameAr",
                table: "Categorys");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Categorys");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "SubCategorys",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "NameEn",
                table: "Categorys",
                newName: "Name");
        }
    }
}
