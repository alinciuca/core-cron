using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Cron.Data.Migrations
{
    public partial class ChangedToDateTimeOffset : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "b7ad2e72-2122-4e38-8179-cf59ea0335e0", "2586fdfa-c3b1-4c14-b258-2a7928bb4d70" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "2586fdfa-c3b1-4c14-b258-2a7928bb4d70", "99f208d9-29fc-473c-b7e0-591dc67c809c" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "b7ad2e72-2122-4e38-8179-cf59ea0335e0", "65b36da9-5e76-41dc-9925-7d04b8dab02f" });

            migrationBuilder.AlterColumn<DateTimeOffset>(
                name: "DateAdded",
                table: "Service",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<TimeSpan>(
                name: "UpdateFrequency",
                table: "Service",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "7cfe886c-208c-432f-ada5-4d8d27f30cb6", "4bc8069a-910e-41cd-b807-cb002470e267", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d5b5ed59-b050-4287-bb9b-6c65356cbdc9", 0, "70f9660f-0047-45d5-b7c7-bbaa891e4c79", "su@a.co", true, false, null, "SU@A.CO", "SU@A.CO", "AQAAAAEAACcQAAAAEDPh/9TXtg5lv5qsYzSuPVWRb5fa9uDaWkqoh9psjtCd86RpCuzC3QAOEa/1fFZKJA==", null, false, "QI52LZEPNK5EOJJX6SYMYXGTLZMA5PSA", false, "su@a.co" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "d5b5ed59-b050-4287-bb9b-6c65356cbdc9", "7cfe886c-208c-432f-ada5-4d8d27f30cb6" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d5b5ed59-b050-4287-bb9b-6c65356cbdc9", "7cfe886c-208c-432f-ada5-4d8d27f30cb6" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "7cfe886c-208c-432f-ada5-4d8d27f30cb6", "4bc8069a-910e-41cd-b807-cb002470e267" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "d5b5ed59-b050-4287-bb9b-6c65356cbdc9", "70f9660f-0047-45d5-b7c7-bbaa891e4c79" });

            migrationBuilder.DropColumn(
                name: "UpdateFrequency",
                table: "Service");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Service",
                nullable: false,
                oldClrType: typeof(DateTimeOffset));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2586fdfa-c3b1-4c14-b258-2a7928bb4d70", "99f208d9-29fc-473c-b7e0-591dc67c809c", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b7ad2e72-2122-4e38-8179-cf59ea0335e0", 0, "65b36da9-5e76-41dc-9925-7d04b8dab02f", "su@a.co", true, false, null, "SU@A.CO", "SU@A.CO", "AQAAAAEAACcQAAAAEDPh/9TXtg5lv5qsYzSuPVWRb5fa9uDaWkqoh9psjtCd86RpCuzC3QAOEa/1fFZKJA==", null, false, "QI52LZEPNK5EOJJX6SYMYXGTLZMA5PSA", false, "su@a.co" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "b7ad2e72-2122-4e38-8179-cf59ea0335e0", "2586fdfa-c3b1-4c14-b258-2a7928bb4d70" });
        }
    }
}
