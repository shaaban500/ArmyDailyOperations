using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyOperations.Persistence.Migrations
{
    public partial class AddingservicenavproptoOperationVehicle : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "OperationType",
                table: "OperationVehicles",
                newName: "RelatedOperationType");

            migrationBuilder.AddColumn<long>(
                name: "OperationDescriptionId",
                table: "OperationVehicles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OperationInstructionId",
                table: "OperationVehicles",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "OperationTypeId",
                table: "OperationVehicles",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_OperationVehicles_OperationDescriptionId",
                table: "OperationVehicles",
                column: "OperationDescriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationVehicles_OperationInstructionId",
                table: "OperationVehicles",
                column: "OperationInstructionId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationVehicles_OperationTypeId",
                table: "OperationVehicles",
                column: "OperationTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationVehicles_OperationDescriptions_OperationDescriptionId",
                table: "OperationVehicles",
                column: "OperationDescriptionId",
                principalTable: "OperationDescriptions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationVehicles_OperationInstructions_OperationInstructionId",
                table: "OperationVehicles",
                column: "OperationInstructionId",
                principalTable: "OperationInstructions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationVehicles_OperationTypes_OperationTypeId",
                table: "OperationVehicles",
                column: "OperationTypeId",
                principalTable: "OperationTypes",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationVehicles_OperationDescriptions_OperationDescriptionId",
                table: "OperationVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationVehicles_OperationInstructions_OperationInstructionId",
                table: "OperationVehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_OperationVehicles_OperationTypes_OperationTypeId",
                table: "OperationVehicles");

            migrationBuilder.DropIndex(
                name: "IX_OperationVehicles_OperationDescriptionId",
                table: "OperationVehicles");

            migrationBuilder.DropIndex(
                name: "IX_OperationVehicles_OperationInstructionId",
                table: "OperationVehicles");

            migrationBuilder.DropIndex(
                name: "IX_OperationVehicles_OperationTypeId",
                table: "OperationVehicles");

            migrationBuilder.DropColumn(
                name: "OperationDescriptionId",
                table: "OperationVehicles");

            migrationBuilder.DropColumn(
                name: "OperationInstructionId",
                table: "OperationVehicles");

            migrationBuilder.DropColumn(
                name: "OperationTypeId",
                table: "OperationVehicles");

            migrationBuilder.RenameColumn(
                name: "RelatedOperationType",
                table: "OperationVehicles",
                newName: "OperationType");
        }
    }
}
