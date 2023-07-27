using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyOperations.Persistence.Migrations
{
    public partial class setrelationskillsandsoldierstomanytomany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Skills_Soldiers_SoldierId",
                table: "Skills");

            migrationBuilder.DropIndex(
                name: "IX_Skills_SoldierId",
                table: "Skills");

            migrationBuilder.DropColumn(
                name: "SoldierId",
                table: "Skills");

            migrationBuilder.CreateTable(
                name: "SkillSoldier",
                columns: table => new
                {
                    SkillsId = table.Column<long>(type: "bigint", nullable: false),
                    SoldiersId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkillSoldier", x => new { x.SkillsId, x.SoldiersId });
                    table.ForeignKey(
                        name: "FK_SkillSoldier_Skills_SkillsId",
                        column: x => x.SkillsId,
                        principalTable: "Skills",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SkillSoldier_Soldiers_SoldiersId",
                        column: x => x.SoldiersId,
                        principalTable: "Soldiers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SkillSoldier_SoldiersId",
                table: "SkillSoldier",
                column: "SoldiersId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SkillSoldier");

            migrationBuilder.AddColumn<long>(
                name: "SoldierId",
                table: "Skills",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Skills_SoldierId",
                table: "Skills",
                column: "SoldierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Skills_Soldiers_SoldierId",
                table: "Skills",
                column: "SoldierId",
                principalTable: "Soldiers",
                principalColumn: "Id");
        }
    }
}
