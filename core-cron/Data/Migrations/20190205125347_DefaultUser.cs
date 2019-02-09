using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Cron.Data.Migrations
{
    public partial class DefaultUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "8049e69b-b7ec-48b3-b9e3-d0f770e167f2", "361c60f5-9380-4e41-9b33-2932f2dbc498" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "361c60f5-9380-4e41-9b33-2932f2dbc498", "c8d14da5-1260-448e-9d73-eda798cee977" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "8049e69b-b7ec-48b3-b9e3-d0f770e167f2", "2d6b52a7-6576-47e6-9c32-63ea9bb3a979" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bda20fa6-89aa-40f3-9b3b-9efab6a665f3", "8328eaf2-a2c7-419b-a918-bc08dd8f48c0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "0bcc8d38-61e0-434e-9042-3692bf1852dc", 0, "0a139435-255d-4593-a247-ca8210db5bce", "su@a.co", true, false, null, "SU@A.CO", "SU@A.CO", "AQAAAAEAACcQAAAAEDPh/9TXtg5lv5qsYzSuPVWRb5fa9uDaWkqoh9psjtCd86RpCuzC3QAOEa/1fFZKJA==", null, false, "QI52LZEPNK5EOJJX6SYMYXGTLZMA5PSA", false, "su@a.co" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "0bcc8d38-61e0-434e-9042-3692bf1852dc", "bda20fa6-89aa-40f3-9b3b-9efab6a665f3" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "0bcc8d38-61e0-434e-9042-3692bf1852dc", "bda20fa6-89aa-40f3-9b3b-9efab6a665f3" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "bda20fa6-89aa-40f3-9b3b-9efab6a665f3", "8328eaf2-a2c7-419b-a918-bc08dd8f48c0" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "0bcc8d38-61e0-434e-9042-3692bf1852dc", "0a139435-255d-4593-a247-ca8210db5bce" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "361c60f5-9380-4e41-9b33-2932f2dbc498", "c8d14da5-1260-448e-9d73-eda798cee977", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "8049e69b-b7ec-48b3-b9e3-d0f770e167f2", 0, "2d6b52a7-6576-47e6-9c32-63ea9bb3a979", "su@a.co", true, false, null, "SU@A.CO", "SU@A.CO", "AQAAAAEAACcQAAAAEDPh/9TXtg5lv5qsYzSuPVWRb5fa9uDaWkqoh9psjtCd86RpCuzC3QAOEa/1fFZKJA==", null, false, "QI52LZEPNK5EOJJX6SYMYXGTLZMA5PSA", false, "su@a.co" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "8049e69b-b7ec-48b3-b9e3-d0f770e167f2", "361c60f5-9380-4e41-9b33-2932f2dbc498" });
        }
    }
}
