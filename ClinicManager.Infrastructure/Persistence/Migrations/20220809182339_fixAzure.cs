using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    public partial class fixAzure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PdfPath",
                schema: "dbo",
                table: "Subscriptions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PdfPath",
                schema: "dbo",
                table: "Subscriptions");
        }
    }
}
