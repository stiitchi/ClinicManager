using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    public partial class fix18 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BloodGlucoseId",
                schema: "dbo",
                table: "ObservationRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "BloodId",
                schema: "dbo",
                table: "ObservationRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NeuroLogicalId",
                schema: "dbo",
                table: "ObservationRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NeuroVascularId",
                schema: "dbo",
                table: "ObservationRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UrineTestId",
                schema: "dbo",
                table: "ObservationRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "VitalSignId",
                schema: "dbo",
                table: "ObservationRecords",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BloodGlucoseId",
                schema: "dbo",
                table: "ObservationRecords");

            migrationBuilder.DropColumn(
                name: "BloodId",
                schema: "dbo",
                table: "ObservationRecords");

            migrationBuilder.DropColumn(
                name: "NeuroLogicalId",
                schema: "dbo",
                table: "ObservationRecords");

            migrationBuilder.DropColumn(
                name: "NeuroVascularId",
                schema: "dbo",
                table: "ObservationRecords");

            migrationBuilder.DropColumn(
                name: "UrineTestId",
                schema: "dbo",
                table: "ObservationRecords");

            migrationBuilder.DropColumn(
                name: "VitalSignId",
                schema: "dbo",
                table: "ObservationRecords");
        }
    }
}
