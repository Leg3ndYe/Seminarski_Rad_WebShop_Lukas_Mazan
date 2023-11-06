using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;
using System.Text;

#nullable disable

namespace Motorcycle_WebShop.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddAdminAccount : Migration
    {
        const string ADMIN_USER_GUID = "9f352e39-720a-4fea-9401-e73f92284770";
        const string ADMIN_ROLE_GUID = "446c8083-98b5-4251-a368-7e5ce85b0797";

        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();

            var passwordhash = hasher.HashPassword(null, "HashPass123!");

            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO AspNetUsers (Id, " +
                                                    "UserName, " +
                                                    "NormalizedUserName, " +
                                                    "Email, " +
                                                    "NormalizedEmail, " +
                                                    "EmailConfirmed, " +
                                                    "PasswordHash, " +
                                                    "SecurityStamp, " +
                                                    "PhoneNumber, " +
                                                    "PhoneNumberConfirmed, " +
                                                    "TwoFactorEnabled, " +
                                                    "LockoutEnabled, " +
                                                    "AccessFailedCount, " +
                                                    "Address, " +
                                                    "City, " +
                                                    "Country, " +
                                                    "FirstName, " +
                                                    "LastName, " +
                                                    "PostalCode) ");

            sb.AppendLine("VALUES(");
            sb.AppendLine($"'{ADMIN_USER_GUID}',");
            sb.AppendLine($"'admin@admin.com',");
            sb.AppendLine($"'ADMIN@ADMIN.COM',");
            sb.AppendLine($"'admin@admin.com',");
            sb.AppendLine($"'ADMIN@ADMIN.COM',");
            sb.AppendLine($"0,");
            sb.AppendLine($"'{passwordhash}',");
            sb.AppendLine($"'Admin',");
            sb.AppendLine($"'+385981234567',");
            sb.AppendLine($"1,");
            sb.AppendLine($"0,");
            sb.AppendLine($"0,");
            sb.AppendLine($"0,");
            sb.AppendLine($"'Slavonska avenija 55',");
            sb.AppendLine($"'Zagreb',");
            sb.AppendLine($"'Croatia',");
            sb.AppendLine($"'Rudolf',");
            sb.AppendLine($"'Wendigo',");
            sb.AppendLine($"'10132'");
            sb.AppendLine(")");

            migrationBuilder.Sql(sb.ToString());

            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id, Name, NormalizedName) " +
                                $"VALUES ('{ADMIN_ROLE_GUID}', 'Admin', 'ADMIN')");

            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles (UserId, RoleId)" +
                                $"VALUES ('{ADMIN_USER_GUID}', '{ADMIN_ROLE_GUID}')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHERE UserId = '{ADMIN_USER_GUID}' AND RoleId = '{ADMIN_ROLE_GUID}'");

            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id = '{ADMIN_USER_GUID}'");

            migrationBuilder.Sql($"DELTE FROM AspNetUsers WHERE Id = '{ADMIN_USER_GUID}'");
        }
    }
}
