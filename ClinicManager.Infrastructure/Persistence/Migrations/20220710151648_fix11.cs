using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    public partial class fix11 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OccupiedBeds",
                schema: "dbo",
                table: "Wards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnOccupiedBeds",
                schema: "dbo",
                table: "Wards",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OccupiedBeds",
                schema: "dbo",
                table: "Wards");

            migrationBuilder.DropColumn(
                name: "UnOccupiedBeds",
                schema: "dbo",
                table: "Wards");
        }
    }
}
