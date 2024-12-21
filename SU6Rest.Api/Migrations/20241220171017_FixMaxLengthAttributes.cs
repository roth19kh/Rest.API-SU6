using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SU6Rest.Api.Migrations
{
    /// <inheritdoc />
    public partial class FixMaxLengthAttributes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ItemName",
                table: "Item");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Item",
                type: "character varying(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Item");

            migrationBuilder.AddColumn<string>(
                name: "ItemName",
                table: "Item",
                type: "text",
                nullable: false,
                defaultValue: "");
        }
    }
}
