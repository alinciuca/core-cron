using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Cron.Data.Migrations
{
    public partial class ChangedFromDateTimeToOffset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "ac786ea7-25a1-4a1a-8e32-0a323abe5c2c", "0a721b51-140b-451c-8c78-2071136ca45c" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "0a721b51-140b-451c-8c78-2071136ca45c", "9cd98e63-6682-4d9c-a216-9ff32738cd5c" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "ac786ea7-25a1-4a1a-8e32-0a323abe5c2c", "d610e1f8-e1ca-4175-8f67-5f6bc70b1ee1" });

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "LastUpdate",
                table: "Heartbeat",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2db302a1-f537-45fe-9caa-acded270c7f0", "6bebf805-bb01-4a76-98d7-416e0841fa03", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "1ba4f783-d416-4f73-b840-86ece38f0330", 0, "9666f58d-80ac-498b-a977-e539649980c0", "su@a.co", true, false, null, "SU@A.CO", "SU@A.CO", "AQAAAAEAACcQAAAAEDPh/9TXtg5lv5qsYzSuPVWRb5fa9uDaWkqoh9psjtCd86RpCuzC3QAOEa/1fFZKJA==", null, false, "QI52LZEPNK5EOJJX6SYMYXGTLZMA5PSA", false, "su@a.co" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "1ba4f783-d416-4f73-b840-86ece38f0330", "2db302a1-f537-45fe-9caa-acded270c7f0" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "1ba4f783-d416-4f73-b840-86ece38f0330", "2db302a1-f537-45fe-9caa-acded270c7f0" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2db302a1-f537-45fe-9caa-acded270c7f0", "6bebf805-bb01-4a76-98d7-416e0841fa03" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "1ba4f783-d416-4f73-b840-86ece38f0330", "9666f58d-80ac-498b-a977-e539649980c0" });

            migrationBuilder.AlterColumn<DateTime>(
                name: "LastUpdate",
                table: "Heartbeat",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0a721b51-140b-451c-8c78-2071136ca45c", "9cd98e63-6682-4d9c-a216-9ff32738cd5c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "ac786ea7-25a1-4a1a-8e32-0a323abe5c2c", 0, "d610e1f8-e1ca-4175-8f67-5f6bc70b1ee1", "su@a.co", true, false, null, "SU@A.CO", "SU@A.CO", "AQAAAAEAACcQAAAAEDPh/9TXtg5lv5qsYzSuPVWRb5fa9uDaWkqoh9psjtCd86RpCuzC3QAOEa/1fFZKJA==", null, false, "QI52LZEPNK5EOJJX6SYMYXGTLZMA5PSA", false, "su@a.co" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "ac786ea7-25a1-4a1a-8e32-0a323abe5c2c", "0a721b51-140b-451c-8c78-2071136ca45c" });
        }
    }
}
