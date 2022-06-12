using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    public partial class fix11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayFees_Patients_PatientId",
                schema: "dbo",
                table: "DayFees");

            migrationBuilder.DropForeignKey(
                name: "FK_ICDCodes_Patients_PatientId",
                schema: "dbo",
                table: "ICDCodes");

            migrationBuilder.DropIndex(
                name: "IX_ICDCodes_PatientId",
                schema: "dbo",
                table: "ICDCodes");

            migrationBuilder.DropIndex(
                name: "IX_DayFees_PatientId",
                schema: "dbo",
                table: "DayFees");

            migrationBuilder.DropColumn(
                name: "PatientId",
                schema: "dbo",
                table: "ICDCodes");

            migrationBuilder.DropColumn(
                name: "PatientId",
                schema: "dbo",
                table: "DayFees");

            migrationBuilder.AddColumn<int>(
                name: "PatientEntityId",
                schema: "dbo",
                table: "ICDCodes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PatientEntityId",
                schema: "dbo",
                table: "DayFees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ICDCodes_PatientEntityId",
                schema: "dbo",
                table: "ICDCodes",
                column: "PatientEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DayFees_PatientEntityId",
                schema: "dbo",
                table: "DayFees",
                column: "PatientEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayFees_Patients_PatientEntityId",
                schema: "dbo",
                table: "DayFees",
                column: "PatientEntityId",
                principalSchema: "dbo",
                principalTable: "Patients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_ICDCodes_Patients_PatientEntityId",
                schema: "dbo",
                table: "ICDCodes",
                column: "PatientEntityId",
                principalSchema: "dbo",
                principalTable: "Patients",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DayFees_Patients_PatientEntityId",
                schema: "dbo",
                table: "DayFees");

            migrationBuilder.DropForeignKey(
                name: "FK_ICDCodes_Patients_PatientEntityId",
                schema: "dbo",
                table: "ICDCodes");

            migrationBuilder.DropIndex(
                name: "IX_ICDCodes_PatientEntityId",
                schema: "dbo",
                table: "ICDCodes");

            migrationBuilder.DropIndex(
                name: "IX_DayFees_PatientEntityId",
                schema: "dbo",
                table: "DayFees");

            migrationBuilder.DropColumn(
                name: "PatientEntityId",
                schema: "dbo",
                table: "ICDCodes");

            migrationBuilder.DropColumn(
                name: "PatientEntityId",
                schema: "dbo",
                table: "DayFees");

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                schema: "dbo",
                table: "ICDCodes",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PatientId",
                schema: "dbo",
                table: "DayFees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_ICDCodes_PatientId",
                schema: "dbo",
                table: "ICDCodes",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DayFees_PatientId",
                schema: "dbo",
                table: "DayFees",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_DayFees_Patients_PatientId",
                schema: "dbo",
                table: "DayFees",
                column: "PatientId",
                principalSchema: "dbo",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ICDCodes_Patients_PatientId",
                schema: "dbo",
                table: "ICDCodes",
                column: "PatientId",
                principalSchema: "dbo",
                principalTable: "Patients",
                principalColumn: "Id");
        }
    }
}
