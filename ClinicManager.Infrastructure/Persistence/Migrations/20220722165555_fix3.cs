using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    public partial class fix3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodPressureChartEntries",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodPressureChartEntry = table.Column<double>(type: "float", nullable: false),
                    BloodPressureChartId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodPressureChartEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodPressureChartEntries_BloodPressureCharts_BloodPressureChartId",
                        column: x => x.BloodPressureChartId,
                        principalSchema: "dbo",
                        principalTable: "BloodPressureCharts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HeartRateChartEntries",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeartRateChartEntry = table.Column<double>(type: "float", nullable: false),
                    HeartRateChartId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeartRateChartEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeartRateChartEntries_HeartRateCharts_HeartRateChartId",
                        column: x => x.HeartRateChartId,
                        principalSchema: "dbo",
                        principalTable: "HeartRateCharts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RespitoryRateChartEntries",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RespitoryRateChartEntry = table.Column<double>(type: "float", nullable: false),
                    RespitoryRateChartId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespitoryRateChartEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespitoryRateChartEntries_RespitoryCharts_RespitoryRateChartId",
                        column: x => x.RespitoryRateChartId,
                        principalSchema: "dbo",
                        principalTable: "RespitoryCharts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TemperatureChartEntries",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TemperatureChartEntry = table.Column<double>(type: "float", nullable: false),
                    TemperatureChartId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperatureChartEntries", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemperatureChartEntries_TemperatureCharts_TemperatureChartId",
                        column: x => x.TemperatureChartId,
                        principalSchema: "dbo",
                        principalTable: "TemperatureCharts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BloodPressureChartEntries_BloodPressureChartId",
                schema: "dbo",
                table: "BloodPressureChartEntries",
                column: "BloodPressureChartId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodPressureChartEntries_Id",
                schema: "dbo",
                table: "BloodPressureChartEntries",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_HeartRateChartEntries_HeartRateChartId",
                schema: "dbo",
                table: "HeartRateChartEntries",
                column: "HeartRateChartId");

            migrationBuilder.CreateIndex(
                name: "IX_HeartRateChartEntries_Id",
                schema: "dbo",
                table: "HeartRateChartEntries",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RespitoryRateChartEntries_Id",
                schema: "dbo",
                table: "RespitoryRateChartEntries",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RespitoryRateChartEntries_RespitoryRateChartId",
                schema: "dbo",
                table: "RespitoryRateChartEntries",
                column: "RespitoryRateChartId");

            migrationBuilder.CreateIndex(
                name: "IX_TemperatureChartEntries_Id",
                schema: "dbo",
                table: "TemperatureChartEntries",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TemperatureChartEntries_TemperatureChartId",
                schema: "dbo",
                table: "TemperatureChartEntries",
                column: "TemperatureChartId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodPressureChartEntries",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HeartRateChartEntries",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RespitoryRateChartEntries",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TemperatureChartEntries",
                schema: "dbo");
        }
    }
}
