using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyOperations.Persistence.Migrations
{
    public partial class AddingPoliceOfficerAlternativeIdcolumntoPoliceOfficers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasAlternative",
                table: "PoliceOfficers");

            migrationBuilder.AddColumn<long>(
                name: "PoliceOfficerAlternativeId",
                table: "PoliceOfficers",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PoliceOfficers_PoliceOfficerAlternativeId",
                table: "PoliceOfficers",
                column: "PoliceOfficerAlternativeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliceOfficers_PoliceOfficers_PoliceOfficerAlternativeId",
                table: "PoliceOfficers",
                column: "PoliceOfficerAlternativeId",
                principalTable: "PoliceOfficers",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliceOfficers_PoliceOfficers_PoliceOfficerAlternativeId",
                table: "PoliceOfficers");

            migrationBuilder.DropIndex(
                name: "IX_PoliceOfficers_PoliceOfficerAlternativeId",
                table: "PoliceOfficers");

            migrationBuilder.DropColumn(
                name: "PoliceOfficerAlternativeId",
                table: "PoliceOfficers");

            migrationBuilder.AddColumn<bool>(
                name: "HasAlternative",
                table: "PoliceOfficers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
