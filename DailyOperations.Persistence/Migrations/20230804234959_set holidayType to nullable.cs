using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyOperations.Persistence.Migrations
{
    public partial class setholidayTypetonullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoldierHolidays_HolidayTypes_HolidayTypeId",
                table: "SoldierHolidays");

            migrationBuilder.AlterColumn<long>(
                name: "HolidayTypeId",
                table: "SoldierHolidays",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_SoldierHolidays_HolidayTypes_HolidayTypeId",
                table: "SoldierHolidays",
                column: "HolidayTypeId",
                principalTable: "HolidayTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoldierHolidays_HolidayTypes_HolidayTypeId",
                table: "SoldierHolidays");

            migrationBuilder.AlterColumn<long>(
                name: "HolidayTypeId",
                table: "SoldierHolidays",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SoldierHolidays_HolidayTypes_HolidayTypeId",
                table: "SoldierHolidays",
                column: "HolidayTypeId",
                principalTable: "HolidayTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
