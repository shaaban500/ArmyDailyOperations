using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyOperations.Persistence.Migrations
{
    public partial class AddingDatetoOperations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Operations_VehicleTypes_VehicleTypeId",
                table: "Operations");

            migrationBuilder.DropIndex(
                name: "IX_Operations_VehicleTypeId",
                table: "Operations");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "Operations");

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Operations",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Operations");

            migrationBuilder.AddColumn<long>(
                name: "VehicleTypeId",
                table: "Operations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Operations_VehicleTypeId",
                table: "Operations",
                column: "VehicleTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Operations_VehicleTypes_VehicleTypeId",
                table: "Operations",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
