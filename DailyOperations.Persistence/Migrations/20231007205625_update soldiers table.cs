using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyOperations.Persistence.Migrations
{
    public partial class updatesoldierstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_GeneralDepartments_GeneralDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_InnerDepartments_InnerDepartmentId",
                table: "Soldiers");

            migrationBuilder.RenameColumn(
                name: "InnerDepartmentId",
                table: "Soldiers",
                newName: "PreviousDepartmentId");

            migrationBuilder.RenameColumn(
                name: "GeneralDepartmentId",
                table: "Soldiers",
                newName: "NextDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Soldiers_InnerDepartmentId",
                table: "Soldiers",
                newName: "IX_Soldiers_PreviousDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Soldiers_GeneralDepartmentId",
                table: "Soldiers",
                newName: "IX_Soldiers_NextDepartmentId");

            migrationBuilder.AddColumn<DateTime>(
                name: "NextMovingDate",
                table: "Soldiers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PreviousMovingDate",
                table: "Soldiers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Soldiers_Departments_NextDepartmentId",
                table: "Soldiers",
                column: "NextDepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Soldiers_Departments_PreviousDepartmentId",
                table: "Soldiers",
                column: "PreviousDepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_Departments_NextDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_Departments_PreviousDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "NextMovingDate",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "PreviousMovingDate",
                table: "Soldiers");

            migrationBuilder.RenameColumn(
                name: "PreviousDepartmentId",
                table: "Soldiers",
                newName: "InnerDepartmentId");

            migrationBuilder.RenameColumn(
                name: "NextDepartmentId",
                table: "Soldiers",
                newName: "GeneralDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Soldiers_PreviousDepartmentId",
                table: "Soldiers",
                newName: "IX_Soldiers_InnerDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Soldiers_NextDepartmentId",
                table: "Soldiers",
                newName: "IX_Soldiers_GeneralDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Soldiers_GeneralDepartments_GeneralDepartmentId",
                table: "Soldiers",
                column: "GeneralDepartmentId",
                principalTable: "GeneralDepartments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Soldiers_InnerDepartments_InnerDepartmentId",
                table: "Soldiers",
                column: "InnerDepartmentId",
                principalTable: "InnerDepartments",
                principalColumn: "Id");
        }
    }
}
