using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Microservice.VehicleApi.Migrations
{
    /// <inheritdoc />
    public partial class AddOperationTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "OperationType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Details = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OperationTypeId = table.Column<int>(type: "int", nullable: false),
                    VehicleId = table.Column<int>(type: "int", nullable: false),
                    Km = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operation_OperationType_OperationTypeId",
                        column: x => x.OperationTypeId,
                        principalTable: "OperationType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Operation_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OperationMaintenanceElement",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OperationId = table.Column<int>(type: "int", nullable: false),
                    MaintenanceElementId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationMaintenanceElement", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationMaintenanceElement_MaintenanceElement_MaintenanceElementId",
                        column: x => x.MaintenanceElementId,
                        principalTable: "MaintenanceElement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OperationMaintenanceElement_Operation_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.InsertData(
                table: "OperationType",
                columns: new[] { "Id", "Code", "CreatedDate", "CreatedUser", "Description" },
                values: new object[,]
                {
                    { 1, "MW", new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserUnknown", "MAINTENANCE_WORKSHOP" },
                    { 2, "FW", new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserUnknown", "FAILURE_WORKSHOP" },
                    { 3, "C", new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserUnknown", "CLOTHES" },
                    { 4, "T", new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserUnknown", "TOOLS" },
                    { 5, "O", new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserUnknown", "OTHERS" },
                    { 6, "MH", new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserUnknown", "MAINTENANCE_HOME" },
                    { 7, "FH", new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserUnknown", "FAILURE_HOME" },
                    { 8, "R", new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserUnknown", "SPARE_PARTS" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Operation_OperationTypeId",
                table: "Operation",
                column: "OperationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Operation_VehicleId",
                table: "Operation",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationMaintenanceElement_MaintenanceElementId",
                table: "OperationMaintenanceElement",
                column: "MaintenanceElementId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationMaintenanceElement_OperationId",
                table: "OperationMaintenanceElement",
                column: "OperationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperationMaintenanceElement");

            migrationBuilder.DropTable(
                name: "MaintenanceElement");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "OperationType");
        }
    }
}
