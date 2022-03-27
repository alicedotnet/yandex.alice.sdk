namespace Yandex.Alice.Sdk.Demo.SmartHome.Migrations.IdentityServer.PersistedGrantDb;

using System;
using Microsoft.EntityFrameworkCore.Migrations;

/// <summary>
/// Initial migration.
/// </summary>
public partial class InitialPersistedGrantMigration : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "DeviceCodes",
            table => new
            {
                UserCode = table.Column<string>("TEXT", maxLength: 200, nullable: false),
                DeviceCode = table.Column<string>("TEXT", maxLength: 200, nullable: false),
                SubjectId = table.Column<string>("TEXT", maxLength: 200, nullable: true),
                SessionId = table.Column<string>("TEXT", maxLength: 100, nullable: true),
                ClientId = table.Column<string>("TEXT", maxLength: 200, nullable: false),
                Description = table.Column<string>("TEXT", maxLength: 200, nullable: true),
                CreationTime = table.Column<DateTime>("TEXT", nullable: false),
                Expiration = table.Column<DateTime>("TEXT", nullable: false),
                Data = table.Column<string>("TEXT", maxLength: 50000, nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_DeviceCodes", x => x.UserCode);
            });

        migrationBuilder.CreateTable(
            "PersistedGrants",
            table => new
            {
                Key = table.Column<string>("TEXT", maxLength: 200, nullable: false),
                Type = table.Column<string>("TEXT", maxLength: 50, nullable: false),
                SubjectId = table.Column<string>("TEXT", maxLength: 200, nullable: true),
                SessionId = table.Column<string>("TEXT", maxLength: 100, nullable: true),
                ClientId = table.Column<string>("TEXT", maxLength: 200, nullable: false),
                Description = table.Column<string>("TEXT", maxLength: 200, nullable: true),
                CreationTime = table.Column<DateTime>("TEXT", nullable: false),
                Expiration = table.Column<DateTime>("TEXT", nullable: true),
                ConsumedTime = table.Column<DateTime>("TEXT", nullable: true),
                Data = table.Column<string>("TEXT", maxLength: 50000, nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_PersistedGrants", x => x.Key);
            });

        migrationBuilder.CreateIndex(
            "IX_DeviceCodes_DeviceCode",
            "DeviceCodes",
            "DeviceCode",
            unique: true);

        migrationBuilder.CreateIndex(
            "IX_DeviceCodes_Expiration",
            "DeviceCodes",
            "Expiration");

        migrationBuilder.CreateIndex(
            "IX_PersistedGrants_Expiration",
            "PersistedGrants",
            "Expiration");

        migrationBuilder.CreateIndex(
            "IX_PersistedGrants_SubjectId_ClientId_Type",
            "PersistedGrants",
            new[] { "SubjectId", "ClientId", "Type" });

        migrationBuilder.CreateIndex(
            "IX_PersistedGrants_SubjectId_SessionId_Type",
            "PersistedGrants",
            new[] { "SubjectId", "SessionId", "Type" });
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "DeviceCodes");

        migrationBuilder.DropTable(
            "PersistedGrants");
    }
}