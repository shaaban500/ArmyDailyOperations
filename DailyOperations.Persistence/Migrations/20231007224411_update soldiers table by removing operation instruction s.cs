using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyOperations.Persistence.Migrations
{
    public partial class updatesoldierstablebyremovingoperationinstructions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperatinSoldiers_OperationInstructions_OperationInstructionId",
                table: "OperatinSoldiers");

            migrationBuilder.DropIndex(
                name: "IX_OperatinSoldiers_OperationInstructionId",
                table: "OperatinSoldiers");

            migrationBuilder.DropColumn(
                name: "OperationInstructionId",
                table: "OperatinSoldiers");

            migrationBuilder.DropColumn(
                name: "TimeFrom",
                table: "OperatinSoldiers");

            migrationBuilder.DropColumn(
                name: "TimeTo",
                table: "OperatinSoldiers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "OperationInstructionId",
                table: "OperatinSoldiers",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<int>(
                name: "TimeFrom",
                table: "OperatinSoldiers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeTo",
                table: "OperatinSoldiers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperatinSoldiers_OperationInstructionId",
                table: "OperatinSoldiers",
                column: "OperationInstructionId");

            migrationBuilder.AddForeignKey(
                name: "FK_OperatinSoldiers_OperationInstructions_OperationInstructionId",
                table: "OperatinSoldiers",
                column: "OperationInstructionId",
                principalTable: "OperationInstructions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
