using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Microservice.MaintenanceApi.Migrations
{
    /// <inheritdoc />
    public partial class AddMaintenancesTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaintenanceFrecId",
                table: "Maintenance");

            migrationBuilder.CreateTable(
                name: "ConfigurationMaintenance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ConfigurationId = table.Column<int>(type: "int", nullable: false),
                    MaintenanceId = table.Column<int>(type: "int", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationMaintenance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfigurationMaintenance_Configurations_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalTable: "Configurations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConfigurationMaintenance_Maintenance_MaintenanceId",
                        column: x => x.MaintenanceId,
                        principalTable: "Maintenance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceElement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Master = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceElement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MaintenanceMaintenanceElement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaintenanceId = table.Column<int>(type: "int", nullable: false),
                    MaintenanceElementId = table.Column<int>(type: "int", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaintenanceMaintenanceElement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaintenanceMaintenanceElement_MaintenanceElement_MaintenanceElementId",
                        column: x => x.MaintenanceElementId,
                        principalTable: "MaintenanceElement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceMaintenanceElement_Maintenance_MaintenanceId",
                        column: x => x.MaintenanceId,
                        principalTable: "Maintenance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CreatedDate", "CreatedUser", "Description", "FromKm", "Init", "Km", "MaintenanceFreqId", "Master", "Time", "ToKm", "Wear" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserUnknown", "FIRST_REVIEW", 0, true, 1000, 1, true, 6, 0, false },
                    { 2, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserUnknown", "CHANGE_WHEEL", 0, false, 30000, 2, true, 36, 0, true }
                });

            migrationBuilder.InsertData(
                table: "MaintenanceElement",
                columns: new[] { "Id", "CreatedDate", "CreatedUser", "Description", "Master", "Name" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserUnknown", "CHANGE_FRONT_WHEEL", true, "FRONT_WHEEL" },
                    { 2, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserUnknown", "CHANGE_BACK_WHEEL", true, "BACK_WHEEL" },
                    { 3, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserUnknown", "CHANGE_ENGINE_OIL", true, "ENGINE_OIL" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationMaintenance_ConfigurationId",
                table: "ConfigurationMaintenance",
                column: "ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationMaintenance_MaintenanceId",
                table: "ConfigurationMaintenance",
                column: "MaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceMaintenanceElement_MaintenanceElementId",
                table: "MaintenanceMaintenanceElement",
                column: "MaintenanceElementId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceMaintenanceElement_MaintenanceId",
                table: "MaintenanceMaintenanceElement",
                column: "MaintenanceId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigurationMaintenance");

            migrationBuilder.DropTable(
                name: "MaintenanceMaintenanceElement");

            migrationBuilder.DropTable(
                name: "MaintenanceElement");

            migrationBuilder.DeleteData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Maintenance",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.AddColumn<int>(
                name: "MaintenanceFrecId",
                table: "Maintenance",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
