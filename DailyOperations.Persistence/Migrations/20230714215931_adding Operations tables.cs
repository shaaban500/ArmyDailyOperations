using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyOperations.Persistence.Migrations
{
    public partial class addingOperationstables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DailyOperations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DailyOperationName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyOperations", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DriverTypes",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DriverTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GeneralDepartments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GeneralDepartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "InnerDepartments",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InnerDepartments", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationDescriptions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationDescriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationInstructions",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Instruction = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationInstructions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "OperationTypes",
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
                    table.PrimaryKey("PK_OperationTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SectorPlaces",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorPlaceName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SectorPlaces", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Sectors",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SectorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sectors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShiftTypes",
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
                    table.PrimaryKey("PK_ShiftTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Operations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GeneralDepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    InnerDepartmentId = table.Column<long>(type: "bigint", nullable: false),
                    DailyOperationId = table.Column<long>(type: "bigint", nullable: false),
                    ShiftTypeId = table.Column<long>(type: "bigint", nullable: false),
                    ShiftTimeFrom = table.Column<int>(type: "int", nullable: false),
                    ShiftTimeTo = table.Column<int>(type: "int", nullable: false),
                    SectorId = table.Column<long>(type: "bigint", nullable: false),
                    SectorPlaceFromId = table.Column<long>(type: "bigint", nullable: false),
                    SectorPlaceToId = table.Column<long>(type: "bigint", nullable: false),
                    VehicleTypeId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operations_DailyOperations_DailyOperationId",
                        column: x => x.DailyOperationId,
                        principalTable: "DailyOperations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Operations_GeneralDepartments_GeneralDepartmentId",
                        column: x => x.GeneralDepartmentId,
                        principalTable: "GeneralDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Operations_InnerDepartments_InnerDepartmentId",
                        column: x => x.InnerDepartmentId,
                        principalTable: "InnerDepartments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Operations_SectorPlaces_SectorPlaceFromId",
                        column: x => x.SectorPlaceFromId,
                        principalTable: "SectorPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Operations_SectorPlaces_SectorPlaceToId",
                        column: x => x.SectorPlaceToId,
                        principalTable: "SectorPlaces",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Operations_Sectors_SectorId",
                        column: x => x.SectorId,
                        principalTable: "Sectors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Operations_ShiftTypes_ShiftTypeId",
                        column: x => x.ShiftTypeId,
                        principalTable: "ShiftTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Operations_VehicleTypes_VehicleTypeId",
                        column: x => x.VehicleTypeId,
                        principalTable: "VehicleTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OperatinSoldiers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoldierId = table.Column<long>(type: "bigint", nullable: false),
                    OperationId = table.Column<long>(type: "bigint", nullable: false),
                    OperationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    OperationDescriptionId = table.Column<long>(type: "bigint", nullable: false),
                    OperationInstructionId = table.Column<long>(type: "bigint", nullable: false),
                    TimeFrom = table.Column<int>(type: "int", nullable: true),
                    TimeTo = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperatinSoldiers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperatinSoldiers_OperationDescriptions_OperationDescriptionId",
                        column: x => x.OperationDescriptionId,
                        principalTable: "OperationDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OperatinSoldiers_OperationInstructions_OperationInstructionId",
                        column: x => x.OperationInstructionId,
                        principalTable: "OperationInstructions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OperatinSoldiers_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OperatinSoldiers_OperationTypes_OperationTypeId",
                        column: x => x.OperationTypeId,
                        principalTable: "OperationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OperatinSoldiers_Soldiers_SoldierId",
                        column: x => x.SoldierId,
                        principalTable: "Soldiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OperationOfficers",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceOfficerId = table.Column<long>(type: "bigint", nullable: false),
                    OperationId = table.Column<long>(type: "bigint", nullable: false),
                    OperationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    OperationDescriptionId = table.Column<long>(type: "bigint", nullable: false),
                    OperationInstructionId = table.Column<long>(type: "bigint", nullable: false),
                    TimeFrom = table.Column<int>(type: "int", nullable: true),
                    TimeTo = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationOfficers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationOfficers_OperationDescriptions_OperationDescriptionId",
                        column: x => x.OperationDescriptionId,
                        principalTable: "OperationDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OperationOfficers_OperationInstructions_OperationInstructionId",
                        column: x => x.OperationInstructionId,
                        principalTable: "OperationInstructions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OperationOfficers_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OperationOfficers_OperationTypes_OperationTypeId",
                        column: x => x.OperationTypeId,
                        principalTable: "OperationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OperationOfficers_PoliceOfficers_PoliceOfficerId",
                        column: x => x.PoliceOfficerId,
                        principalTable: "PoliceOfficers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OperationPoliceAssistants",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoliceAssistantId = table.Column<long>(type: "bigint", nullable: false),
                    OperationId = table.Column<long>(type: "bigint", nullable: false),
                    OperationTypeId = table.Column<long>(type: "bigint", nullable: false),
                    OperationDescriptionId = table.Column<long>(type: "bigint", nullable: false),
                    OperationInstructionId = table.Column<long>(type: "bigint", nullable: false),
                    TimeFrom = table.Column<int>(type: "int", nullable: true),
                    TimeTo = table.Column<int>(type: "int", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationPoliceAssistants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationPoliceAssistants_OperationDescriptions_OperationDescriptionId",
                        column: x => x.OperationDescriptionId,
                        principalTable: "OperationDescriptions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OperationPoliceAssistants_OperationInstructions_OperationInstructionId",
                        column: x => x.OperationInstructionId,
                        principalTable: "OperationInstructions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OperationPoliceAssistants_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OperationPoliceAssistants_OperationTypes_OperationTypeId",
                        column: x => x.OperationTypeId,
                        principalTable: "OperationTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OperationPoliceAssistants_PoliceAssistants_PoliceAssistantId",
                        column: x => x.PoliceAssistantId,
                        principalTable: "PoliceAssistants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "OperationVehicles",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleId = table.Column<long>(type: "bigint", nullable: false),
                    OperationId = table.Column<long>(type: "bigint", nullable: false),
                    DriverTypeId = table.Column<long>(type: "bigint", nullable: false),
                    DriverId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OperationVehicles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OperationVehicles_DriverTypes_DriverTypeId",
                        column: x => x.DriverTypeId,
                        principalTable: "DriverTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OperationVehicles_Operations_OperationId",
                        column: x => x.OperationId,
                        principalTable: "Operations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_OperationVehicles_Vehicles_VehicleId",
                        column: x => x.VehicleId,
                        principalTable: "Vehicles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OperatinSoldiers_OperationDescriptionId",
                table: "OperatinSoldiers",
                column: "OperationDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatinSoldiers_OperationId",
                table: "OperatinSoldiers",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatinSoldiers_OperationInstructionId",
                table: "OperatinSoldiers",
                column: "OperationInstructionId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatinSoldiers_OperationTypeId",
                table: "OperatinSoldiers",
                column: "OperationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OperatinSoldiers_SoldierId",
                table: "OperatinSoldiers",
                column: "SoldierId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationOfficers_OperationDescriptionId",
                table: "OperationOfficers",
                column: "OperationDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationOfficers_OperationId",
                table: "OperationOfficers",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationOfficers_OperationInstructionId",
                table: "OperationOfficers",
                column: "OperationInstructionId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationOfficers_OperationTypeId",
                table: "OperationOfficers",
                column: "OperationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationOfficers_PoliceOfficerId",
                table: "OperationOfficers",
                column: "PoliceOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationPoliceAssistants_OperationDescriptionId",
                table: "OperationPoliceAssistants",
                column: "OperationDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationPoliceAssistants_OperationId",
                table: "OperationPoliceAssistants",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationPoliceAssistants_OperationInstructionId",
                table: "OperationPoliceAssistants",
                column: "OperationInstructionId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationPoliceAssistants_OperationTypeId",
                table: "OperationPoliceAssistants",
                column: "OperationTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationPoliceAssistants_PoliceAssistantId",
                table: "OperationPoliceAssistants",
                column: "PoliceAssistantId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_DailyOperationId",
                table: "Operations",
                column: "DailyOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_GeneralDepartmentId",
                table: "Operations",
                column: "GeneralDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_InnerDepartmentId",
                table: "Operations",
                column: "InnerDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_SectorId",
                table: "Operations",
                column: "SectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_SectorPlaceFromId",
                table: "Operations",
                column: "SectorPlaceFromId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_SectorPlaceToId",
                table: "Operations",
                column: "SectorPlaceToId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_ShiftTypeId",
                table: "Operations",
                column: "ShiftTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Operations_VehicleTypeId",
                table: "Operations",
                column: "VehicleTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationVehicles_DriverTypeId",
                table: "OperationVehicles",
                column: "DriverTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationVehicles_OperationId",
                table: "OperationVehicles",
                column: "OperationId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationVehicles_VehicleId",
                table: "OperationVehicles",
                column: "VehicleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OperatinSoldiers");

            migrationBuilder.DropTable(
                name: "OperationOfficers");

            migrationBuilder.DropTable(
                name: "OperationPoliceAssistants");

            migrationBuilder.DropTable(
                name: "OperationVehicles");

            migrationBuilder.DropTable(
                name: "OperationDescriptions");

            migrationBuilder.DropTable(
                name: "OperationInstructions");

            migrationBuilder.DropTable(
                name: "OperationTypes");

            migrationBuilder.DropTable(
                name: "DriverTypes");

            migrationBuilder.DropTable(
                name: "Operations");

            migrationBuilder.DropTable(
                name: "DailyOperations");

            migrationBuilder.DropTable(
                name: "GeneralDepartments");

            migrationBuilder.DropTable(
                name: "InnerDepartments");

            migrationBuilder.DropTable(
                name: "SectorPlaces");

            migrationBuilder.DropTable(
                name: "Sectors");

            migrationBuilder.DropTable(
                name: "ShiftTypes");
        }
    }
}
