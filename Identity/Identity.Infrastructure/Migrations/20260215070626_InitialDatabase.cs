using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "master_features",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    path = table.Column<string>(type: "text", nullable: false),
                    location_id = table.Column<long>(type: "bigint", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_master_features", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictApplications",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ApplicationType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ClientId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    ClientSecret = table.Column<string>(type: "text", nullable: true),
                    ClientType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ConcurrencyToken = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    ConsentType = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    DisplayNames = table.Column<string>(type: "text", nullable: true),
                    JsonWebKeySet = table.Column<string>(type: "text", nullable: true),
                    Permissions = table.Column<string>(type: "text", nullable: true),
                    PostLogoutRedirectUris = table.Column<string>(type: "text", nullable: true),
                    Properties = table.Column<string>(type: "text", nullable: true),
                    RedirectUris = table.Column<string>(type: "text", nullable: true),
                    Requirements = table.Column<string>(type: "text", nullable: true),
                    Settings = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictApplications", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictScopes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ConcurrencyToken = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Descriptions = table.Column<string>(type: "text", nullable: true),
                    DisplayName = table.Column<string>(type: "text", nullable: true),
                    DisplayNames = table.Column<string>(type: "text", nullable: true),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: true),
                    Properties = table.Column<string>(type: "text", nullable: true),
                    Resources = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictScopes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "password_rule",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    len = table.Column<int>(type: "integer", nullable: false),
                    is_lower = table.Column<bool>(type: "boolean", nullable: false),
                    is_upper = table.Column<bool>(type: "boolean", nullable: false),
                    is_digit = table.Column<bool>(type: "boolean", nullable: false),
                    is_symbol = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_password_rule", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "refresh_token",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    hashed_token = table.Column<string>(type: "text", nullable: false),
                    userid = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    action = table.Column<string>(type: "text", nullable: false),
                    info = table.Column<string>(type: "text", nullable: true),
                    expire_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_refresh_token", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "roles",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    location_id = table.Column<long>(type: "bigint", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_roles", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictAuthorizations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ApplicationId = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyToken = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Properties = table.Column<string>(type: "text", nullable: true),
                    Scopes = table.Column<string>(type: "text", nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Subject = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true),
                    Type = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictAuthorizations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictAuthorizations_OpenIddictApplications_Application~",
                        column: x => x.ApplicationId,
                        principalTable: "OpenIddictApplications",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "weak_password",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    pattern = table.Column<string>(type: "text", nullable: false),
                    rule_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_weak_password", x => x.id);
                    table.ForeignKey(
                        name: "FK_weak_password_password_rule_rule_id",
                        column: x => x.rule_id,
                        principalTable: "password_rule",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "features",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    path = table.Column<string>(type: "text", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    is_allow = table.Column<bool>(type: "boolean", nullable: false),
                    is_create = table.Column<bool>(type: "boolean", nullable: false),
                    is_modify = table.Column<bool>(type: "boolean", nullable: false),
                    is_delete = table.Column<bool>(type: "boolean", nullable: false),
                    is_action = table.Column<bool>(type: "boolean", nullable: false),
                    location_id = table.Column<long>(type: "bigint", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_features", x => x.id);
                    table.ForeignKey(
                        name: "FK_features_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "operators",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    userid = table.Column<string>(type: "text", nullable: false),
                    username = table.Column<string>(type: "text", nullable: false),
                    password = table.Column<string>(type: "text", nullable: false),
                    email = table.Column<string>(type: "text", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    firstname = table.Column<string>(type: "text", nullable: false),
                    middlename = table.Column<string>(type: "text", nullable: false),
                    lastname = table.Column<string>(type: "text", nullable: false),
                    phone = table.Column<string>(type: "text", nullable: false),
                    image = table.Column<string>(type: "text", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    location_id = table.Column<long>(type: "bigint", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operators", x => x.id);
                    table.ForeignKey(
                        name: "FK_operators_roles_role_id",
                        column: x => x.role_id,
                        principalTable: "roles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpenIddictTokens",
                columns: table => new
                {
                    Id = table.Column<string>(type: "text", nullable: false),
                    ApplicationId = table.Column<string>(type: "text", nullable: true),
                    AuthorizationId = table.Column<string>(type: "text", nullable: true),
                    ConcurrencyToken = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    CreationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ExpirationDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Payload = table.Column<string>(type: "text", nullable: true),
                    Properties = table.Column<string>(type: "text", nullable: true),
                    RedemptionDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    ReferenceId = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    Status = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    Subject = table.Column<string>(type: "character varying(400)", maxLength: 400, nullable: true),
                    Type = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpenIddictTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpenIddictTokens_OpenIddictApplications_ApplicationId",
                        column: x => x.ApplicationId,
                        principalTable: "OpenIddictApplications",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_OpenIddictTokens_OpenIddictAuthorizations_AuthorizationId",
                        column: x => x.AuthorizationId,
                        principalTable: "OpenIddictAuthorizations",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "master_features",
                columns: new[] { "id", "created_date", "is_active", "location_id", "name", "path", "updated_date" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9357), true, 0L, "Dashboard", "/", new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9359) },
                    { 2, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9362), true, 0L, "Events", "/event", new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9362) },
                    { 3, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9364), true, 0L, "Location", "/location", new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9364) },
                    { 4, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9364), true, 0L, "Alerts", "/alert", new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9365) },
                    { 5, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9365), true, 0L, "Operator", "/operator", new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9366) },
                    { 6, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9366), true, 0L, "Role", "/role", new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9367) },
                    { 7, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9367), true, 0L, "Hardware", "/hardware", new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9367) },
                    { 8, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9368), true, 0L, "Control Point", "/control", new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9368) },
                    { 9, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9369), true, 0L, "Monitor Point", "/monitor", new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9369) },
                    { 10, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9370), true, 0L, "Monitor Group", "/monitorgroup", new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9370) },
                    { 11, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9371), true, 0L, "Door", "/door", new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9371) },
                    { 12, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9372), true, 0L, "User", "/user", new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9372) },
                    { 13, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9373), true, 0L, "Access Level", "/level", new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9373) },
                    { 14, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9374), true, 0L, "Access Area", "/area", new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9374) },
                    { 15, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9375), true, 0L, "Timezone", "/timezone", new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9375) },
                    { 16, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9375), true, 0L, "Holiday", "/holiday", new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9376) },
                    { 17, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9376), true, 0L, "Interval", "/interval", new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9377) },
                    { 18, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9377), true, 0L, "Trigger", "/trigger", new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9378) },
                    { 19, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9379), true, 0L, "Procedure", "/procedure", new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9379) },
                    { 20, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9380), true, 0L, "Reports", "/report", new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9380) },
                    { 21, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9381), true, 0L, "Settings", "/setting", new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9381) },
                    { 22, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9382), true, 0L, "Maps", "/map", new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9382) }
                });

            migrationBuilder.InsertData(
                table: "password_rule",
                columns: new[] { "id", "is_digit", "is_lower", "is_symbol", "is_upper", "len" },
                values: new object[] { 1, false, false, false, false, 4 });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "created_date", "is_active", "location_id", "name", "updated_date" },
                values: new object[] { 1, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9538), true, 0L, "Administrator", new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9538) });

            migrationBuilder.InsertData(
                table: "operators",
                columns: new[] { "id", "created_date", "email", "firstname", "image", "is_active", "lastname", "location_id", "middlename", "password", "phone", "role_id", "title", "updated_date", "userid", "username" },
                values: new object[] { 1, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9496), "support@honorsupplying.com", "Administrator", "", true, "Platform", 0L, "", "2439iBIqejYGcodz6j0vGvyeI25eOrjMX3QtIhgVyo0M4YYmWbS+NmGwo0LLByUY", "", 1, "Mr.", new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9496), "1", "admin" });

            migrationBuilder.InsertData(
                table: "weak_password",
                columns: new[] { "id", "pattern", "rule_id" },
                values: new object[,]
                {
                    { 1, "P@ssw0rd", 1 },
                    { 2, "password", 1 },
                    { 3, "admin", 1 },
                    { 4, "123456", 1 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_features_role_id",
                table: "features",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictApplications_ClientId",
                table: "OpenIddictApplications",
                column: "ClientId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictAuthorizations_ApplicationId_Status_Subject_Type",
                table: "OpenIddictAuthorizations",
                columns: new[] { "ApplicationId", "Status", "Subject", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictScopes_Name",
                table: "OpenIddictScopes",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ApplicationId_Status_Subject_Type",
                table: "OpenIddictTokens",
                columns: new[] { "ApplicationId", "Status", "Subject", "Type" });

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_AuthorizationId",
                table: "OpenIddictTokens",
                column: "AuthorizationId");

            migrationBuilder.CreateIndex(
                name: "IX_OpenIddictTokens_ReferenceId",
                table: "OpenIddictTokens",
                column: "ReferenceId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_operators_role_id",
                table: "operators",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_weak_password_rule_id",
                table: "weak_password",
                column: "rule_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "features");

            migrationBuilder.DropTable(
                name: "master_features");

            migrationBuilder.DropTable(
                name: "OpenIddictScopes");

            migrationBuilder.DropTable(
                name: "OpenIddictTokens");

            migrationBuilder.DropTable(
                name: "operators");

            migrationBuilder.DropTable(
                name: "refresh_token");

            migrationBuilder.DropTable(
                name: "weak_password");

            migrationBuilder.DropTable(
                name: "OpenIddictAuthorizations");

            migrationBuilder.DropTable(
                name: "roles");

            migrationBuilder.DropTable(
                name: "password_rule");

            migrationBuilder.DropTable(
                name: "OpenIddictApplications");
        }
    }
}
