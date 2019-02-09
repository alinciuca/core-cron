using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Cron.Data.Migrations
{
    public partial class AddedServiceNameAndIdentifier : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "eef43fda-a6da-4069-bb77-880046e11859", "0a62dc65-0856-4001-9ec4-e54fe3f500c2" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "0a62dc65-0856-4001-9ec4-e54fe3f500c2", "437fccf1-87a4-4ae0-953c-0feff187552f" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "eef43fda-a6da-4069-bb77-880046e11859", "c7f772ce-0385-4138-8ff3-6b413ac6ccbc" });

            migrationBuilder.AlterColumn<string>(
                name: "ServiceIdentifier",
                table: "Service",
                unicode: false,
                maxLength: 40,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 500);

            migrationBuilder.AddColumn<string>(
                name: "ServiceName",
                table: "Service",
                unicode: false,
                maxLength: 500,
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.CreateIndex(
                name: "UK_ServiceName_ServiceIdentifier",
                table: "Service",
                columns: new[] { "ServiceName", "ServiceIdentifier" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "UK_Heartbeat_Service",
                table: "Heartbeat",
                columns: new[] { "HeartbeatId", "ServiceId" },
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UK_ServiceName_ServiceIdentifier",
                table: "Service");

            migrationBuilder.DropIndex(
                name: "UK_Heartbeat_Service",
                table: "Heartbeat");

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

            migrationBuilder.DropColumn(
                name: "ServiceName",
                table: "Service");

            migrationBuilder.AlterColumn<string>(
                name: "ServiceIdentifier",
                table: "Service",
                unicode: false,
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldUnicode: false,
                oldMaxLength: 40);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "0a62dc65-0856-4001-9ec4-e54fe3f500c2", "437fccf1-87a4-4ae0-953c-0feff187552f", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "eef43fda-a6da-4069-bb77-880046e11859", 0, "c7f772ce-0385-4138-8ff3-6b413ac6ccbc", "su@a.co", true, false, null, "SU@A.CO", "SU@A.CO", "AQAAAAEAACcQAAAAEDPh/9TXtg5lv5qsYzSuPVWRb5fa9uDaWkqoh9psjtCd86RpCuzC3QAOEa/1fFZKJA==", null, false, "QI52LZEPNK5EOJJX6SYMYXGTLZMA5PSA", false, "su@a.co" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "eef43fda-a6da-4069-bb77-880046e11859", "0a62dc65-0856-4001-9ec4-e54fe3f500c2" });
        }
    }
}
