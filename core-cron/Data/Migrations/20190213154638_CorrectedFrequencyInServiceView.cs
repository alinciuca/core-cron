using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Cron.Data.Migrations
{
    public partial class CorrectedFrequencyInServiceView : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dfee16f6-d8bc-4e6f-a514-46c4d15bc940", "f7b4e14e-3bb0-4bab-aea9-4d696914f9fa", "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "d8a87448-a3a2-4ed4-b9c5-77bc347e2599", 0, "44a53d8d-6035-4afd-8b54-c800846a29cb", "su@a.co", true, false, null, "SU@A.CO", "SU@A.CO", "AQAAAAEAACcQAAAAEDPh/9TXtg5lv5qsYzSuPVWRb5fa9uDaWkqoh9psjtCd86RpCuzC3QAOEa/1fFZKJA==", null, false, "QI52LZEPNK5EOJJX6SYMYXGTLZMA5PSA", false, "su@a.co" });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "d8a87448-a3a2-4ed4-b9c5-77bc347e2599", "dfee16f6-d8bc-4e6f-a514-46c4d15bc940" });

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
											DATEDIFF(MINUTE, h1.LastUpdate, MIN(h2.LastUpdate)) as MinutesDiff
											from Heartbeat h1
											inner join Heartbeat h2 on h1.ServiceId = h2.ServiceId and h2.LastUpdate > h1.LastUpdate
											where h1.ServiceId = s.ServiceId
											group by h1.ServiceId, h1.LastUpdate 
											order by h1.LastUpdate desc) as UpdateFrequencyInMinutes
			FROM            dbo.Service AS s
GO
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUserRoles",
                keyColumns: new[] { "UserId", "RoleId" },
                keyValues: new object[] { "d8a87448-a3a2-4ed4-b9c5-77bc347e2599", "dfee16f6-d8bc-4e6f-a514-46c4d15bc940" });

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "dfee16f6-d8bc-4e6f-a514-46c4d15bc940", "f7b4e14e-3bb0-4bab-aea9-4d696914f9fa" });

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumns: new[] { "Id", "ConcurrencyStamp" },
                keyValues: new object[] { "d8a87448-a3a2-4ed4-b9c5-77bc347e2599", "44a53d8d-6035-4afd-8b54-c800846a29cb" });

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
    }
}
