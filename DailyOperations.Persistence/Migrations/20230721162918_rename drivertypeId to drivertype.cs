using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyOperations.Persistence.Migrations
{
    public partial class renamedrivertypeIdtodrivertype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OperationVehicles_DriverTypes_DriverTypeId",
                table: "OperationVehicles");

            migrationBuilder.DropIndex(
                name: "IX_OperationVehicles_DriverTypeId",
                table: "OperationVehicles");

            migrationBuilder.RenameColumn(
                name: "DriverTypeId",
                table: "OperationVehicles",
                newName: "DriverType");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DriverType",
                table: "OperationVehicles",
                newName: "DriverTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_OperationVehicles_DriverTypeId",
                table: "OperationVehicles",
                column: "DriverTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_OperationVehicles_DriverTypes_DriverTypeId",
                table: "OperationVehicles",
                column: "DriverTypeId",
                principalTable: "DriverTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
