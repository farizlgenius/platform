using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Location.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "locations",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_locations", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "operator_location",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    location_id = table.Column<int>(type: "integer", nullable: false),
                    operator_id = table.Column<int>(type: "integer", nullable: false),
                    is_active = table.Column<bool>(type: "boolean", nullable: false),
                    created_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    updated_date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_operator_location", x => x.id);
                    table.ForeignKey(
                        name: "FK_operator_location_locations_location_id",
                        column: x => x.location_id,
                        principalTable: "locations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "locations",
                columns: new[] { "id", "created_date", "description", "is_active", "name", "updated_date" },
                values: new object[] { 1, new DateTime(2026, 2, 16, 3, 24, 6, 788, DateTimeKind.Utc).AddTicks(2353), "Main location", true, "Main", new DateTime(2026, 2, 16, 3, 24, 6, 788, DateTimeKind.Utc).AddTicks(2355) });

            migrationBuilder.InsertData(
                table: "operator_location",
                columns: new[] { "id", "created_date", "is_active", "location_id", "operator_id", "updated_date" },
                values: new object[] { 1, new DateTime(2026, 2, 16, 3, 24, 6, 788, DateTimeKind.Utc).AddTicks(2435), true, 1, 1, new DateTime(2026, 2, 16, 3, 24, 6, 788, DateTimeKind.Utc).AddTicks(2435) });

            migrationBuilder.CreateIndex(
                name: "IX_operator_location_location_id",
                table: "operator_location",
                column: "location_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "operator_location");

            migrationBuilder.DropTable(
                name: "locations");
        }
    }
}
