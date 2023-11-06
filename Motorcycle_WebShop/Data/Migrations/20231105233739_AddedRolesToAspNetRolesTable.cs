using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Motorcycle_WebShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedRolesToAspNetRolesTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "2cd04bd9-83ff-49a3-a1b7-e97a5e9896d9", null, "Secretary", "SECRETARY" },
                    { "4bc6d9be - 018d - 4cd9 - acaa - d855942ee8d9", null, "Chief executive officer", "CHIEF EXECUTIVE OFFICER" },
                    { "811bf54e-ec17-457f-917b-c432d1060070", null, "Moderator", "MODERATOR" },
                    { "edffea81-92bf-4400-84f3-047a9f72cbc7", null, "Support", "SUPPORT" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "2cd04bd9-83ff-49a3-a1b7-e97a5e9896d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "4bc6d9be - 018d - 4cd9 - acaa - d855942ee8d9");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "811bf54e-ec17-457f-917b-c432d1060070");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "edffea81-92bf-4400-84f3-047a9f72cbc7");
        }
    }
}
