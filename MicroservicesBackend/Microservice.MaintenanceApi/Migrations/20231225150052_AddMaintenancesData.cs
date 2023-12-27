using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Microservice.MaintenanceApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMaintenancesData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "ConfigurationMaintenance",
                columns: new[] { "Id", "ConfigurationId", "CreatedDate", "CreatedUser", "MaintenanceId" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserUnknown", 1 },
                    { 2, 1, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserUnknown", 2 }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceMaintenanceElement",
                columns: new[] { "Id", "CreatedDate", "CreatedUser", "MaintenanceElementId", "MaintenanceId" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserUnknown", 3, 1 },
                    { 2, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserUnknown", 1, 2 },
                    { 3, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserUnknown", 3, 2 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "ConfigurationMaintenance",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "ConfigurationMaintenance",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MaintenanceMaintenanceElement",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "MaintenanceMaintenanceElement",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "MaintenanceMaintenanceElement",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
