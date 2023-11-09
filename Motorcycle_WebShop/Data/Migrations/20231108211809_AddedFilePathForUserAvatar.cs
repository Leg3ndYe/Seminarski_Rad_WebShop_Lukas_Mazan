using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Motorcycle_WebShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedFilePathForUserAvatar : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "FilePath",
                table: "UserAvatar",
                newName: "AvatarFilePath");

            migrationBuilder.AddColumn<string>(
                name: "AvatarFilePath",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvatarFilePath",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "AvatarFilePath",
                table: "UserAvatar",
                newName: "FilePath");
        }
    }
}
