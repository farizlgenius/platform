using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateRelation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "location_id",
                table: "operators");

            migrationBuilder.DropColumn(
                name: "location_id",
                table: "features");

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

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9756), new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9759) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9761), new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9761) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9762), new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9763) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9764), new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9764) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9765), new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9765) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9766), new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9766) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9766), new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9767) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9767), new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9768) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9768), new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9768) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9769), new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9769) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9770), new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9770) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9771), new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9771) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9772), new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9772) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9773), new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9773) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9773), new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9774) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9774), new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9775) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9775), new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9775) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9776), new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9776) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9777), new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9777) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9778), new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9778) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9779), new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9779) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 22,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9780), new DateTime(2026, 2, 17, 9, 53, 48, 680, DateTimeKind.Utc).AddTicks(9780) });

            migrationBuilder.InsertData(
                table: "operator_locations",
                columns: new[] { "id", "created_date", "location_id", "operator_id", "updated_date" },
                values: new object[] { 1, new DateTime(2026, 2, 17, 9, 53, 48, 681, DateTimeKind.Utc).AddTicks(1676), 1, 1, new DateTime(2026, 2, 17, 9, 53, 48, 681, DateTimeKind.Utc).AddTicks(1677) });

            migrationBuilder.UpdateData(
                table: "operators",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 681, DateTimeKind.Utc).AddTicks(1694), new DateTime(2026, 2, 17, 9, 53, 48, 681, DateTimeKind.Utc).AddTicks(1694) });

            migrationBuilder.CreateIndex(
                name: "IX_operator_locations_operator_id",
                table: "operator_locations",
                column: "operator_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "operator_locations");

            migrationBuilder.AddColumn<long>(
                name: "location_id",
                table: "operators",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "location_id",
                table: "features",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9357), new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9359) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9362), new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9362) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9364), new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9364) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9364), new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9365) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9365), new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9366) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9366), new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9367) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9367), new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9367) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9368), new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9368) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9369), new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9369) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9370), new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9370) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9371), new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9371) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9372), new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9372) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9373), new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9373) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9374), new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9374) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9375), new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9375) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9375), new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9376) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9376), new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9377) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9377), new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9378) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9379), new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9379) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9380), new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9380) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9381), new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9381) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 22,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9382), new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9382) });

            migrationBuilder.UpdateData(
                table: "operators",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_date", "location_id", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9496), 0L, new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9496) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9538), new DateTime(2026, 2, 15, 7, 6, 26, 637, DateTimeKind.Utc).AddTicks(9538) });
        }
    }
}
