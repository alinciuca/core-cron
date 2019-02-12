using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Cron.Data.Migrations
{
    public partial class RemovedColumnAndAdjustedView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropColumn(
                name: "UpdateFrequency",
                table: "Service");

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
										   WHERE        (s.ServiceId = ServiceId) order by LastUpdate desc) AS LastUpdate,
										   (select top 1
											DATEDIFF(HH, h1.LastUpdate, MIN(h2.LastUpdate)) as HoursDiff
											from Heartbeat h1
											inner join Heartbeat h2 on h1.ServiceId = h2.ServiceId and h2.LastUpdate > h1.LastUpdate
											group by h1.ServiceId, h1.LastUpdate 
											order by h1.LastUpdate desc) as UpdateFrequencyInHours
			FROM            dbo.Service AS s
			GO");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<TimeSpan>(
                name: "UpdateFrequency",
                table: "Service",
                nullable: true);

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
    }
}
