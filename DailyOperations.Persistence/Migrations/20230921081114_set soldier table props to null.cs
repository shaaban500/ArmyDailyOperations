using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyOperations.Persistence.Migrations
{
    public partial class setsoldiertablepropstonull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_InnerDepartments_NextDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_InnerDepartments_PreviousDepartmentId",
                table: "Soldiers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PreviousMovingDate",
                table: "Soldiers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<long>(
                name: "PreviousDepartmentId",
                table: "Soldiers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "NextMovingDate",
                table: "Soldiers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<long>(
                name: "NextDepartmentId",
                table: "Soldiers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Soldiers_InnerDepartments_NextDepartmentId",
                table: "Soldiers",
                column: "NextDepartmentId",
                principalTable: "InnerDepartments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Soldiers_InnerDepartments_PreviousDepartmentId",
                table: "Soldiers",
                column: "PreviousDepartmentId",
                principalTable: "InnerDepartments",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_InnerDepartments_NextDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_InnerDepartments_PreviousDepartmentId",
                table: "Soldiers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PreviousMovingDate",
                table: "Soldiers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PreviousDepartmentId",
                table: "Soldiers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "NextMovingDate",
                table: "Soldiers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "NextDepartmentId",
                table: "Soldiers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Soldiers_InnerDepartments_NextDepartmentId",
                table: "Soldiers",
                column: "NextDepartmentId",
                principalTable: "InnerDepartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Soldiers_InnerDepartments_PreviousDepartmentId",
                table: "Soldiers",
                column: "PreviousDepartmentId",
                principalTable: "InnerDepartments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
