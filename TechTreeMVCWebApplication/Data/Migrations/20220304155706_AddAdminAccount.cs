using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TechTreeMVCWebApplication.Data.Migrations
{
    public partial class AddAdminAccount : Migration
    {
        const string ADMIN_USER_GUID = "b3ce191d-631d-4db8-8569-ddddf2ad55fc";
        const string ADMIN_ROLE_GUID = "bd4d4434-10ac-4f89-b933-5ba85400de1f";
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var hasher = new PasswordHasher<ApplicationUser>();
            var passwordHash = hasher.HashPassword(null, "Password100!");
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("INSERT INTO AspNetUsers(Id, UserName, NormalizedUserName, Email, EmailConfirmed,PhoneNumberConfirmed,TwoFactorEnabled,LockoutEnabled, AccessFailedCount, NormalizedEmail, PasswordHash, SecurityStamp,FirstName)");
            sb.AppendLine("VALUES(");
            sb.AppendLine($"'{ADMIN_USER_GUID}'");
            sb.AppendLine(",'mourismagdy@learn.com'");
            sb.AppendLine(",'MOURISMAGDY@LEARN.COM'");
            sb.AppendLine(",'mourismagdy@learn.com'");
            sb.AppendLine(",0");
            sb.AppendLine(",0");
            sb.AppendLine(",0");
            sb.AppendLine(",0");
            sb.AppendLine(",0");
            sb.AppendLine(",'MOURISMAGDY@LEARN.COM'");
            sb.AppendLine($",'{passwordHash}'");
            sb.AppendLine(",''");
            sb.AppendLine(",'Admin'");
            sb.AppendLine(")");

            migrationBuilder.Sql(sb.ToString());
            migrationBuilder.Sql($"INSERT INTO AspNetRoles (Id,Name,NormalizedName) VALUES ('{ADMIN_ROLE_GUID}','admin','ADMIN')");
            migrationBuilder.Sql($"INSERT INTO AspNetUserRoles (UserId,RoleId) VALUES ('{ADMIN_USER_GUID}','{ADMIN_ROLE_GUID}')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql($"DELETE FROM AspNetUserRoles WHERE UserId='{ADMIN_USER_GUID}' AND RoleId='{ADMIN_ROLE_GUID}'");
            migrationBuilder.Sql($"DELETE FROM AspNetUsers WHERE Id='{ADMIN_USER_GUID}'");
            migrationBuilder.Sql($"DELETE FROM AspNetRoles WHERE Id='{ADMIN_ROLE_GUID}'");

        }
    }
}
