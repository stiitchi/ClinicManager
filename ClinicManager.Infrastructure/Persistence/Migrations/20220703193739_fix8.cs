using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    public partial class fix8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Dietician",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "EmergencyContactNo",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "Stage",
                schema: "dbo",
                table: "Patients",
                newName: "WoundStage");

            migrationBuilder.RenameColumn(
                name: "Relationship",
                schema: "dbo",
                table: "Patients",
                newName: "WoundLocation");

            migrationBuilder.RenameColumn(
                name: "Location",
                schema: "dbo",
                table: "Patients",
                newName: "WorkAddressProvince");

            migrationBuilder.RenameColumn(
                name: "EmergencyContactLastName",
                schema: "dbo",
                table: "Patients",
                newName: "WorkAddressPostalCode");

            migrationBuilder.RenameColumn(
                name: "EmergencyContactIdNo",
                schema: "dbo",
                table: "Patients",
                newName: "MedicalAidIdNumber");

            migrationBuilder.RenameColumn(
                name: "EmergencyContactFirstName",
                schema: "dbo",
                table: "Patients",
                newName: "WorkAddressCity");

            migrationBuilder.AlterColumn<string>(
                name: "MedicalAidNo",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "AuthNo",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "City",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "EmployerName",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Initials",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainMemberBusinessCity",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainMemberBusinessPostalCode",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainMemberBusinessProvince",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainMemberBusinessStreetAddress",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainMemberCellNo",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainMemberCity",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainMemberEmployer",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainMemberFirstName",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainMemberLastName",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainMemberOccupation",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainMemberPostalAddress",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainMemberPostalAddressCode",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainMemberProvince",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainMemberRelationship",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainMemberStreetAddress",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainMemberSuburb",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MainMemberTelNo",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NextOfKin",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NextOfKinAltContactNo",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NextOfKinContactNo",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "NextOfKinRelationship",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Occupation",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OtherContact",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OtherContactAltContactNo",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OtherContactNo",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "OtherContactRelationship",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PatientCellNo",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PatientTelNo",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PatientWorkTelNo",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PoBox",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PoBoxCode",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "PostalCode",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Province",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "StreetAddress",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "WorkAddress",
                schema: "dbo",
                table: "Patients",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AuthNo",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "City",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Email",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "EmployerName",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Initials",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MainMemberBusinessCity",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MainMemberBusinessPostalCode",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MainMemberBusinessProvince",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MainMemberBusinessStreetAddress",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MainMemberCellNo",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MainMemberCity",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MainMemberEmployer",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MainMemberFirstName",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MainMemberLastName",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MainMemberOccupation",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MainMemberPostalAddress",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MainMemberPostalAddressCode",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MainMemberProvince",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MainMemberRelationship",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MainMemberStreetAddress",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MainMemberSuburb",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "MainMemberTelNo",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "NextOfKin",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "NextOfKinAltContactNo",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "NextOfKinContactNo",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "NextOfKinRelationship",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Occupation",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "OtherContact",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "OtherContactAltContactNo",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "OtherContactNo",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "OtherContactRelationship",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientCellNo",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientTelNo",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PatientWorkTelNo",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PoBox",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PoBoxCode",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "Province",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "StreetAddress",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "WorkAddress",
                schema: "dbo",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "WoundStage",
                schema: "dbo",
                table: "Patients",
                newName: "Stage");

            migrationBuilder.RenameColumn(
                name: "WoundLocation",
                schema: "dbo",
                table: "Patients",
                newName: "Relationship");

            migrationBuilder.RenameColumn(
                name: "WorkAddressProvince",
                schema: "dbo",
                table: "Patients",
                newName: "Location");

            migrationBuilder.RenameColumn(
                name: "WorkAddressPostalCode",
                schema: "dbo",
                table: "Patients",
                newName: "EmergencyContactLastName");

            migrationBuilder.RenameColumn(
                name: "WorkAddressCity",
                schema: "dbo",
                table: "Patients",
                newName: "EmergencyContactFirstName");

            migrationBuilder.RenameColumn(
                name: "MedicalAidIdNumber",
                schema: "dbo",
                table: "Patients",
                newName: "EmergencyContactIdNo");

            migrationBuilder.AlterColumn<int>(
                name: "MedicalAidNo",
                schema: "dbo",
                table: "Patients",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<bool>(
                name: "Dietician",
                schema: "dbo",
                table: "Patients",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "EmergencyContactNo",
                schema: "dbo",
                table: "Patients",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
