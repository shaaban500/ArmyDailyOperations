using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyOperations.Persistence.Migrations
{
    public partial class fixMembersTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoldierSkills_Soldiers_SoldierId",
                table: "SoldierSkills");

            migrationBuilder.DropColumn(
                name: "ExtraDuration",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "RecruitmentDuration",
                table: "Soldiers");

            migrationBuilder.RenameColumn(
                name: "Skill",
                table: "SoldierSkills",
                newName: "Name");

            migrationBuilder.AlterColumn<long>(
                name: "SoldierId",
                table: "SoldierSkills",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RecruitmentStartDate",
                table: "Soldiers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "RecruitmentEndDate",
                table: "Soldiers",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddForeignKey(
                name: "FK_SoldierSkills_Soldiers_SoldierId",
                table: "SoldierSkills",
                column: "SoldierId",
                principalTable: "Soldiers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoldierSkills_Soldiers_SoldierId",
                table: "SoldierSkills");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "SoldierSkills",
                newName: "Skill");

            migrationBuilder.AlterColumn<long>(
                name: "SoldierId",
                table: "SoldierSkills",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RecruitmentStartDate",
                table: "Soldiers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RecruitmentEndDate",
                table: "Soldiers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "ExtraDuration",
                table: "Soldiers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "RecruitmentDuration",
                table: "Soldiers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddForeignKey(
                name: "FK_SoldierSkills_Soldiers_SoldierId",
                table: "SoldierSkills",
                column: "SoldierId",
                principalTable: "Soldiers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
