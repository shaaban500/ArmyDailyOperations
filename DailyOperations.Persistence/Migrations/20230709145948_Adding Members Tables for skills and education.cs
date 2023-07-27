using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyOperations.Persistence.Migrations
{
    public partial class AddingMembersTablesforskillsandeducation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Type",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "PoliceOfficers");

            migrationBuilder.DropColumn(
                name: "PowerType",
                table: "PoliceOfficers");

            migrationBuilder.DropColumn(
                name: "Department",
                table: "PoliceAssistants");

            migrationBuilder.AddColumn<long>(
                name: "VehicleMarkId",
                table: "Vehicles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "VehicleTypeId",
                table: "Vehicles",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DepartmentId",
                table: "Soldiers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "EducationTypeId",
                table: "Soldiers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<decimal>(
                name: "ExtraDuration",
                table: "Soldiers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<long>(
                name: "PowerTypeId",
                table: "Soldiers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<decimal>(
                name: "RecruitmentDuration",
                table: "Soldiers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<DateTime>(
                name: "RecruitmentEndDate",
                table: "Soldiers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RecruitmentStartDate",
                table: "Soldiers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<long>(
                name: "DepartmentId",
                table: "PoliceOfficers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PowerTypeId",
                table: "PoliceOfficers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "DepartmentId",
                table: "PoliceAssistants",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "PowerTypeId",
                table: "PoliceAssistants",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EducationTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PowerTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PowerTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SoldierSkills",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Skill = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoldierId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldierSkills", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoldierSkills_Soldiers_SoldierId",
                        column: x => x.SoldierId,
                        principalTable: "Soldiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VehicleMarks",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleMarks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VehicleTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VehicleTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleMarkId",
                table: "Vehicles",
                column: "VehicleMarkId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_DepartmentId",
                table: "Soldiers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_EducationTypeId",
                table: "Soldiers",
                column: "EducationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Soldiers_PowerTypeId",
                table: "Soldiers",
                column: "PowerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceOfficers_DepartmentId",
                table: "PoliceOfficers",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceOfficers_PowerTypeId",
                table: "PoliceOfficers",
                column: "PowerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceAssistants_DepartmentId",
                table: "PoliceAssistants",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_PoliceAssistants_PowerTypeId",
                table: "PoliceAssistants",
                column: "PowerTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldierSkills_SoldierId",
                table: "SoldierSkills",
                column: "SoldierId");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleMarks_VehicleMarkId",
                table: "Vehicles",
                column: "VehicleMarkId",
                principalTable: "VehicleMarks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles",
                column: "VehicleTypeId",
                principalTable: "VehicleTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleMarks_VehicleMarkId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_VehicleTypes_VehicleTypeId",
                table: "Vehicles");

            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "EducationTypes");

            migrationBuilder.DropTable(
                name: "PowerTypes");

            migrationBuilder.DropTable(
                name: "SoldierSkills");

            migrationBuilder.DropTable(
                name: "VehicleMarks");

            migrationBuilder.DropTable(
                name: "VehicleTypes");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleMarkId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_VehicleTypeId",
                table: "Vehicles");

            migrationBuilder.DropIndex(
                name: "IX_Soldiers_DepartmentId",
                table: "Soldiers");

            migrationBuilder.DropIndex(
                name: "IX_Soldiers_EducationTypeId",
                table: "Soldiers");

            migrationBuilder.DropIndex(
                name: "IX_Soldiers_PowerTypeId",
                table: "Soldiers");

            migrationBuilder.DropIndex(
                name: "IX_PoliceOfficers_DepartmentId",
                table: "PoliceOfficers");

            migrationBuilder.DropIndex(
                name: "IX_PoliceOfficers_PowerTypeId",
                table: "PoliceOfficers");

            migrationBuilder.DropIndex(
                name: "IX_PoliceAssistants_DepartmentId",
                table: "PoliceAssistants");

            migrationBuilder.DropIndex(
                name: "IX_PoliceAssistants_PowerTypeId",
                table: "PoliceAssistants");

            migrationBuilder.DropColumn(
                name: "VehicleMarkId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleTypeId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "EducationTypeId",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "ExtraDuration",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "PowerTypeId",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "RecruitmentDuration",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "RecruitmentEndDate",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "RecruitmentStartDate",
                table: "Soldiers");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "PoliceOfficers");

            migrationBuilder.DropColumn(
                name: "PowerTypeId",
                table: "PoliceOfficers");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "PoliceAssistants");

            migrationBuilder.DropColumn(
                name: "PowerTypeId",
                table: "PoliceAssistants");

            migrationBuilder.AddColumn<string>(
                name: "Type",
                table: "Vehicles",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "Soldiers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "PoliceOfficers",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PowerType",
                table: "PoliceOfficers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Department",
                table: "PoliceAssistants",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
