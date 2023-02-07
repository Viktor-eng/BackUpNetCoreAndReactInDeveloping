using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DataBase.Migrations
{
    public partial class Inital : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Drives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Letter = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drives", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrpcServiceUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Storages",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IpAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    GrpcServiceUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Storages", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DatabaseDefinitions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerId = table.Column<int>(type: "int", nullable: false),
                    DriveId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Source = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TempBackupPath = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DatabaseDefinitions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DatabaseDefinitions_Drives_DriveId",
                        column: x => x.DriveId,
                        principalTable: "Drives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DatabaseDefinitions_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServerToDrives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerId = table.Column<int>(type: "int", nullable: false),
                    DriveId = table.Column<int>(type: "int", nullable: false),
                    IsBackup = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerToDrives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServerToDrives_Drives_DriveId",
                        column: x => x.DriveId,
                        principalTable: "Drives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServerToDrives_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StorageToDrives",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    DriveId = table.Column<int>(type: "int", nullable: false),
                    IsBackup = table.Column<bool>(type: "bit", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageToDrives", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageToDrives_Drives_DriveId",
                        column: x => x.DriveId,
                        principalTable: "Drives",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StorageToDrives_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BackUpHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatabaseDefinitionId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BackUpSize = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackUpHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BackUpHistories_DatabaseDefinitions_DatabaseDefinitionId",
                        column: x => x.DatabaseDefinitionId,
                        principalTable: "DatabaseDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BackUpTargets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatabaseDefinitionId = table.Column<int>(type: "int", nullable: false),
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    DriveId = table.Column<int>(type: "int", nullable: false),
                    Target = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackUpTargets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BackUpTargets_DatabaseDefinitions_DatabaseDefinitionId",
                        column: x => x.DatabaseDefinitionId,
                        principalTable: "DatabaseDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BackUpTargets_Drives_DriveId",
                        column: x => x.DriveId,
                        principalTable: "Drives",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_BackUpTargets_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ScheduleBackups",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatabaseDefinitionId = table.Column<int>(type: "int", nullable: false),
                    SchedulePlan = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleBackups", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ScheduleBackups_DatabaseDefinitions_DatabaseDefinitionId",
                        column: x => x.DatabaseDefinitionId,
                        principalTable: "DatabaseDefinitions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ServerSizeHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FreeSpace = table.Column<int>(type: "int", nullable: false),
                    TotalSpace = table.Column<int>(type: "int", nullable: false),
                    ServerToDriveId = table.Column<int>(type: "int", nullable: false),
                    ServerId = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServerSizeHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ServerSizeHistories_Servers_ServerId",
                        column: x => x.ServerId,
                        principalTable: "Servers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ServerSizeHistories_ServerToDrives_ServerToDriveId",
                        column: x => x.ServerToDriveId,
                        principalTable: "ServerToDrives",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StorageSizeHistories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StorageId = table.Column<int>(type: "int", nullable: false),
                    StorageToDriveId = table.Column<int>(type: "int", nullable: false),
                    FreeSpace = table.Column<int>(type: "int", nullable: false),
                    TotalSpace = table.Column<int>(type: "int", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StorageSizeHistories", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StorageSizeHistories_Storages_StorageId",
                        column: x => x.StorageId,
                        principalTable: "Storages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StorageSizeHistories_StorageToDrives_StorageToDriveId",
                        column: x => x.StorageToDriveId,
                        principalTable: "StorageToDrives",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "BackUpHistoryLogs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BackUpHistoryId = table.Column<int>(type: "int", nullable: false),
                    Step = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateBegin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateEnd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BackUpHistoryLogs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BackUpHistoryLogs_BackUpHistories_BackUpHistoryId",
                        column: x => x.BackUpHistoryId,
                        principalTable: "BackUpHistories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Drives",
                columns: new[] { "Id", "CreatedAt", "LastModifiedAt", "Letter" },
                values: new object[,]
                {
                    { 1, new DateTime(2023, 1, 23, 16, 1, 1, 427, DateTimeKind.Local).AddTicks(4208), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(2704), "A" },
                    { 24, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(4107), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(4108), "X" },
                    { 23, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(4105), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(4106), "W" },
                    { 22, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(4104), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(4104), "V" },
                    { 21, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(4102), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(4103), "U" },
                    { 20, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(4100), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(4101), "T" },
                    { 19, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(4098), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(4099), "S" },
                    { 18, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(4095), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(4096), "R" },
                    { 17, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3908), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3909), "Q" },
                    { 16, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3907), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3907), "P" },
                    { 15, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3905), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3906), "O" },
                    { 14, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3903), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3904), "N" },
                    { 13, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3901), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3902), "M" },
                    { 12, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3900), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3900), "L" },
                    { 11, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3898), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3899), "K" },
                    { 10, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3896), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3897), "J" },
                    { 9, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3894), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3894), "I" },
                    { 8, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3892), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3892), "H" },
                    { 7, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3890), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3890), "G" },
                    { 6, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3888), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3889), "F" },
                    { 5, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3884), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3884), "E" },
                    { 4, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3882), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3883), "D" },
                    { 3, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3879), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3881), "C" },
                    { 2, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3774), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(3779), "B" },
                    { 25, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(4109), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(4109), "Y" },
                    { 26, new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(4110), new DateTime(2023, 1, 23, 16, 1, 1, 428, DateTimeKind.Local).AddTicks(4111), "Z" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BackUpHistories_DatabaseDefinitionId",
                table: "BackUpHistories",
                column: "DatabaseDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_BackUpHistoryLogs_BackUpHistoryId",
                table: "BackUpHistoryLogs",
                column: "BackUpHistoryId");

            migrationBuilder.CreateIndex(
                name: "IX_BackUpTargets_DatabaseDefinitionId",
                table: "BackUpTargets",
                column: "DatabaseDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_BackUpTargets_DriveId",
                table: "BackUpTargets",
                column: "DriveId");

            migrationBuilder.CreateIndex(
                name: "IX_BackUpTargets_StorageId",
                table: "BackUpTargets",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_DatabaseDefinitions_DriveId",
                table: "DatabaseDefinitions",
                column: "DriveId");

            migrationBuilder.CreateIndex(
                name: "IX_DatabaseDefinitions_ServerId",
                table: "DatabaseDefinitions",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleBackups_DatabaseDefinitionId",
                table: "ScheduleBackups",
                column: "DatabaseDefinitionId");

            migrationBuilder.CreateIndex(
                name: "IX_ServerSizeHistories_ServerId",
                table: "ServerSizeHistories",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_ServerSizeHistories_ServerToDriveId",
                table: "ServerSizeHistories",
                column: "ServerToDriveId");

            migrationBuilder.CreateIndex(
                name: "IX_ServerToDrives_DriveId",
                table: "ServerToDrives",
                column: "DriveId");

            migrationBuilder.CreateIndex(
                name: "IX_ServerToDrives_ServerId",
                table: "ServerToDrives",
                column: "ServerId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageSizeHistories_StorageId",
                table: "StorageSizeHistories",
                column: "StorageId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageSizeHistories_StorageToDriveId",
                table: "StorageSizeHistories",
                column: "StorageToDriveId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageToDrives_DriveId",
                table: "StorageToDrives",
                column: "DriveId");

            migrationBuilder.CreateIndex(
                name: "IX_StorageToDrives_StorageId",
                table: "StorageToDrives",
                column: "StorageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BackUpHistoryLogs");

            migrationBuilder.DropTable(
                name: "BackUpTargets");

            migrationBuilder.DropTable(
                name: "ScheduleBackups");

            migrationBuilder.DropTable(
                name: "ServerSizeHistories");

            migrationBuilder.DropTable(
                name: "StorageSizeHistories");

            migrationBuilder.DropTable(
                name: "BackUpHistories");

            migrationBuilder.DropTable(
                name: "ServerToDrives");

            migrationBuilder.DropTable(
                name: "StorageToDrives");

            migrationBuilder.DropTable(
                name: "DatabaseDefinitions");

            migrationBuilder.DropTable(
                name: "Storages");

            migrationBuilder.DropTable(
                name: "Drives");

            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}
