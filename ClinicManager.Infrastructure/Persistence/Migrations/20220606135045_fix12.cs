using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    public partial class fix12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WardNumber",
                schema: "dbo",
                table: "Beds",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AdmissionTime",
                schema: "dbo",
                table: "Admissions",
                type: "datetime2",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time",
                oldMaxLength: 200);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WardNumber",
                schema: "dbo",
                table: "Beds");

            migrationBuilder.AlterColumn<TimeSpan>(
                name: "AdmissionTime",
                schema: "dbo",
                table: "Admissions",
                type: "time",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldMaxLength: 200);
        }
    }
}
