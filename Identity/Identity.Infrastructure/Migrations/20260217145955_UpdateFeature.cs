using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Identity.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class UpdateFeature : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "features",
                columns: new[] { "id", "created_date", "is_action", "is_active", "is_allow", "is_create", "is_delete", "is_modify", "name", "path", "role_id", "updated_date" },
                values: new object[,]
                {
                    { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, "Dashboard", "/", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, "Events", "/event", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, "Location", "/location", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, "Alerts", "/alert", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, "Operator", "/operator", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 6, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, "Role", "/role", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, "Hardware", "/hardware", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 8, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, "Control Point", "/control", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 9, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, "Monitor Point", "/monitor", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 10, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, "Monitor Group", "/monitorgroup", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 11, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, "Door", "/door", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 12, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, "User", "/user", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 13, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, "Access Level", "/level", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 14, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, "Access Area", "/area", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 15, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, "Timezone", "/timezone", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 16, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, "Holiday", "/holiday", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 17, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, "Interval", "/interval", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 18, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, "Trigger", "/trigger", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 19, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, "Procedure", "/procedure", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 20, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, "Reports", "/report", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 21, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, "Settings", "/setting", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 22, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), true, true, true, true, true, true, "Maps", "/map", 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3254), new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3256) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 2,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3259), new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3259) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 3,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3260), new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3260) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 4,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3261), new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3261) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 5,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3262), new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3262) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 6,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3263), new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3263) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 7,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3264), new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3264) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 8,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3265), new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3265) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 9,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3266), new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3266) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 10,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3267), new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3267) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 11,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3268), new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3268) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 12,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3269), new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3269) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 13,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3270), new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3270) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 14,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3270), new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3271) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 15,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3271), new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3272) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 16,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3272), new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3272) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 17,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3273), new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3273) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 18,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3274), new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3274) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 19,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3275), new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3275) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 20,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3276), new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3276) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 21,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3277), new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3277) });

            migrationBuilder.UpdateData(
                table: "master_features",
                keyColumn: "id",
                keyValue: 22,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3278), new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(3278) });

            migrationBuilder.UpdateData(
                table: "operator_locations",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(5269), new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(5269) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_date", "location_id", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(5287), 1L, new DateTime(2026, 2, 17, 14, 59, 55, 616, DateTimeKind.Utc).AddTicks(5287) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "features",
                keyColumn: "id",
                keyValue: 22);

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

            migrationBuilder.UpdateData(
                table: "operator_locations",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_date", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 681, DateTimeKind.Utc).AddTicks(1676), new DateTime(2026, 2, 17, 9, 53, 48, 681, DateTimeKind.Utc).AddTicks(1677) });

            migrationBuilder.UpdateData(
                table: "roles",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "created_date", "location_id", "updated_date" },
                values: new object[] { new DateTime(2026, 2, 17, 9, 53, 48, 681, DateTimeKind.Utc).AddTicks(1694), 0L, new DateTime(2026, 2, 17, 9, 53, 48, 681, DateTimeKind.Utc).AddTicks(1694) });
        }
    }
}
