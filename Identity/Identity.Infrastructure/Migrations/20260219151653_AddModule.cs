using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddModule : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MasterModule",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    desciption = table.Column<string>(type: "text", nullable: false),
                    location_id = table.Column<long>(type: "bigint", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MasterModule", x => x.id);
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
                name: "master_features",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    master_module_id = table.Column<int>(type: "integer", nullable: false),
                    location_id = table.Column<long>(type: "bigint", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_master_features", x => x.id);
                    table.ForeignKey(
                        name: "FK_master_features_MasterModule_master_module_id",
                        column: x => x.master_module_id,
                        principalTable: "MasterModule",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                    module_id = table.Column<int>(type: "integer", nullable: false),
                    role_id = table.Column<int>(type: "integer", nullable: false),
                    is_allow = table.Column<bool>(type: "boolean", nullable: false),
                    is_create = table.Column<bool>(type: "boolean", nullable: false),
                    is_modify = table.Column<bool>(type: "boolean", nullable: false),
                    is_delete = table.Column<bool>(type: "boolean", nullable: false),
                    is_action = table.Column<bool>(type: "boolean", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "operator_locations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    location_id = table.Column<int>(type: "integer", nullable: false),
                    operator_id = table.Column<int>(type: "integer", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operator_locations", x => x.id);
                    table.ForeignKey(
                        name: "FK_operator_locations_operators_operator_id",
                        column: x => x.operator_id,
                        principalTable: "operators",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "MasterModule",
                columns: new[] { "id", "created_date", "desciption", "is_active", "location_id", "name", "updated_date" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2296), "", true, 0L, "Access Control System", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2303) },
                    { 2, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2309), "", true, 0L, "Visitor Management System", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2310) }
                });

            migrationBuilder.InsertData(
                table: "password_rule",
                columns: new[] { "id", "is_digit", "is_lower", "is_symbol", "is_upper", "len" },
                values: new object[] { 1, false, false, false, false, 4 });

            migrationBuilder.InsertData(
                table: "roles",
                columns: new[] { "id", "created_date", "is_active", "location_id", "name", "updated_date" },
                values: new object[] { 1, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(8861), true, 1L, "Administrator", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(8863) });

            migrationBuilder.InsertData(
                table: "features",
                columns: new[] { "id", "created_date", "is_action", "is_active", "is_allow", "is_create", "is_delete", "is_modify", "module_id", "name", "role_id", "updated_date" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, 1, "Dashboard", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, 1, "Events", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, 1, "Location", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, 1, "Alerts", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, 1, "Operator", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, 1, "Role", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, 1, "Hardware", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, 1, "Control Point", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, 1, "Monitor Point", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, 1, "Monitor Group", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, 1, "Door", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, 1, "User", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, 1, "Access Level", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, 1, "Access Area", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, 1, "Timezone", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, 1, "Holiday", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, 1, "Interval", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, 1, "Trigger", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, 1, "Procedure", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, 1, "Reports", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, 1, "Settings", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, 1, "Maps", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.InsertData(
                table: "master_features",
                columns: new[] { "id", "created_date", "is_active", "location_id", "master_module_id", "name", "updated_date" },
                values: new object[,]
                {
                    { 1, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2678), true, 0L, 1, "Dashboard", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2680) },
                    { 2, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2686), true, 0L, 1, "Events", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2687) },
                    { 3, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2690), true, 0L, 1, "Location", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2691) },
                    { 4, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2694), true, 0L, 1, "Alerts", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2695) },
                    { 5, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2698), true, 0L, 1, "Operator", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2699) },
                    { 6, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2702), true, 0L, 1, "Role", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2703) },
                    { 7, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2706), true, 0L, 1, "Hardware", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2706) },
                    { 8, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2709), true, 0L, 1, "Control Point", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2710) },
                    { 9, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2713), true, 0L, 1, "Monitor Point", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2714) },
                    { 10, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2717), true, 0L, 1, "Monitor Group", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2717) },
                    { 11, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2720), true, 0L, 1, "Door", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2721) },
                    { 12, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2723), true, 0L, 1, "User", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2724) },
                    { 13, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2727), true, 0L, 1, "Access Level", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2727) },
                    { 14, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2730), true, 0L, 1, "Access Area", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2731) },
                    { 15, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2733), true, 0L, 1, "Timezone", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2734) },
                    { 16, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2737), true, 0L, 1, "Holiday", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2737) },
                    { 17, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2740), true, 0L, 1, "Interval", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2741) },
                    { 18, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2743), true, 0L, 1, "Trigger", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2744) },
                    { 19, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2747), true, 0L, 1, "Procedure", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2748) },
                    { 20, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2750), true, 0L, 1, "Reports", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2751) },
                    { 21, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2753), true, 0L, 1, "Settings", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2754) },
                    { 22, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2757), true, 0L, 1, "Maps", new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(2757) }
                });

            migrationBuilder.InsertData(
                table: "operators",
                columns: new[] { "id", "created_date", "email", "firstname", "image", "is_active", "lastname", "middlename", "password", "phone", "role_id", "title", "updated_date", "userid", "username" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "support@honorsupplying.com", "Administrator", "", true, "Platform", "", "2439iBIqejYGcodz6j0vGvyeI25eOrjMX3QtIhgVyo0M4YYmWbS+NmGwo0LLByUY", "", 1, "Mr.", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "1", "admin" });

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

            migrationBuilder.InsertData(
                table: "operator_locations",
                columns: new[] { "id", "created_date", "location_id", "operator_id", "updated_date" },
                values: new object[] { 1, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(8764), 1, 1, new DateTime(2026, 2, 19, 15, 16, 53, 99, DateTimeKind.Utc).AddTicks(8770) });

            migrationBuilder.CreateIndex(
                name: "IX_features_role_id",
                table: "features",
                column: "role_id");

            migrationBuilder.CreateIndex(
                name: "IX_master_features_master_module_id",
                table: "master_features",
                column: "master_module_id");

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
                name: "IX_operator_locations_operator_id",
                table: "operator_locations",
                column: "operator_id");

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
                name: "operator_locations");

            migrationBuilder.DropTable(
                name: "refresh_token");

            migrationBuilder.DropTable(
                name: "weak_password");

            migrationBuilder.DropTable(
                name: "MasterModule");

            migrationBuilder.DropTable(
                name: "OpenIddictAuthorizations");

            migrationBuilder.DropTable(
                name: "operators");

            migrationBuilder.DropTable(
                name: "password_rule");

            migrationBuilder.DropTable(
                name: "OpenIddictApplications");

            migrationBuilder.DropTable(
                name: "roles");
        }
    }
}
