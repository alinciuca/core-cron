using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Cron.Data.Migrations
{
	public partial class AddedServicesView : Migration
	{
		protected override void Up(MigrationBuilder migrationBuilder)
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

		protected override void Down(MigrationBuilder migrationBuilder)
		{
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
				values: new object[] { "7cfe886c-208c-432f-ada5-4d8d27f30cb6", "4bc8069a-910e-41cd-b807-cb002470e267", "Admin", "ADMIN" });

			migrationBuilder.InsertData(
				table: "AspNetUsers",
				columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
				values: new object[] { "d5b5ed59-b050-4287-bb9b-6c65356cbdc9", 0, "70f9660f-0047-45d5-b7c7-bbaa891e4c79", "su@a.co", true, false, null, "SU@A.CO", "SU@A.CO", "AQAAAAEAACcQAAAAEDPh/9TXtg5lv5qsYzSuPVWRb5fa9uDaWkqoh9psjtCd86RpCuzC3QAOEa/1fFZKJA==", null, false, "QI52LZEPNK5EOJJX6SYMYXGTLZMA5PSA", false, "su@a.co" });

			migrationBuilder.InsertData(
				table: "AspNetUserRoles",
				columns: new[] { "UserId", "RoleId" },
				values: new object[] { "d5b5ed59-b050-4287-bb9b-6c65356cbdc9", "7cfe886c-208c-432f-ada5-4d8d27f30cb6" });

			migrationBuilder.Sql(@"
			IF EXISTS(select * from sys.views where name = 'vw_Service')
				BEGIN
					DROP VIEW vw_Service
				END
			GO");
		}
	}
}
