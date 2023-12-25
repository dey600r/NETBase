using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BASE.AppInfrastructure.Migrations
{
    public partial class AddOperationAndMaintenanceTables : Migration
    {
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
                name: "MaintenanceFreq",
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
                    table.PrimaryKey("PK_MaintenanceFreq", x => x.Id);
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
                name: "Maintenance",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MaintenanceFreqId = table.Column<int>(type: "int", nullable: false),
                    Km = table.Column<int>(type: "int", nullable: false),
                    Time = table.Column<int>(type: "int", nullable: true),
                    Init = table.Column<bool>(type: "bit", nullable: false),
                    Wear = table.Column<bool>(type: "bit", nullable: false),
                    FromKm = table.Column<int>(type: "int", nullable: false),
                    ToKm = table.Column<int>(type: "int", nullable: false),
                    Master = table.Column<bool>(type: "bit", nullable: false),
                    CreatedUser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maintenance", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maintenance_MaintenanceFreq_MaintenanceFreqId",
                        column: x => x.MaintenanceFreqId,
                        principalTable: "MaintenanceFreq",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "FK_ConfigurationMaintenance_Configuration_ConfigurationId",
                        column: x => x.ConfigurationId,
                        principalTable: "Configuration",
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
                        name: "FK_MaintenanceMaintenanceElement_Maintenance_MaintenanceId",
                        column: x => x.MaintenanceId,
                        principalTable: "Maintenance",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MaintenanceMaintenanceElement_MaintenanceElement_MaintenanceElementId",
                        column: x => x.MaintenanceElementId,
                        principalTable: "MaintenanceElement",
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

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAENL1kF17uGjruVqtV8dfiKvhNdiLhOk1iWM2T8YEIbF03EQm32QbK2Kae/6tghvv2Q==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAENL1kF17uGjruVqtV8dfiKvhNdiLhOk1iWM2T8YEIbF03EQm32QbK2Kae/6tghvv2Q==");

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
                table: "MaintenanceFreq",
                columns: new[] { "Id", "Code", "CreatedDate", "CreatedUser", "Description" },
                values: new object[,]
                {
                    { 1, "O", new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserUnknown", "ONCE" },
                    { 2, "C", new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserUnknown", "CALENDAR" }
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

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CreatedDate", "CreatedUser", "Description", "FromKm", "Init", "Km", "MaintenanceFreqId", "Master", "Time", "ToKm", "Wear" },
                values: new object[] { 1, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserUnknown", "FIRST_REVIEW", 0, true, 1000, 1, true, 6, 0, false });

            migrationBuilder.InsertData(
                table: "Maintenance",
                columns: new[] { "Id", "CreatedDate", "CreatedUser", "Description", "FromKm", "Init", "Km", "MaintenanceFreqId", "Master", "Time", "ToKm", "Wear" },
                values: new object[] { 2, new DateTime(2023, 8, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "UserUnknown", "CHANGE_WHEEL", 0, false, 30000, 2, true, 36, 0, true });

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

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationMaintenance_ConfigurationId",
                table: "ConfigurationMaintenance",
                column: "ConfigurationId");

            migrationBuilder.CreateIndex(
                name: "IX_ConfigurationMaintenance_MaintenanceId",
                table: "ConfigurationMaintenance",
                column: "MaintenanceId");

            migrationBuilder.CreateIndex(
                name: "IX_Maintenance_MaintenanceFreqId",
                table: "Maintenance",
                column: "MaintenanceFreqId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceMaintenanceElement_MaintenanceElementId",
                table: "MaintenanceMaintenanceElement",
                column: "MaintenanceElementId");

            migrationBuilder.CreateIndex(
                name: "IX_MaintenanceMaintenanceElement_MaintenanceId",
                table: "MaintenanceMaintenanceElement",
                column: "MaintenanceId");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigurationMaintenance");

            migrationBuilder.DropTable(
                name: "MaintenanceMaintenanceElement");

            migrationBuilder.DropTable(
                name: "OperationMaintenanceElement");

            migrationBuilder.DropTable(
                name: "Maintenance");

            migrationBuilder.DropTable(
                name: "MaintenanceElement");

            migrationBuilder.DropTable(
                name: "Operation");

            migrationBuilder.DropTable(
                name: "MaintenanceFreq");

            migrationBuilder.DropTable(
                name: "OperationType");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEIO8v1KfLpRwlLR/ZI+noOYi8vp3IXgbQrrC5LXvELpDuxlKmFsrhcQxZiuAt/AwVA==");

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "PasswordHash",
                value: "AQAAAAEAACcQAAAAEIO8v1KfLpRwlLR/ZI+noOYi8vp3IXgbQrrC5LXvELpDuxlKmFsrhcQxZiuAt/AwVA==");
        }
    }
}
