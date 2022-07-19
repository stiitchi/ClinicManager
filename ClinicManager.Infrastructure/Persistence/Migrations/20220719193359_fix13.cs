using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    public partial class fix13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WardEntityId",
                schema: "dbo",
                table: "Doctors",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_WardEntityId",
                schema: "dbo",
                table: "Doctors",
                column: "WardEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Doctors_Wards_WardEntityId",
                schema: "dbo",
                table: "Doctors",
                column: "WardEntityId",
                principalSchema: "dbo",
                principalTable: "Wards",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Doctors_Wards_WardEntityId",
                schema: "dbo",
                table: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_Doctors_WardEntityId",
                schema: "dbo",
                table: "Doctors");

            migrationBuilder.DropColumn(
                name: "WardEntityId",
                schema: "dbo",
                table: "Doctors");
        }
    }
}
