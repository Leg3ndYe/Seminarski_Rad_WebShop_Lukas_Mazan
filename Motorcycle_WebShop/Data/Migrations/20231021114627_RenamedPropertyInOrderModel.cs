using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motorcycle_WebShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class RenamedPropertyInOrderModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order_Order_OrderId",
                table: "Order");

            migrationBuilder.DropIndex(
                name: "IX_Order_OrderId",
                table: "Order");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "Order");

            migrationBuilder.CreateIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderItem_Order_OrderId",
                table: "OrderItem");

            migrationBuilder.DropIndex(
                name: "IX_OrderItem_OrderId",
                table: "OrderItem");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "Order",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Order_OrderId",
                table: "Order",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Order_OrderId",
                table: "Order",
                column: "OrderId",
                principalTable: "Order",
                principalColumn: "Id");
        }
    }
}
