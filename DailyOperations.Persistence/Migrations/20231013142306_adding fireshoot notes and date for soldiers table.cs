using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyOperations.Persistence.Migrations
{
    public partial class addingfireshootnotesanddateforsoldierstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_Departments_NextDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "NextMovingDate",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "OperationDescriptions");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "OperationDescriptions");

            migrationBuilder.RenameColumn(
                name: "PreviousMovingDate",
                table: "Soldiers",
                newName: "MovingDate");

            migrationBuilder.RenameColumn(
                name: "NextDepartmentId",
                table: "Soldiers",
                newName: "CurrentDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Soldiers_NextDepartmentId",
                table: "Soldiers",
                newName: "IX_Soldiers_CurrentDepartmentId");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastFireShootingDate",
                table: "Soldiers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "MovingNotes",
                table: "Soldiers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "FK_Soldiers_Departments_CurrentDepartmentId",
                table: "Soldiers",
                column: "CurrentDepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_Departments_CurrentDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "LastFireShootingDate",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "MovingNotes",
                table: "Soldiers");

            migrationBuilder.RenameColumn(
                name: "MovingDate",
                table: "Soldiers",
                newName: "PreviousMovingDate");

            migrationBuilder.RenameColumn(
                name: "CurrentDepartmentId",
                table: "Soldiers",
                newName: "NextDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Soldiers_CurrentDepartmentId",
                table: "Soldiers",
                newName: "IX_Soldiers_NextDepartmentId");

            migrationBuilder.AddColumn<DateTime>(
                name: "NextMovingDate",
                table: "Soldiers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "OperationDescriptions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "OperationDescriptions",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddForeignKey(
                name: "FK_Soldiers_Departments_NextDepartmentId",
                table: "Soldiers",
                column: "NextDepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
