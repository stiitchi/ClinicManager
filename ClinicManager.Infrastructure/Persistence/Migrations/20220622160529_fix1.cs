using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    public partial class fix1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ContactNO",
                schema: "dbo",
                table: "Patients",
                newName: "EmergencyContactNo");

            migrationBuilder.AddColumn<string>(
                name: "DependentCode",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "EmergencyContactIdNo",
                schema: "dbo",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Language",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Race",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Stage",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DependentCode",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "EmergencyContactIdNo",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Gender",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Language",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Location",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Race",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Stage",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "EmergencyContactNo",
                schema: "dbo",
                table: "Patients",
                newName: "ContactNO");
        }
    }
}
