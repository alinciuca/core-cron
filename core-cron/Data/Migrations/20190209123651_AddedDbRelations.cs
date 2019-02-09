using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Core.Cron.Data.Migrations
{
    public partial class AddedDbRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.CreateTable(
                name: "Service",
                columns: table => new
                {
                    ServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServiceIdentifier = table.Column<string>(unicode: false, maxLength: 500, nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Service", x => x.ServiceId);
                });

            migrationBuilder.CreateTable(
                name: "Heartbeat",
                columns: table => new
                {
                    HeartbeatId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ServiceId = table.Column<int>(nullable: false),
                    LastUpdate = table.Column<DateTime>(nullable: false),
                    RowVersion = table.Column<byte[]>(rowVersion: true, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heartbeat", x => x.HeartbeatId);
                    table.ForeignKey(
                        name: "FK_Heartbeat_Service_ServiceId",
                        column: x => x.ServiceId,
                        principalTable: "Service",
                        principalColumn: "ServiceId",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Heartbeat_ServiceId",
                table: "Heartbeat",
                column: "ServiceId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Heartbeat");

            migrationBuilder.DropTable(
                name: "Service");

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
    }
}
