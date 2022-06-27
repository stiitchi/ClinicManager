using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    public partial class fix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PatientBeds",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BedId = table.Column<int>(type: "int", nullable: false),
                    WardId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientBeds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientBeds_Beds_BedId",
                        column: x => x.BedId,
                        principalSchema: "dbo",
                        principalTable: "Beds",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PatientBeds_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PatientBeds_Wards_WardId",
                        column: x => x.WardId,
                        principalSchema: "dbo",
                        principalTable: "Wards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PatientBeds_BedId",
                schema: "dbo",
                table: "PatientBeds",
                column: "BedId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientBeds_Id",
                schema: "dbo",
                table: "PatientBeds",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PatientBeds_PatientId",
                schema: "dbo",
                table: "PatientBeds",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientBeds_WardId",
                schema: "dbo",
                table: "PatientBeds",
                column: "WardId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PatientBeds",
                schema: "dbo");
        }
    }
}
