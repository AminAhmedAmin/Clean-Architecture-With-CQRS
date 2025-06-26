using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VuexyBase.Application.Migrations
{
    /// <inheritdoc />
    public partial class editSettingTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "SenderName",
                table: "Settings",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SenderName",
                table: "Settings");            
        }
    }
}
