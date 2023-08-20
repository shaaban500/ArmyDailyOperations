using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyOperations.Persistence.Migrations
{
    public partial class AddingIsArmedIsInadministrativeWorkandHasAlternativetoPoliceOfficer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasAlternative",
                table: "PoliceOfficers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsArmed",
                table: "PoliceOfficers",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsInadministrativeWork",
                table: "PoliceOfficers",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasAlternative",
                table: "PoliceOfficers");

            migrationBuilder.DropColumn(
                name: "IsArmed",
                table: "PoliceOfficers");

            migrationBuilder.DropColumn(
                name: "IsInadministrativeWork",
                table: "PoliceOfficers");
        }
    }
}
