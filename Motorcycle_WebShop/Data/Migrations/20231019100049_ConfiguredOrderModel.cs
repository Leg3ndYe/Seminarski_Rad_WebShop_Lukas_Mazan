using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motorcycle_WebShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class ConfiguredOrderModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShippingAdress",
                table: "Order",
                newName: "ShippingAddress");

            migrationBuilder.RenameColumn(
                name: "BillingAdress",
                table: "Order",
                newName: "BillingAddress");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ShippingAdress",
                table: "Order",
                newName: "ShippingAddress");

            migrationBuilder.RenameColumn(
                name: "BillingAdress",
                table: "Order",
                newName: "BillingAddress");
        }
    }
}
