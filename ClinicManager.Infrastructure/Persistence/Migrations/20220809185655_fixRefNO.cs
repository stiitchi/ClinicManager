using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    public partial class fixRefNO : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ReferenceNumber",
                schema: "dbo",
                table: "Subscriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ReferenceNumber",
                schema: "dbo",
                table: "Subscriptions");
        }
    }
}
