using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyOperations.Persistence.Migrations
{
    public partial class addingtimetooperationVehicles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TimeFrom",
                table: "OperationVehicles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "TimeTo",
                table: "OperationVehicles",
                type: "int",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeFrom",
                table: "OperationVehicles");

            migrationBuilder.DropColumn(
                name: "TimeTo",
                table: "OperationVehicles");
        }
    }
}
