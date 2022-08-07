using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    public partial class fix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OccupiedBeds",
                schema: "dbo",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UnoccupiedBeds",
                schema: "dbo",
                table: "Rooms",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OccupiedBeds",
                schema: "dbo",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "UnoccupiedBeds",
                schema: "dbo",
                table: "Rooms");
        }
    }
}
