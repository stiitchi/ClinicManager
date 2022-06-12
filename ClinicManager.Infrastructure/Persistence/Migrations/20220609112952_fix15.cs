using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    public partial class fix15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                schema: "dbo",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "AltContact",
                schema: "dbo",
                table: "Admissions");

            migrationBuilder.RenameColumn(
                name: "MedicalAidMemberSurname",
                schema: "dbo",
                table: "Admissions",
                newName: "MedicalAidMemberRelationship");

            migrationBuilder.RenameColumn(
                name: "MedicalAidMemberName",
                schema: "dbo",
                table: "Admissions",
                newName: "MedicalAidMemberPostalAddressCode");

            migrationBuilder.RenameColumn(
                name: "MedicalAidMemberCode",
                schema: "dbo",
                table: "Admissions",
                newName: "MedicalAidMemberHomePostalCode");

            migrationBuilder.RenameColumn(
                name: "ContactNo",
                schema: "dbo",
                table: "Admissions",
                newName: "MedicalAidMemberHomeAddress");

            migrationBuilder.RenameColumn(
                name: "AltContactRelationship",
                schema: "dbo",
                table: "Admissions",
                newName: "MedicalAidMemberFullName");

            migrationBuilder.RenameColumn(
                name: "AltContactNo",
                schema: "dbo",
                table: "Admissions",
                newName: "HomeAddress");

            migrationBuilder.AlterColumn<string>(
                name: "PoBox",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "MedicalAidOption",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MedicalAidNo",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MedicalAidName",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "MedicalAidMemberTelNo",
                schema: "dbo",
                table: "Admissions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "MedicalAidMemberIdNo",
                schema: "dbo",
                table: "Admissions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MedicalAidMemberEmployer",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<int>(
                name: "MedicalAidMemberCellNo",
                schema: "dbo",
                table: "Admissions",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MedicalAidMemberBusinessPostalCode",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "MedicalAidMemberBusinessAddress",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "DependentCode",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "AuthNo",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "AltContactNoKin",
                schema: "dbo",
                table: "Admissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ContactNoKin",
                schema: "dbo",
                table: "Admissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OtherContact",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OtherContactNo",
                schema: "dbo",
                table: "Admissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OtherContactNoAlt",
                schema: "dbo",
                table: "Admissions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "OtherContactRelationship",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PostalCode",
                schema: "dbo",
                table: "Admissions",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AltContactNoKin",
                schema: "dbo",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "ContactNoKin",
                schema: "dbo",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "OtherContact",
                schema: "dbo",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "OtherContactNo",
                schema: "dbo",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "OtherContactNoAlt",
                schema: "dbo",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "OtherContactRelationship",
                schema: "dbo",
                table: "Admissions");

            migrationBuilder.DropColumn(
                name: "PostalCode",
                schema: "dbo",
                table: "Admissions");

            migrationBuilder.RenameColumn(
                name: "MedicalAidMemberRelationship",
                schema: "dbo",
                table: "Admissions",
                newName: "MedicalAidMemberSurname");

            migrationBuilder.RenameColumn(
                name: "MedicalAidMemberPostalAddressCode",
                schema: "dbo",
                table: "Admissions",
                newName: "MedicalAidMemberName");

            migrationBuilder.RenameColumn(
                name: "MedicalAidMemberHomePostalCode",
                schema: "dbo",
                table: "Admissions",
                newName: "MedicalAidMemberCode");

            migrationBuilder.RenameColumn(
                name: "MedicalAidMemberHomeAddress",
                schema: "dbo",
                table: "Admissions",
                newName: "ContactNo");

            migrationBuilder.RenameColumn(
                name: "MedicalAidMemberFullName",
                schema: "dbo",
                table: "Admissions",
                newName: "AltContactRelationship");

            migrationBuilder.RenameColumn(
                name: "HomeAddress",
                schema: "dbo",
                table: "Admissions",
                newName: "AltContactNo");

            migrationBuilder.AlterColumn<string>(
                name: "PoBox",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MedicalAidOption",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MedicalAidNo",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MedicalAidName",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MedicalAidMemberTelNo",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "MedicalAidMemberIdNo",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "MedicalAidMemberEmployer",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MedicalAidMemberCellNo",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<string>(
                name: "MedicalAidMemberBusinessPostalCode",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "MedicalAidMemberBusinessAddress",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "DependentCode",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "AuthNo",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "AltContact",
                schema: "dbo",
                table: "Admissions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
