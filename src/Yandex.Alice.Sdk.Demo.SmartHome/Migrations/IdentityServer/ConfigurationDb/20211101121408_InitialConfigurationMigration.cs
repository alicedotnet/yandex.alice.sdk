namespace Yandex.Alice.Sdk.Demo.SmartHome.Migrations.IdentityServer.ConfigurationDb;

using System;
using Microsoft.EntityFrameworkCore.Migrations;

/// <summary>
/// Initial migration.
/// </summary>
public partial class InitialConfigurationMigration : Migration
{
    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.CreateTable(
            "ApiResources",
            table => new
            {
                Id = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Enabled = table.Column<bool>("INTEGER", nullable: false),
                Name = table.Column<string>("TEXT", maxLength: 200, nullable: false),
                DisplayName = table.Column<string>("TEXT", maxLength: 200, nullable: true),
                Description = table.Column<string>("TEXT", maxLength: 1000, nullable: true),
                AllowedAccessTokenSigningAlgorithms = table.Column<string>("TEXT", maxLength: 100, nullable: true),
                ShowInDiscoveryDocument = table.Column<bool>("INTEGER", nullable: false),
                Created = table.Column<DateTime>("TEXT", nullable: false),
                Updated = table.Column<DateTime>("TEXT", nullable: true),
                LastAccessed = table.Column<DateTime>("TEXT", nullable: true),
                NonEditable = table.Column<bool>("INTEGER", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ApiResources", x => x.Id);
            });

        migrationBuilder.CreateTable(
            "ApiScopes",
            table => new
            {
                Id = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Enabled = table.Column<bool>("INTEGER", nullable: false),
                Name = table.Column<string>("TEXT", maxLength: 200, nullable: false),
                DisplayName = table.Column<string>("TEXT", maxLength: 200, nullable: true),
                Description = table.Column<string>("TEXT", maxLength: 1000, nullable: true),
                Required = table.Column<bool>("INTEGER", nullable: false),
                Emphasize = table.Column<bool>("INTEGER", nullable: false),
                ShowInDiscoveryDocument = table.Column<bool>("INTEGER", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ApiScopes", x => x.Id);
            });

        migrationBuilder.CreateTable(
            "Clients",
            table => new
            {
                Id = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Enabled = table.Column<bool>("INTEGER", nullable: false),
                ClientId = table.Column<string>("TEXT", maxLength: 200, nullable: false),
                ProtocolType = table.Column<string>("TEXT", maxLength: 200, nullable: false),
                RequireClientSecret = table.Column<bool>("INTEGER", nullable: false),
                ClientName = table.Column<string>("TEXT", maxLength: 200, nullable: true),
                Description = table.Column<string>("TEXT", maxLength: 1000, nullable: true),
                ClientUri = table.Column<string>("TEXT", maxLength: 2000, nullable: true),
                LogoUri = table.Column<string>("TEXT", maxLength: 2000, nullable: true),
                RequireConsent = table.Column<bool>("INTEGER", nullable: false),
                AllowRememberConsent = table.Column<bool>("INTEGER", nullable: false),
                AlwaysIncludeUserClaimsInIdToken = table.Column<bool>("INTEGER", nullable: false),
                RequirePkce = table.Column<bool>("INTEGER", nullable: false),
                AllowPlainTextPkce = table.Column<bool>("INTEGER", nullable: false),
                RequireRequestObject = table.Column<bool>("INTEGER", nullable: false),
                AllowAccessTokensViaBrowser = table.Column<bool>("INTEGER", nullable: false),
                FrontChannelLogoutUri = table.Column<string>("TEXT", maxLength: 2000, nullable: true),
                FrontChannelLogoutSessionRequired = table.Column<bool>("INTEGER", nullable: false),
                BackChannelLogoutUri = table.Column<string>("TEXT", maxLength: 2000, nullable: true),
                BackChannelLogoutSessionRequired = table.Column<bool>("INTEGER", nullable: false),
                AllowOfflineAccess = table.Column<bool>("INTEGER", nullable: false),
                IdentityTokenLifetime = table.Column<int>("INTEGER", nullable: false),
                AllowedIdentityTokenSigningAlgorithms = table.Column<string>("TEXT", maxLength: 100, nullable: true),
                AccessTokenLifetime = table.Column<int>("INTEGER", nullable: false),
                AuthorizationCodeLifetime = table.Column<int>("INTEGER", nullable: false),
                ConsentLifetime = table.Column<int>("INTEGER", nullable: true),
                AbsoluteRefreshTokenLifetime = table.Column<int>("INTEGER", nullable: false),
                SlidingRefreshTokenLifetime = table.Column<int>("INTEGER", nullable: false),
                RefreshTokenUsage = table.Column<int>("INTEGER", nullable: false),
                UpdateAccessTokenClaimsOnRefresh = table.Column<bool>("INTEGER", nullable: false),
                RefreshTokenExpiration = table.Column<int>("INTEGER", nullable: false),
                AccessTokenType = table.Column<int>("INTEGER", nullable: false),
                EnableLocalLogin = table.Column<bool>("INTEGER", nullable: false),
                IncludeJwtId = table.Column<bool>("INTEGER", nullable: false),
                AlwaysSendClientClaims = table.Column<bool>("INTEGER", nullable: false),
                ClientClaimsPrefix = table.Column<string>("TEXT", maxLength: 200, nullable: true),
                PairWiseSubjectSalt = table.Column<string>("TEXT", maxLength: 200, nullable: true),
                Created = table.Column<DateTime>("TEXT", nullable: false),
                Updated = table.Column<DateTime>("TEXT", nullable: true),
                LastAccessed = table.Column<DateTime>("TEXT", nullable: true),
                UserSsoLifetime = table.Column<int>("INTEGER", nullable: true),
                UserCodeType = table.Column<string>("TEXT", maxLength: 100, nullable: true),
                DeviceCodeLifetime = table.Column<int>("INTEGER", nullable: false),
                NonEditable = table.Column<bool>("INTEGER", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_Clients", x => x.Id);
            });

        migrationBuilder.CreateTable(
            "IdentityResources",
            table => new
            {
                Id = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Enabled = table.Column<bool>("INTEGER", nullable: false),
                Name = table.Column<string>("TEXT", maxLength: 200, nullable: false),
                DisplayName = table.Column<string>("TEXT", maxLength: 200, nullable: true),
                Description = table.Column<string>("TEXT", maxLength: 1000, nullable: true),
                Required = table.Column<bool>("INTEGER", nullable: false),
                Emphasize = table.Column<bool>("INTEGER", nullable: false),
                ShowInDiscoveryDocument = table.Column<bool>("INTEGER", nullable: false),
                Created = table.Column<DateTime>("TEXT", nullable: false),
                Updated = table.Column<DateTime>("TEXT", nullable: true),
                NonEditable = table.Column<bool>("INTEGER", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_IdentityResources", x => x.Id);
            });

        migrationBuilder.CreateTable(
            "ApiResourceClaims",
            table => new
            {
                Id = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                ApiResourceId = table.Column<int>("INTEGER", nullable: false),
                Type = table.Column<string>("TEXT", maxLength: 200, nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ApiResourceClaims", x => x.Id);
                table.ForeignKey(
                    "FK_ApiResourceClaims_ApiResources_ApiResourceId",
                    x => x.ApiResourceId,
                    "ApiResources",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ApiResourceProperties",
            table => new
            {
                Id = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                ApiResourceId = table.Column<int>("INTEGER", nullable: false),
                Key = table.Column<string>("TEXT", maxLength: 250, nullable: false),
                Value = table.Column<string>("TEXT", maxLength: 2000, nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ApiResourceProperties", x => x.Id);
                table.ForeignKey(
                    "FK_ApiResourceProperties_ApiResources_ApiResourceId",
                    x => x.ApiResourceId,
                    "ApiResources",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ApiResourceScopes",
            table => new
            {
                Id = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Scope = table.Column<string>("TEXT", maxLength: 200, nullable: false),
                ApiResourceId = table.Column<int>("INTEGER", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ApiResourceScopes", x => x.Id);
                table.ForeignKey(
                    "FK_ApiResourceScopes_ApiResources_ApiResourceId",
                    x => x.ApiResourceId,
                    "ApiResources",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ApiResourceSecrets",
            table => new
            {
                Id = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                ApiResourceId = table.Column<int>("INTEGER", nullable: false),
                Description = table.Column<string>("TEXT", maxLength: 1000, nullable: true),
                Value = table.Column<string>("TEXT", maxLength: 4000, nullable: false),
                Expiration = table.Column<DateTime>("TEXT", nullable: true),
                Type = table.Column<string>("TEXT", maxLength: 250, nullable: false),
                Created = table.Column<DateTime>("TEXT", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ApiResourceSecrets", x => x.Id);
                table.ForeignKey(
                    "FK_ApiResourceSecrets_ApiResources_ApiResourceId",
                    x => x.ApiResourceId,
                    "ApiResources",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ApiScopeClaims",
            table => new
            {
                Id = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                ScopeId = table.Column<int>("INTEGER", nullable: false),
                Type = table.Column<string>("TEXT", maxLength: 200, nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ApiScopeClaims", x => x.Id);
                table.ForeignKey(
                    "FK_ApiScopeClaims_ApiScopes_ScopeId",
                    x => x.ScopeId,
                    "ApiScopes",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ApiScopeProperties",
            table => new
            {
                Id = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                ScopeId = table.Column<int>("INTEGER", nullable: false),
                Key = table.Column<string>("TEXT", maxLength: 250, nullable: false),
                Value = table.Column<string>("TEXT", maxLength: 2000, nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ApiScopeProperties", x => x.Id);
                table.ForeignKey(
                    "FK_ApiScopeProperties_ApiScopes_ScopeId",
                    x => x.ScopeId,
                    "ApiScopes",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ClientClaims",
            table => new
            {
                Id = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Type = table.Column<string>("TEXT", maxLength: 250, nullable: false),
                Value = table.Column<string>("TEXT", maxLength: 250, nullable: false),
                ClientId = table.Column<int>("INTEGER", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClientClaims", x => x.Id);
                table.ForeignKey(
                    "FK_ClientClaims_Clients_ClientId",
                    x => x.ClientId,
                    "Clients",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ClientCorsOrigins",
            table => new
            {
                Id = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Origin = table.Column<string>("TEXT", maxLength: 150, nullable: false),
                ClientId = table.Column<int>("INTEGER", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClientCorsOrigins", x => x.Id);
                table.ForeignKey(
                    "FK_ClientCorsOrigins_Clients_ClientId",
                    x => x.ClientId,
                    "Clients",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ClientGrantTypes",
            table => new
            {
                Id = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                GrantType = table.Column<string>("TEXT", maxLength: 250, nullable: false),
                ClientId = table.Column<int>("INTEGER", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClientGrantTypes", x => x.Id);
                table.ForeignKey(
                    "FK_ClientGrantTypes_Clients_ClientId",
                    x => x.ClientId,
                    "Clients",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ClientIdPRestrictions",
            table => new
            {
                Id = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Provider = table.Column<string>("TEXT", maxLength: 200, nullable: false),
                ClientId = table.Column<int>("INTEGER", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClientIdPRestrictions", x => x.Id);
                table.ForeignKey(
                    "FK_ClientIdPRestrictions_Clients_ClientId",
                    x => x.ClientId,
                    "Clients",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ClientPostLogoutRedirectUris",
            table => new
            {
                Id = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                PostLogoutRedirectUri = table.Column<string>("TEXT", maxLength: 2000, nullable: false),
                ClientId = table.Column<int>("INTEGER", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClientPostLogoutRedirectUris", x => x.Id);
                table.ForeignKey(
                    "FK_ClientPostLogoutRedirectUris_Clients_ClientId",
                    x => x.ClientId,
                    "Clients",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ClientProperties",
            table => new
            {
                Id = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                ClientId = table.Column<int>("INTEGER", nullable: false),
                Key = table.Column<string>("TEXT", maxLength: 250, nullable: false),
                Value = table.Column<string>("TEXT", maxLength: 2000, nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClientProperties", x => x.Id);
                table.ForeignKey(
                    "FK_ClientProperties_Clients_ClientId",
                    x => x.ClientId,
                    "Clients",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ClientRedirectUris",
            table => new
            {
                Id = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                RedirectUri = table.Column<string>("TEXT", maxLength: 2000, nullable: false),
                ClientId = table.Column<int>("INTEGER", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClientRedirectUris", x => x.Id);
                table.ForeignKey(
                    "FK_ClientRedirectUris_Clients_ClientId",
                    x => x.ClientId,
                    "Clients",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ClientScopes",
            table => new
            {
                Id = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                Scope = table.Column<string>("TEXT", maxLength: 200, nullable: false),
                ClientId = table.Column<int>("INTEGER", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClientScopes", x => x.Id);
                table.ForeignKey(
                    "FK_ClientScopes_Clients_ClientId",
                    x => x.ClientId,
                    "Clients",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "ClientSecrets",
            table => new
            {
                Id = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                ClientId = table.Column<int>("INTEGER", nullable: false),
                Description = table.Column<string>("TEXT", maxLength: 2000, nullable: true),
                Value = table.Column<string>("TEXT", maxLength: 4000, nullable: false),
                Expiration = table.Column<DateTime>("TEXT", nullable: true),
                Type = table.Column<string>("TEXT", maxLength: 250, nullable: false),
                Created = table.Column<DateTime>("TEXT", nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_ClientSecrets", x => x.Id);
                table.ForeignKey(
                    "FK_ClientSecrets_Clients_ClientId",
                    x => x.ClientId,
                    "Clients",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "IdentityResourceClaims",
            table => new
            {
                Id = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                IdentityResourceId = table.Column<int>("INTEGER", nullable: false),
                Type = table.Column<string>("TEXT", maxLength: 200, nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_IdentityResourceClaims", x => x.Id);
                table.ForeignKey(
                    "FK_IdentityResourceClaims_IdentityResources_IdentityResourceId",
                    x => x.IdentityResourceId,
                    "IdentityResources",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateTable(
            "IdentityResourceProperties",
            table => new
            {
                Id = table.Column<int>("INTEGER", nullable: false)
                    .Annotation("Sqlite:Autoincrement", true),
                IdentityResourceId = table.Column<int>("INTEGER", nullable: false),
                Key = table.Column<string>("TEXT", maxLength: 250, nullable: false),
                Value = table.Column<string>("TEXT", maxLength: 2000, nullable: false),
            },
            constraints: table =>
            {
                table.PrimaryKey("PK_IdentityResourceProperties", x => x.Id);
                table.ForeignKey(
                    "FK_IdentityResourceProperties_IdentityResources_IdentityResourceId",
                    x => x.IdentityResourceId,
                    "IdentityResources",
                    "Id",
                    onDelete: ReferentialAction.Cascade);
            });

        migrationBuilder.CreateIndex(
            "IX_ApiResourceClaims_ApiResourceId",
            "ApiResourceClaims",
            "ApiResourceId");

        migrationBuilder.CreateIndex(
            "IX_ApiResourceProperties_ApiResourceId",
            "ApiResourceProperties",
            "ApiResourceId");

        migrationBuilder.CreateIndex(
            "IX_ApiResources_Name",
            "ApiResources",
            "Name",
            unique: true);

        migrationBuilder.CreateIndex(
            "IX_ApiResourceScopes_ApiResourceId",
            "ApiResourceScopes",
            "ApiResourceId");

        migrationBuilder.CreateIndex(
            "IX_ApiResourceSecrets_ApiResourceId",
            "ApiResourceSecrets",
            "ApiResourceId");

        migrationBuilder.CreateIndex(
            "IX_ApiScopeClaims_ScopeId",
            "ApiScopeClaims",
            "ScopeId");

        migrationBuilder.CreateIndex(
            "IX_ApiScopeProperties_ScopeId",
            "ApiScopeProperties",
            "ScopeId");

        migrationBuilder.CreateIndex(
            "IX_ApiScopes_Name",
            "ApiScopes",
            "Name",
            unique: true);

        migrationBuilder.CreateIndex(
            "IX_ClientClaims_ClientId",
            "ClientClaims",
            "ClientId");

        migrationBuilder.CreateIndex(
            "IX_ClientCorsOrigins_ClientId",
            "ClientCorsOrigins",
            "ClientId");

        migrationBuilder.CreateIndex(
            "IX_ClientGrantTypes_ClientId",
            "ClientGrantTypes",
            "ClientId");

        migrationBuilder.CreateIndex(
            "IX_ClientIdPRestrictions_ClientId",
            "ClientIdPRestrictions",
            "ClientId");

        migrationBuilder.CreateIndex(
            "IX_ClientPostLogoutRedirectUris_ClientId",
            "ClientPostLogoutRedirectUris",
            "ClientId");

        migrationBuilder.CreateIndex(
            "IX_ClientProperties_ClientId",
            "ClientProperties",
            "ClientId");

        migrationBuilder.CreateIndex(
            "IX_ClientRedirectUris_ClientId",
            "ClientRedirectUris",
            "ClientId");

        migrationBuilder.CreateIndex(
            "IX_Clients_ClientId",
            "Clients",
            "ClientId",
            unique: true);

        migrationBuilder.CreateIndex(
            "IX_ClientScopes_ClientId",
            "ClientScopes",
            "ClientId");

        migrationBuilder.CreateIndex(
            "IX_ClientSecrets_ClientId",
            "ClientSecrets",
            "ClientId");

        migrationBuilder.CreateIndex(
            "IX_IdentityResourceClaims_IdentityResourceId",
            "IdentityResourceClaims",
            "IdentityResourceId");

        migrationBuilder.CreateIndex(
            "IX_IdentityResourceProperties_IdentityResourceId",
            "IdentityResourceProperties",
            "IdentityResourceId");

        migrationBuilder.CreateIndex(
            "IX_IdentityResources_Name",
            "IdentityResources",
            "Name",
            unique: true);
    }

    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DropTable(
            "ApiResourceClaims");

        migrationBuilder.DropTable(
            "ApiResourceProperties");

        migrationBuilder.DropTable(
            "ApiResourceScopes");

        migrationBuilder.DropTable(
            "ApiResourceSecrets");

        migrationBuilder.DropTable(
            "ApiScopeClaims");

        migrationBuilder.DropTable(
            "ApiScopeProperties");

        migrationBuilder.DropTable(
            "ClientClaims");

        migrationBuilder.DropTable(
            "ClientCorsOrigins");

        migrationBuilder.DropTable(
            "ClientGrantTypes");

        migrationBuilder.DropTable(
            "ClientIdPRestrictions");

        migrationBuilder.DropTable(
            "ClientPostLogoutRedirectUris");

        migrationBuilder.DropTable(
            "ClientProperties");

        migrationBuilder.DropTable(
            "ClientRedirectUris");

        migrationBuilder.DropTable(
            "ClientScopes");

        migrationBuilder.DropTable(
            "ClientSecrets");

        migrationBuilder.DropTable(
            "IdentityResourceClaims");

        migrationBuilder.DropTable(
            "IdentityResourceProperties");

        migrationBuilder.DropTable(
            "ApiResources");

        migrationBuilder.DropTable(
            "ApiScopes");

        migrationBuilder.DropTable(
            "Clients");

        migrationBuilder.DropTable(
            "IdentityResources");
    }
}