using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyOperations.Persistence.Migrations
{
    public partial class setMemberspropstoNULLS : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliceAssistants_Departments_DepartmentId",
                table: "PoliceAssistants");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliceAssistants_PowerTypes_PowerTypeId",
                table: "PoliceAssistants");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliceOfficers_Departments_DepartmentId",
                table: "PoliceOfficers");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliceOfficers_PowerTypes_PowerTypeId",
                table: "PoliceOfficers");

            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_Departments_DepartmentId",
                table: "Soldiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_EducationTypes_EducationTypeId",
                table: "Soldiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_PowerTypes_PowerTypeId",
                table: "Soldiers");

            migrationBuilder.AlterColumn<long>(
                name: "PowerTypeId",
                table: "Soldiers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "EducationTypeId",
                table: "Soldiers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DepartmentId",
                table: "Soldiers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "PowerTypeId",
                table: "PoliceOfficers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DepartmentId",
                table: "PoliceOfficers",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "PowerTypeId",
                table: "PoliceAssistants",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AlterColumn<long>(
                name: "DepartmentId",
                table: "PoliceAssistants",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliceAssistants_Departments_DepartmentId",
                table: "PoliceAssistants",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliceAssistants_PowerTypes_PowerTypeId",
                table: "PoliceAssistants",
                column: "PowerTypeId",
                principalTable: "PowerTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliceOfficers_Departments_DepartmentId",
                table: "PoliceOfficers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliceOfficers_PowerTypes_PowerTypeId",
                table: "PoliceOfficers",
                column: "PowerTypeId",
                principalTable: "PowerTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Soldiers_Departments_DepartmentId",
                table: "Soldiers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Soldiers_EducationTypes_EducationTypeId",
                table: "Soldiers",
                column: "EducationTypeId",
                principalTable: "EducationTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Soldiers_PowerTypes_PowerTypeId",
                table: "Soldiers",
                column: "PowerTypeId",
                principalTable: "PowerTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliceAssistants_Departments_DepartmentId",
                table: "PoliceAssistants");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliceAssistants_PowerTypes_PowerTypeId",
                table: "PoliceAssistants");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliceOfficers_Departments_DepartmentId",
                table: "PoliceOfficers");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliceOfficers_PowerTypes_PowerTypeId",
                table: "PoliceOfficers");

            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_Departments_DepartmentId",
                table: "Soldiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_EducationTypes_EducationTypeId",
                table: "Soldiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_PowerTypes_PowerTypeId",
                table: "Soldiers");

            migrationBuilder.AlterColumn<long>(
                name: "PowerTypeId",
                table: "Soldiers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "EducationTypeId",
                table: "Soldiers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DepartmentId",
                table: "Soldiers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PowerTypeId",
                table: "PoliceOfficers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DepartmentId",
                table: "PoliceOfficers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "PowerTypeId",
                table: "PoliceAssistants",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "DepartmentId",
                table: "PoliceAssistants",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PoliceAssistants_Departments_DepartmentId",
                table: "PoliceAssistants",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoliceAssistants_PowerTypes_PowerTypeId",
                table: "PoliceAssistants",
                column: "PowerTypeId",
                principalTable: "PowerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoliceOfficers_Departments_DepartmentId",
                table: "PoliceOfficers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PoliceOfficers_PowerTypes_PowerTypeId",
                table: "PoliceOfficers",
                column: "PowerTypeId",
                principalTable: "PowerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Soldiers_Departments_DepartmentId",
                table: "Soldiers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Soldiers_EducationTypes_EducationTypeId",
                table: "Soldiers",
                column: "EducationTypeId",
                principalTable: "EducationTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Soldiers_PowerTypes_PowerTypeId",
                table: "Soldiers",
                column: "PowerTypeId",
                principalTable: "PowerTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
