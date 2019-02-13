using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Cron.Data.Migrations
{
    public partial class RemovedFreqFromService : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "5be53add-d2c1-4490-b502-825ec23c1f35", "e9077ee9-8bc2-4fcf-a727-2fb4925416b5" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "e9077ee9-8bc2-4fcf-a727-2fb4925416b5", "d0f99737-b921-4cbc-8c0a-01a1a72556f0" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "5be53add-d2c1-4490-b502-825ec23c1f35", "bec187e7-b638-4396-8922-1116607be287" });

            migrationBuilder.DropColumn(
                name: "UpdateFrequencyInHours",
                table: "Service");

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<int>(
                name: "UpdateFrequencyInHours",
                table: "Service",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e9077ee9-8bc2-4fcf-a727-2fb4925416b5", "d0f99737-b921-4cbc-8c0a-01a1a72556f0", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "5be53add-d2c1-4490-b502-825ec23c1f35", 0, "bec187e7-b638-4396-8922-1116607be287", "su@a.co", true, false, null, "SU@A.CO", "SU@A.CO", "AQAAAAEAACcQAAAAEDPh/9TXtg5lv5qsYzSuPVWRb5fa9uDaWkqoh9psjtCd86RpCuzC3QAOEa/1fFZKJA==", null, false, "QI52LZEPNK5EOJJX6SYMYXGTLZMA5PSA", false, "su@a.co" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "5be53add-d2c1-4490-b502-825ec23c1f35", "e9077ee9-8bc2-4fcf-a727-2fb4925416b5" });
        }
    }
}
