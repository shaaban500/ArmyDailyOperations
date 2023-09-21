using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyOperations.Persistence.Migrations
{
    public partial class Addinggeneralandinnerdepartmenttosoldierstableandnextprevdeptinfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_Departments_DepartmentId",
                table: "Soldiers");

            migrationBuilder.DropIndex(
                name: "IX_Soldiers_DepartmentId",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Soldiers");

            migrationBuilder.AddColumn<long>(
                name: "NextDepartmentId",
                table: "Soldiers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "NextMovingDate",
                table: "Soldiers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "PreviousDepartmentId",
                table: "Soldiers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateTime>(
                name: "PreviousMovingDate",
                table: "Soldiers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_NextDepartmentId",
                table: "Soldiers",
                column: "NextDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_PreviousDepartmentId",
                table: "Soldiers",
                column: "PreviousDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Soldiers_InnerDepartments_NextDepartmentId",
                table: "Soldiers",
                column: "NextDepartmentId",
                principalTable: "InnerDepartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Soldiers_InnerDepartments_PreviousDepartmentId",
                table: "Soldiers",
                column: "PreviousDepartmentId",
                principalTable: "InnerDepartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_InnerDepartments_NextDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_InnerDepartments_PreviousDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropIndex(
                name: "IX_Soldiers_NextDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropIndex(
                name: "IX_Soldiers_PreviousDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "NextDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "NextMovingDate",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "PreviousDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "PreviousMovingDate",
                table: "Soldiers");

            migrationBuilder.AddColumn<long>(
                name: "DepartmentId",
                table: "Soldiers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_DepartmentId",
                table: "Soldiers",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Soldiers_Departments_DepartmentId",
                table: "Soldiers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
