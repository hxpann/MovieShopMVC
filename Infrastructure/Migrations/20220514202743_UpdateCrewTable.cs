using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class UpdateCrewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Crew_Crew_CrewId",
                table: "Crew");

            migrationBuilder.DropIndex(
                name: "IX_Crew_CrewId",
                table: "Crew");

            migrationBuilder.DropColumn(
                name: "CrewId",
                table: "Crew");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CrewId",
                table: "Crew",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Crew_CrewId",
                table: "Crew",
                column: "CrewId");

            migrationBuilder.AddForeignKey(
                name: "FK_Crew_Crew_CrewId",
                table: "Crew",
                column: "CrewId",
                principalTable: "Crew",
                principalColumn: "Id");
        }
    }
}
