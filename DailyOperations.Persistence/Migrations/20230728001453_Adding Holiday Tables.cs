using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyOperations.Persistence.Migrations
{
    public partial class AddingHolidayTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HolidayTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HolidayTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AssistantHolidays",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolidayStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    HolidayEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    PoliceAssistantId = table.Column<long>(type: "bigint", nullable: false),
                    HolidayTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssistantHolidays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssistantHolidays_HolidayTypes_HolidayTypeId",
                        column: x => x.HolidayTypeId,
                        principalTable: "HolidayTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AssistantHolidays_PoliceAssistants_PoliceAssistantId",
                        column: x => x.PoliceAssistantId,
                        principalTable: "PoliceAssistants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OfficerHolidays",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolidayStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    HolidayEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    PoliceOfficerId = table.Column<long>(type: "bigint", nullable: false),
                    HolidayTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OfficerHolidays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OfficerHolidays_HolidayTypes_HolidayTypeId",
                        column: x => x.HolidayTypeId,
                        principalTable: "HolidayTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OfficerHolidays_PoliceOfficers_PoliceOfficerId",
                        column: x => x.PoliceOfficerId,
                        principalTable: "PoliceOfficers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoldierHolidays",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HolidayStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Duration = table.Column<int>(type: "int", nullable: false),
                    HolidayEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsFinished = table.Column<bool>(type: "bit", nullable: false),
                    SoldierId = table.Column<long>(type: "bigint", nullable: false),
                    HolidayTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldierHolidays", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoldierHolidays_HolidayTypes_HolidayTypeId",
                        column: x => x.HolidayTypeId,
                        principalTable: "HolidayTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SoldierHolidays_Soldiers_SoldierId",
                        column: x => x.SoldierId,
                        principalTable: "Soldiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssistantHolidays_HolidayTypeId",
                table: "AssistantHolidays",
                column: "HolidayTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_AssistantHolidays_PoliceAssistantId",
                table: "AssistantHolidays",
                column: "PoliceAssistantId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficerHolidays_HolidayTypeId",
                table: "OfficerHolidays",
                column: "HolidayTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OfficerHolidays_PoliceOfficerId",
                table: "OfficerHolidays",
                column: "PoliceOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldierHolidays_HolidayTypeId",
                table: "SoldierHolidays",
                column: "HolidayTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldierHolidays_SoldierId",
                table: "SoldierHolidays",
                column: "SoldierId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssistantHolidays");

            migrationBuilder.DropTable(
                name: "OfficerHolidays");

            migrationBuilder.DropTable(
                name: "SoldierHolidays");

            migrationBuilder.DropTable(
                name: "HolidayTypes");
        }
    }
}
