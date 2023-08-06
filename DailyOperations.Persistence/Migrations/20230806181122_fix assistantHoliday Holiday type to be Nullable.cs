using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyOperations.Persistence.Migrations
{
    public partial class fixassistantHolidayHolidaytypetobeNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssistantHolidays_HolidayTypes_HolidayTypeId",
                table: "AssistantHolidays");

            migrationBuilder.DropColumn(
                name: "Duration",
                table: "AssistantHolidays");

            migrationBuilder.AlterColumn<long>(
                name: "HolidayTypeId",
                table: "AssistantHolidays",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HolidayStartDate",
                table: "AssistantHolidays",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "HolidayEndDate",
                table: "AssistantHolidays",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_AssistantHolidays_HolidayTypes_HolidayTypeId",
                table: "AssistantHolidays",
                column: "HolidayTypeId",
                principalTable: "HolidayTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AssistantHolidays_HolidayTypes_HolidayTypeId",
                table: "AssistantHolidays");

            migrationBuilder.AlterColumn<long>(
                name: "HolidayTypeId",
                table: "AssistantHolidays",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "HolidayStartDate",
                table: "AssistantHolidays",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "HolidayEndDate",
                table: "AssistantHolidays",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Duration",
                table: "AssistantHolidays",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_AssistantHolidays_HolidayTypes_HolidayTypeId",
                table: "AssistantHolidays",
                column: "HolidayTypeId",
                principalTable: "HolidayTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
