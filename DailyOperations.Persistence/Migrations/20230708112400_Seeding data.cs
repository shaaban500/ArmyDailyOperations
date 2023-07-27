using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DailyOperations.Persistence.Migrations
{
    public partial class Seedingdata : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliceAssistants_AssistantsMilitaryDegrees_AssistantsMilitaryDegreeId",
                table: "PoliceAssistants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssistantsMilitaryDegrees",
                table: "AssistantsMilitaryDegrees");

            migrationBuilder.RenameTable(
                name: "AssistantsMilitaryDegrees",
                newName: "AssistantMilitaryDegrees");

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "OfficerMilitaryDegrees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "DisplayOrder",
                table: "AssistantMilitaryDegrees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssistantMilitaryDegrees",
                table: "AssistantMilitaryDegrees",
                column: "Id");

            migrationBuilder.InsertData(
                table: "OfficerMilitaryDegrees",
                columns: new[] { "Id", "CreatedAt", "Degree", "DisplayOrder", "IsDeleted", "UpdatedAt" },
                values: new object[,]
                {
                    { 1L, null, "ملازم", 1, false, null },
                    { 2L, null, "ملازم أول", 2, false, null },
                    { 3L, null, "نقيب", 3, false, null },
                    { 4L, null, "رائد", 4, false, null },
                    { 5L, null, "مقدم", 5, false, null },
                    { 6L, null, "عقيد", 6, false, null },
                    { 7L, null, "عميد", 7, false, null },
                    { 8L, null, "لواء", 8, false, null },
                    { 9L, null, "مساعد وزير", 8, false, null },
                    { 10L, null, "مساعد أول وزير", 8, false, null }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_PoliceAssistants_AssistantMilitaryDegrees_AssistantsMilitaryDegreeId",
                table: "PoliceAssistants",
                column: "AssistantsMilitaryDegreeId",
                principalTable: "AssistantMilitaryDegrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PoliceAssistants_AssistantMilitaryDegrees_AssistantsMilitaryDegreeId",
                table: "PoliceAssistants");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AssistantMilitaryDegrees",
                table: "AssistantMilitaryDegrees");

            migrationBuilder.DeleteData(
                table: "OfficerMilitaryDegrees",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "OfficerMilitaryDegrees",
                keyColumn: "Id",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "OfficerMilitaryDegrees",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "OfficerMilitaryDegrees",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "OfficerMilitaryDegrees",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "OfficerMilitaryDegrees",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "OfficerMilitaryDegrees",
                keyColumn: "Id",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "OfficerMilitaryDegrees",
                keyColumn: "Id",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "OfficerMilitaryDegrees",
                keyColumn: "Id",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "OfficerMilitaryDegrees",
                keyColumn: "Id",
                keyValue: 10L);

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "OfficerMilitaryDegrees");

            migrationBuilder.DropColumn(
                name: "DisplayOrder",
                table: "AssistantMilitaryDegrees");

            migrationBuilder.RenameTable(
                name: "AssistantMilitaryDegrees",
                newName: "AssistantsMilitaryDegrees");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AssistantsMilitaryDegrees",
                table: "AssistantsMilitaryDegrees",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PoliceAssistants_AssistantsMilitaryDegrees_AssistantsMilitaryDegreeId",
                table: "PoliceAssistants",
                column: "AssistantsMilitaryDegreeId",
                principalTable: "AssistantsMilitaryDegrees",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
