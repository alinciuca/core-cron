using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Cron.Data.Migrations
{
    public partial class RemovedRedundandIndex : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UK_Heartbeat_Service",
                table: "Heartbeat");

            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "b3e6df94-1c83-4456-94cd-dfac3fa48e52", "f0e92b17-b598-4b8e-91c3-223cff57af01" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "f0e92b17-b598-4b8e-91c3-223cff57af01", "4b60a746-3d17-4262-b874-c6ac7626e2d3" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "b3e6df94-1c83-4456-94cd-dfac3fa48e52", "800aae8e-0743-4120-849b-50010fc17792" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e58ee605-6085-45b7-86a2-55d9d7552a4f", "0ebf07a9-2f0b-4ad7-9c88-7f61f1d231f3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "217d93db-bdad-4014-84d8-9d1f2934039d", 0, "494d7895-208f-41e6-a83c-f4be143a4f84", "su@a.co", true, false, null, "SU@A.CO", "SU@A.CO", "AQAAAAEAACcQAAAAEDPh/9TXtg5lv5qsYzSuPVWRb5fa9uDaWkqoh9psjtCd86RpCuzC3QAOEa/1fFZKJA==", null, false, "QI52LZEPNK5EOJJX6SYMYXGTLZMA5PSA", false, "su@a.co" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "217d93db-bdad-4014-84d8-9d1f2934039d", "e58ee605-6085-45b7-86a2-55d9d7552a4f" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "217d93db-bdad-4014-84d8-9d1f2934039d", "e58ee605-6085-45b7-86a2-55d9d7552a4f" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "e58ee605-6085-45b7-86a2-55d9d7552a4f", "0ebf07a9-2f0b-4ad7-9c88-7f61f1d231f3" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "217d93db-bdad-4014-84d8-9d1f2934039d", "494d7895-208f-41e6-a83c-f4be143a4f84" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "f0e92b17-b598-4b8e-91c3-223cff57af01", "4b60a746-3d17-4262-b874-c6ac7626e2d3", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b3e6df94-1c83-4456-94cd-dfac3fa48e52", 0, "800aae8e-0743-4120-849b-50010fc17792", "su@a.co", true, false, null, "SU@A.CO", "SU@A.CO", "AQAAAAEAACcQAAAAEDPh/9TXtg5lv5qsYzSuPVWRb5fa9uDaWkqoh9psjtCd86RpCuzC3QAOEa/1fFZKJA==", null, false, "QI52LZEPNK5EOJJX6SYMYXGTLZMA5PSA", false, "su@a.co" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "b3e6df94-1c83-4456-94cd-dfac3fa48e52", "f0e92b17-b598-4b8e-91c3-223cff57af01" });

            migrationBuilder.CreateIndex(
                name: "UK_Heartbeat_Service",
                table: "Heartbeat",
                columns: new[] { "HeartbeatId", "ServiceId" },
                unique: true);
        }
    }
}
