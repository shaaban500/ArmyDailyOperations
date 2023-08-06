using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyOperations.Persistence.Migrations
{
    public partial class fixOfficerHolidayHolidaytypetobeNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficerHolidays_HolidayTypes_HolidayTypeId",
                table: "OfficerHolidays");

            migrationBuilder.AlterColumn<long>(
                name: "HolidayTypeId",
                table: "OfficerHolidays",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_OfficerHolidays_HolidayTypes_HolidayTypeId",
                table: "OfficerHolidays",
                column: "HolidayTypeId",
                principalTable: "HolidayTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OfficerHolidays_HolidayTypes_HolidayTypeId",
                table: "OfficerHolidays");

            migrationBuilder.AlterColumn<long>(
                name: "HolidayTypeId",
                table: "OfficerHolidays",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OfficerHolidays_HolidayTypes_HolidayTypeId",
                table: "OfficerHolidays",
                column: "HolidayTypeId",
                principalTable: "HolidayTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
