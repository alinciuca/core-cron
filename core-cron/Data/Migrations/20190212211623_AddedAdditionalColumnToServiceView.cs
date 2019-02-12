using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Cron.Data.Migrations
{
    public partial class AddedAdditionalColumnToServiceView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                values: new object[] { "993a438c-bb7b-4552-a187-62b1c6f4de3e", "7e242f36-8b14-4697-8c0e-10b5e171231e", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b369eee8-3c18-42e2-aeb9-ec6998e044a2", 0, "f7c54f23-8bc7-445e-8765-2bf0d6503ff8", "su@a.co", true, false, null, "SU@A.CO", "SU@A.CO", "AQAAAAEAACcQAAAAEDPh/9TXtg5lv5qsYzSuPVWRb5fa9uDaWkqoh9psjtCd86RpCuzC3QAOEa/1fFZKJA==", null, false, "QI52LZEPNK5EOJJX6SYMYXGTLZMA5PSA", false, "su@a.co" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "b369eee8-3c18-42e2-aeb9-ec6998e044a2", "993a438c-bb7b-4552-a187-62b1c6f4de3e" });

			migrationBuilder.Sql(@"
			IF EXISTS(select * from sys.views where name = 'vw_Service')
				BEGIN
					DROP VIEW vw_Service
				END
				GO

			CREATE VIEW [dbo].[vw_Service]
			AS
			SELECT        ServiceId, ServiceName, ServiceIdentifier, DateAdded, RowVersion, UpdateFrequency,
										 (SELECT        TOP (1) LastUpdate
										   FROM            dbo.Heartbeat AS h
										   WHERE        (s.ServiceId = ServiceId)) AS LastUpdate
			FROM            dbo.Service AS s
			GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "b369eee8-3c18-42e2-aeb9-ec6998e044a2", "993a438c-bb7b-4552-a187-62b1c6f4de3e" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "993a438c-bb7b-4552-a187-62b1c6f4de3e", "7e242f36-8b14-4697-8c0e-10b5e171231e" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "b369eee8-3c18-42e2-aeb9-ec6998e044a2", "f7c54f23-8bc7-445e-8765-2bf0d6503ff8" });

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

			migrationBuilder.Sql(@"
			IF EXISTS(select * from sys.views where name = 'vw_Service')
				BEGIN
					DROP VIEW vw_Service
				END
				GO

			CREATE VIEW [dbo].[vw_Service]
			AS
			SELECT        ServiceId, ServiceName, ServiceIdentifier, DateAdded, RowVersion,
										 (SELECT        TOP (1) LastUpdate
										   FROM            dbo.Heartbeat AS h
										   WHERE        (s.ServiceId = ServiceId)) AS LastUpdate
			FROM            dbo.Service AS s
			GO");
        }
    }
}
