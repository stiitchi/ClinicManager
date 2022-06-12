using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    public partial class fix14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beds_Patients_PatientId",
                schema: "dbo",
                table: "Beds");

            migrationBuilder.DropForeignKey(
                name: "FK_Beds_Users_NurseId",
                schema: "dbo",
                table: "Beds");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                schema: "dbo",
                table: "Beds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "NurseId",
                schema: "dbo",
                table: "Beds",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Beds_Patients_PatientId",
                schema: "dbo",
                table: "Beds",
                column: "PatientId",
                principalSchema: "dbo",
                principalTable: "Patients",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Beds_Users_NurseId",
                schema: "dbo",
                table: "Beds",
                column: "NurseId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Beds_Patients_PatientId",
                schema: "dbo",
                table: "Beds");

            migrationBuilder.DropForeignKey(
                name: "FK_Beds_Users_NurseId",
                schema: "dbo",
                table: "Beds");

            migrationBuilder.AlterColumn<int>(
                name: "PatientId",
                schema: "dbo",
                table: "Beds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "NurseId",
                schema: "dbo",
                table: "Beds",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Beds_Patients_PatientId",
                schema: "dbo",
                table: "Beds",
                column: "PatientId",
                principalSchema: "dbo",
                principalTable: "Patients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Beds_Users_NurseId",
                schema: "dbo",
                table: "Beds",
                column: "NurseId",
                principalSchema: "dbo",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
