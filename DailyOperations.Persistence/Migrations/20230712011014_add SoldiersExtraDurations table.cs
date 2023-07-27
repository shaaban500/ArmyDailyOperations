using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyOperations.Persistence.Migrations
{
    public partial class addSoldiersExtraDurationstable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SoldierSkills_Soldiers_SoldierId",
                table: "SoldierSkills");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SoldierSkills",
                table: "SoldierSkills");

            migrationBuilder.RenameTable(
                name: "SoldierSkills",
                newName: "Skills");

            migrationBuilder.RenameIndex(
                name: "IX_SoldierSkills_SoldierId",
                table: "Skills",
                newName: "IX_Skills_SoldierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Skills",
                table: "Skills",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EducationCertificates",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CertificateName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SoldierId = table.Column<long>(type: "bigint", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EducationCertificates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EducationCertificates_Soldiers_SoldierId",
                        column: x => x.SoldierId,
                        principalTable: "Soldiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SoldiersExtraDurations",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SoldierId = table.Column<long>(type: "bigint", nullable: false),
                    ExtraDuration = table.Column<int>(type: "int", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SoldiersExtraDurations", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SoldiersExtraDurations_Soldiers_SoldierId",
                        column: x => x.SoldierId,
                        principalTable: "Soldiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EducationCertificates_SoldierId",
                table: "EducationCertificates",
                column: "SoldierId");

            migrationBuilder.CreateIndex(
                name: "IX_SoldiersExtraDurations_SoldierId",
                table: "SoldiersExtraDurations",
                column: "SoldierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Soldiers_SoldierId",
                table: "Skills",
                column: "SoldierId",
                principalTable: "Soldiers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Soldiers_SoldierId",
                table: "Skills");

            migrationBuilder.DropTable(
                name: "EducationCertificates");

            migrationBuilder.DropTable(
                name: "SoldiersExtraDurations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Skills",
                table: "Skills");

            migrationBuilder.RenameTable(
                name: "Skills",
                newName: "SoldierSkills");

            migrationBuilder.RenameIndex(
                name: "IX_Skills_SoldierId",
                table: "SoldierSkills",
                newName: "IX_SoldierSkills_SoldierId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SoldierSkills",
                table: "SoldierSkills",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SoldierSkills_Soldiers_SoldierId",
                table: "SoldierSkills",
                column: "SoldierId",
                principalTable: "Soldiers",
                principalColumn: "Id");
        }
    }
}
