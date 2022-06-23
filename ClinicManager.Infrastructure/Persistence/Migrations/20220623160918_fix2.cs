using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    public partial class fix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IcdCode",
                schema: "dbo",
                table: "PatientICDCodes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "IcdDescription",
                schema: "dbo",
                table: "PatientICDCodes",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DayFeeCode",
                schema: "dbo",
                table: "PatientDayFees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "DayFeeDescription",
                schema: "dbo",
                table: "PatientDayFees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IcdCode",
                schema: "dbo",
                table: "PatientICDCodes");

            migrationBuilder.DropColumn(
                name: "IcdDescription",
                schema: "dbo",
                table: "PatientICDCodes");

            migrationBuilder.DropColumn(
                name: "DayFeeCode",
                schema: "dbo",
                table: "PatientDayFees");

            migrationBuilder.DropColumn(
                name: "DayFeeDescription",
                schema: "dbo",
                table: "PatientDayFees");
        }
    }
}
