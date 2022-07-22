using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    public partial class fix2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodOxygenChartEntries",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodOxygenChartEntry = table.Column<double>(type: "float", nullable: false),
                    BloodOxygenChartId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodOxygenChartEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodOxygenChartEntries_BloodOxygenCharts_BloodOxygenChartId",
                        column: x => x.BloodOxygenChartId,
                        principalSchema: "dbo",
                        principalTable: "BloodOxygenCharts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodOxygenChartEntries_BloodOxygenChartId",
                schema: "dbo",
                table: "BloodOxygenChartEntries",
                column: "BloodOxygenChartId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodOxygenChartEntries_Id",
                schema: "dbo",
                table: "BloodOxygenChartEntries",
                column: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodOxygenChartEntries",
                schema: "dbo");
        }
    }
}
