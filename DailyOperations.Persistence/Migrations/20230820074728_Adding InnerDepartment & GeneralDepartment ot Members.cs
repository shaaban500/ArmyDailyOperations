using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyOperations.Persistence.Migrations
{
    public partial class AddingInnerDepartmentGeneralDepartmentotMembers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliceAssistants_Departments_DepartmentId",
                table: "PoliceAssistants");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliceOfficers_Departments_DepartmentId",
                table: "PoliceOfficers");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "PoliceOfficers",
                newName: "InnerDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_PoliceOfficers_DepartmentId",
                table: "PoliceOfficers",
                newName: "IX_PoliceOfficers_InnerDepartmentId");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "PoliceAssistants",
                newName: "InnerDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_PoliceAssistants_DepartmentId",
                table: "PoliceAssistants",
                newName: "IX_PoliceAssistants_InnerDepartmentId");

            migrationBuilder.AddColumn<long>(
                name: "GeneralDepartmentId",
                table: "Soldiers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "InnerDepartmentId",
                table: "Soldiers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GeneralDepartmentId",
                table: "PoliceOfficers",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "GeneralDepartmentId",
                table: "PoliceAssistants",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_GeneralDepartmentId",
                table: "Soldiers",
                column: "GeneralDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_InnerDepartmentId",
                table: "Soldiers",
                column: "InnerDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceOfficers_GeneralDepartmentId",
                table: "PoliceOfficers",
                column: "GeneralDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceAssistants_GeneralDepartmentId",
                table: "PoliceAssistants",
                column: "GeneralDepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliceAssistants_GeneralDepartments_GeneralDepartmentId",
                table: "PoliceAssistants",
                column: "GeneralDepartmentId",
                principalTable: "GeneralDepartments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliceAssistants_InnerDepartments_InnerDepartmentId",
                table: "PoliceAssistants",
                column: "InnerDepartmentId",
                principalTable: "InnerDepartments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliceOfficers_GeneralDepartments_GeneralDepartmentId",
                table: "PoliceOfficers",
                column: "GeneralDepartmentId",
                principalTable: "GeneralDepartments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliceOfficers_InnerDepartments_InnerDepartmentId",
                table: "PoliceOfficers",
                column: "InnerDepartmentId",
                principalTable: "InnerDepartments",
                principalColumn: "Id");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliceAssistants_GeneralDepartments_GeneralDepartmentId",
                table: "PoliceAssistants");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliceAssistants_InnerDepartments_InnerDepartmentId",
                table: "PoliceAssistants");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliceOfficers_GeneralDepartments_GeneralDepartmentId",
                table: "PoliceOfficers");

            migrationBuilder.DropForeignKey(
                name: "FK_PoliceOfficers_InnerDepartments_InnerDepartmentId",
                table: "PoliceOfficers");

            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_GeneralDepartments_GeneralDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_InnerDepartments_InnerDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropIndex(
                name: "IX_Soldiers_GeneralDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropIndex(
                name: "IX_Soldiers_InnerDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropIndex(
                name: "IX_PoliceOfficers_GeneralDepartmentId",
                table: "PoliceOfficers");

            migrationBuilder.DropIndex(
                name: "IX_PoliceAssistants_GeneralDepartmentId",
                table: "PoliceAssistants");

            migrationBuilder.DropColumn(
                name: "GeneralDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "InnerDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "GeneralDepartmentId",
                table: "PoliceOfficers");

            migrationBuilder.DropColumn(
                name: "GeneralDepartmentId",
                table: "PoliceAssistants");

            migrationBuilder.RenameColumn(
                name: "InnerDepartmentId",
                table: "PoliceOfficers",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_PoliceOfficers_InnerDepartmentId",
                table: "PoliceOfficers",
                newName: "IX_PoliceOfficers_DepartmentId");

            migrationBuilder.RenameColumn(
                name: "InnerDepartmentId",
                table: "PoliceAssistants",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_PoliceAssistants_InnerDepartmentId",
                table: "PoliceAssistants",
                newName: "IX_PoliceAssistants_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliceAssistants_Departments_DepartmentId",
                table: "PoliceAssistants",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliceOfficers_Departments_DepartmentId",
                table: "PoliceOfficers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");
        }
    }
}
