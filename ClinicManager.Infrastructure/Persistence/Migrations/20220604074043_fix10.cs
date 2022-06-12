using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    public partial class fix10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ICDCodes_Patients_PatientId",
                schema: "dbo",
                table: "ICDCodes");

            migrationBuilder.AddForeignKey(
                name: "FK_ICDCodes_Patients_PatientId",
                schema: "dbo",
                table: "ICDCodes",
                column: "PatientId",
                principalSchema: "dbo",
                principalTable: "Patients",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ICDCodes_Patients_PatientId",
                schema: "dbo",
                table: "ICDCodes");

            migrationBuilder.AddForeignKey(
                name: "FK_ICDCodes_Patients_PatientId",
                schema: "dbo",
                table: "ICDCodes",
                column: "PatientId",
                principalSchema: "dbo",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
