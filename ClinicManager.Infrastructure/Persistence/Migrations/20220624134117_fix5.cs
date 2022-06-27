using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    public partial class fix5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PatientBeds_Wards_WardId",
                schema: "dbo",
                table: "PatientBeds");

            migrationBuilder.DropIndex(
                name: "IX_PatientBeds_WardId",
                schema: "dbo",
                table: "PatientBeds");

            migrationBuilder.DropColumn(
                name: "WardId",
                schema: "dbo",
                table: "PatientBeds");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WardId",
                schema: "dbo",
                table: "PatientBeds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PatientBeds_WardId",
                schema: "dbo",
                table: "PatientBeds",
                column: "WardId");

            migrationBuilder.AddForeignKey(
                name: "FK_PatientBeds_Wards_WardId",
                schema: "dbo",
                table: "PatientBeds",
                column: "WardId",
                principalSchema: "dbo",
                principalTable: "Wards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
