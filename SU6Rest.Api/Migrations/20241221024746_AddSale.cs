using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SU6Rest.Api.Migrations
{
    /// <inheritdoc />
    public partial class AddSale : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sale",
                columns: table => new
                {
                    SaleId = table.Column<Guid>(type: "uuid", nullable: false),
                    CustomerId = table.Column<Guid>(type: "uuid", nullable: false),
                    InvoiceNumber = table.Column<string>(type: "character varying(12)", maxLength: 12, nullable: false),
                    IssueDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Total = table.Column<double>(type: "double precision", nullable: false),
                    Discount = table.Column<int>(type: "integer", nullable: false),
                    GrandTotal = table.Column<double>(type: "double precision", nullable: false),
                    CategoryId = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sale", x => x.SaleId);
                    table.ForeignKey(
                        name: "FK_Sale_Categopry_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categopry",
                        principalColumn: "CategoryId");
                });

            migrationBuilder.CreateTable(
                name: "SaleDetail",
                columns: table => new
                {
                    SaleDetailId = table.Column<Guid>(type: "uuid", nullable: false),
                    SaleId = table.Column<Guid>(type: "uuid", nullable: false),
                    ItemId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<double>(type: "double precision", nullable: false),
                    Qty = table.Column<int>(type: "integer", nullable: false),
                    Total = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SaleDetail", x => x.SaleDetailId);
                    table.ForeignKey(
                        name: "FK_SaleDetail_Item_ItemId",
                        column: x => x.ItemId,
                        principalTable: "Item",
                        principalColumn: "ItemId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SaleDetail_Sale_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sale",
                        principalColumn: "SaleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sale_CategoryId",
                table: "Sale",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_ItemId",
                table: "SaleDetail",
                column: "ItemId");

            migrationBuilder.CreateIndex(
                name: "IX_SaleDetail_SaleId",
                table: "SaleDetail",
                column: "SaleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SaleDetail");

            migrationBuilder.DropTable(
                name: "Sale");
        }
    }
}
