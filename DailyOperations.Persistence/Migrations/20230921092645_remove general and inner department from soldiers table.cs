using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyOperations.Persistence.Migrations
{
    public partial class removegeneralandinnerdepartmentfromsoldierstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_GeneralDepartments_GeneralDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_InnerDepartments_InnerDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_InnerDepartments_NextDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_InnerDepartments_PreviousDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropIndex(
                name: "IX_Soldiers_GeneralDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "GeneralDepartmentId",
                table: "Soldiers");

            migrationBuilder.RenameColumn(
                name: "InnerDepartmentId",
                table: "Soldiers",
                newName: "DepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Soldiers_InnerDepartmentId",
                table: "Soldiers",
                newName: "IX_Soldiers_DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Soldiers_Departments_DepartmentId",
                table: "Soldiers",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

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
                name: "FK_Soldiers_Departments_DepartmentId",
                table: "Soldiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_Departments_NextDepartmentId",
                table: "Soldiers");

            migrationBuilder.DropForeignKey(
                name: "FK_Soldiers_Departments_PreviousDepartmentId",
                table: "Soldiers");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Soldiers",
                newName: "InnerDepartmentId");

            migrationBuilder.RenameIndex(
                name: "IX_Soldiers_DepartmentId",
                table: "Soldiers",
                newName: "IX_Soldiers_InnerDepartmentId");

            migrationBuilder.AddColumn<long>(
                name: "GeneralDepartmentId",
                table: "Soldiers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_GeneralDepartmentId",
                table: "Soldiers",
                column: "GeneralDepartmentId");

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
    }
}
