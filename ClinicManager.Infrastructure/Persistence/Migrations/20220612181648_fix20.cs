using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    public partial class fix20 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CarePlanFluids",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "EliminationRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FluidBalanceRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HygieneRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "InterventionRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MobilityRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "NutritionRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ObservationRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OxygenationRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PsychologicalRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SafetyRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SkinIntegrityReportRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "StoolReportRecords",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "AssistIntoChairRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssistIntoChairTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AssistIntoChairFrequency = table.Column<int>(type: "int", nullable: false),
                    AssistIntoChairSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssistIntoChairRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AssistIntoChairRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BedBathAssistRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedBathAssistTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BedBathAssistFrequency = table.Column<int>(type: "int", nullable: false),
                    BedBathAssistSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BedBathAssistRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BedBathAssistRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BedBathRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedBathTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BedBathFrequency = table.Column<int>(type: "int", nullable: false),
                    BedBathSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BedBathRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BedBathRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BedRestRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedRestTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BedRestFrequency = table.Column<int>(type: "int", nullable: false),
                    BedRestSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BedRestRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BedRestRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BloodGlucoseRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodGlucoseTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BloodGlucoseFrequency = table.Column<int>(type: "int", nullable: false),
                    BloodGlucoseSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodGlucoseRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodGlucoseRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BloodRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BloodFrequency = table.Column<int>(type: "int", nullable: false),
                    BloodSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarePlanCheckIVSiteTests",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckIVSiteTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CheckIVSiteFrequency = table.Column<int>(type: "int", nullable: false),
                    CheckIVSiteSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePlanCheckIVSiteTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarePlanCheckIVSiteTests_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarePlanIVTests",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IvTestTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IvTestFrequency = table.Column<int>(type: "int", nullable: false),
                    IvTestSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePlanIVTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarePlanIVTests_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarePlanMonitorFluidRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MonitorFluidTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    MonitorFluidFrequency = table.Column<int>(type: "int", nullable: false),
                    MonitorFluidSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePlanMonitorFluidRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarePlanMonitorFluidRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarePlanOralRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OralTestTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OralTestFrequency = table.Column<int>(type: "int", nullable: false),
                    OralTestSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePlanOralRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarePlanOralRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CarePlanTubeTests",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TubeTestTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    TubeTestFrequency = table.Column<int>(type: "int", nullable: false),
                    TubeTestSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePlanTubeTests", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarePlanTubeTests_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CathetherRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CathetherTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CathetherFrequency = table.Column<int>(type: "int", nullable: false),
                    CathetherSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CathetherRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CathetherRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CheckIDBandsRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CheckIDBandsTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CheckIDBandsFrequency = table.Column<int>(type: "int", nullable: false),
                    CheckIDBandsSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CheckIDBandsRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CheckIDBandsRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommunicationRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CommunicationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CommunicationFrequency = table.Column<int>(type: "int", nullable: false),
                    CommunicationSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommunicationRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CommunicationRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ContinentRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ContinentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContinentFrequency = table.Column<int>(type: "int", nullable: false),
                    ContinentSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ContinentRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ContinentRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CotsideRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CotsidesTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CotsidesFrequency = table.Column<int>(type: "int", nullable: false),
                    CotsidesSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CotsideRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CotsideRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExerciseRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ExercisesTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExercisesFrequency = table.Column<int>(type: "int", nullable: false),
                    ExercisesSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExerciseRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ExerciseRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FullWardDietRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullWardDietTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FullWardDietFrequency = table.Column<int>(type: "int", nullable: false),
                    FullWardDietSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FullWardDietRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FullWardDietRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HealthEducationRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HealthEducationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HealthEducationFrequency = table.Column<int>(type: "int", nullable: false),
                    HealthEducationSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthEducationRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HealthEducationRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InhalaNebsRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InhalaNebsTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    InhalaNebsFrequency = table.Column<int>(type: "int", nullable: false),
                    InhalaNebsSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InhalaNebsRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InhalaNebsRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IntravenousRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IntravenousIntakeMl = table.Column<int>(type: "int", nullable: false),
                    IntravenousIntakeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IntravenousIntakeTimeCompleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IntravenousIntakeStartVolume = table.Column<int>(type: "int", nullable: false),
                    IntravenousIntakeCompleteVolume = table.Column<int>(type: "int", nullable: false),
                    IvCheck = table.Column<bool>(type: "bit", nullable: false),
                    IvDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IntravenousRunningTotal = table.Column<int>(type: "int", nullable: false),
                    IvCheckType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IntravenousRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IntravenousRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IsolationRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsolationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsolationFrequency = table.Column<int>(type: "int", nullable: false),
                    IsolationSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IsolationRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IsolationRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "KeepNpoRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KeepNPOTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KeepNPOFrequency = table.Column<int>(type: "int", nullable: false),
                    KeepNPOSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KeepNpoRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_KeepNpoRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaskRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaskTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MaskFrequency = table.Column<int>(type: "int", nullable: false),
                    MaskSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MaskRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MaskRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MedicationRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MedicationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedicationFrequency = table.Column<int>(type: "int", nullable: false),
                    MedicationSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicationRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicationRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MobileImmobileRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MobileImmobileTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MobileImmobileFrequency = table.Column<int>(type: "int", nullable: false),
                    MobileImmobileSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobileImmobileRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MobileImmobileRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NasalCannulaRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NasalCannulaTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NasalCannulaFrequency = table.Column<int>(type: "int", nullable: false),
                    NasalCannulaSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NasalCannulaRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NasalCannulaRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NeurologicalRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NeuroLogicalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NeuroLogicalFrequency = table.Column<int>(type: "int", nullable: false),
                    NeuroLogicalSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeurologicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NeurologicalRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NeurovascularRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NeuroVascularTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NeuroVascularFrequency = table.Column<int>(type: "int", nullable: false),
                    NeuroVascularSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NeurovascularRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NeurovascularRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OralIntakeRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OralIntakeMl = table.Column<int>(type: "int", nullable: false),
                    OralIntakeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OralIntakeVolume = table.Column<int>(type: "int", nullable: false),
                    OralCheckType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OutputMl = table.Column<int>(type: "int", nullable: false),
                    IsUrine = table.Column<bool>(type: "bit", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OralIntakeRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OralIntakeRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OralOutputRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OutputMl = table.Column<int>(type: "int", nullable: false),
                    RunningOutputTotal = table.Column<int>(type: "int", nullable: false),
                    OralOutputTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsUrine = table.Column<bool>(type: "bit", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OralOutputRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OralOutputRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientDayFees",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayFeesId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDayFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientDayFees_DayFees_DayFeesId",
                        column: x => x.DayFeesId,
                        principalSchema: "dbo",
                        principalTable: "DayFees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientDayFees_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientDoctor",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientDoctor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientDoctor_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientDoctor_Users_DoctorId",
                        column: x => x.DoctorId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientICDCodes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IcdCodeId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientICDCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientICDCodes_ICDCodes_IcdCodeId",
                        column: x => x.IcdCodeId,
                        principalSchema: "dbo",
                        principalTable: "ICDCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientICDCodes_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PatientNurses",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NurseId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PatientNurses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PatientNurses_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientNurses_Users_NurseId",
                        column: x => x.NurseId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PolyMaskRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PolyMaskTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PolyMaskFrequency = table.Column<int>(type: "int", nullable: false),
                    PolyMaskSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PolyMaskRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PolyMaskRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PostOperativeCareRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PostOperativeCareTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostOperativeCareFrequency = table.Column<int>(type: "int", nullable: false),
                    PostOperativeCareSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PostOperativeCareRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PostOperativeCareRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PressurePartRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PressurePartCareTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PressurePartCareFrequency = table.Column<int>(type: "int", nullable: false),
                    PressurePartCareSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PressurePartRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PressurePartRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Previous24HourRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Previous24HourIntake = table.Column<int>(type: "int", nullable: false),
                    Previous24HourOutput = table.Column<int>(type: "int", nullable: false),
                    Total24HourIntake = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Previous24HourRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Previous24HourRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ReportRednessRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ReportRednessTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportRednessFrequency = table.Column<int>(type: "int", nullable: false),
                    ReportRednessSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReportRednessRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ReportRednessRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SelfCareRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SelfCareTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SelfCareFrequency = table.Column<int>(type: "int", nullable: false),
                    SelfCareSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SelfCareRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SelfCareRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SpecialRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SpecialTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpecialFrequency = table.Column<int>(type: "int", nullable: false),
                    SpecialSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecialRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SpecialRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoolChartRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NormalBowelHabit = table.Column<bool>(type: "bit", nullable: false),
                    StoolChartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StoolChartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StoolColour = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Blood = table.Column<bool>(type: "bit", nullable: false),
                    MucousAmount = table.Column<int>(type: "int", nullable: false),
                    BowelAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Consistency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoolChartRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoolChartRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SupportRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupportTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupportFrequency = table.Column<int>(type: "int", nullable: false),
                    SupportSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SupportRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SupportRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TractionRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TractionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TractionFrequency = table.Column<int>(type: "int", nullable: false),
                    TractionSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TractionRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TractionRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UrineTestRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UrineTestTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UrineTestFrequency = table.Column<int>(type: "int", nullable: false),
                    UrineTestSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UrineTestRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UrineTestRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VitalSignRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VitalSignsTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VitalSignsFrequency = table.Column<int>(type: "int", nullable: false),
                    VitalSignSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VitalSignRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VitalSignRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WalkAssistanceRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WalkWithAssistanceTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WalkWithAssistanceFrequency = table.Column<int>(type: "int", nullable: false),
                    WalkWithAssistanceSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WalkAssistanceRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WalkAssistanceRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WoundCareRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WoundCareTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WoundCareFrequency = table.Column<int>(type: "int", nullable: false),
                    WoundCareSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WoundCareRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_WoundCareRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AssistIntoChairRecords_Id",
                schema: "dbo",
                table: "AssistIntoChairRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_AssistIntoChairRecords_PatientId",
                schema: "dbo",
                table: "AssistIntoChairRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_BedBathAssistRecords_Id",
                schema: "dbo",
                table: "BedBathAssistRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BedBathAssistRecords_PatientId",
                schema: "dbo",
                table: "BedBathAssistRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_BedBathRecords_Id",
                schema: "dbo",
                table: "BedBathRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BedBathRecords_PatientId",
                schema: "dbo",
                table: "BedBathRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_BedRestRecords_Id",
                schema: "dbo",
                table: "BedRestRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BedRestRecords_PatientId",
                schema: "dbo",
                table: "BedRestRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodGlucoseRecords_Id",
                schema: "dbo",
                table: "BloodGlucoseRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BloodGlucoseRecords_PatientId",
                schema: "dbo",
                table: "BloodGlucoseRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRecords_Id",
                schema: "dbo",
                table: "BloodRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BloodRecords_PatientId",
                schema: "dbo",
                table: "BloodRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanCheckIVSiteTests_Id",
                schema: "dbo",
                table: "CarePlanCheckIVSiteTests",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanCheckIVSiteTests_PatientId",
                schema: "dbo",
                table: "CarePlanCheckIVSiteTests",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanIVTests_Id",
                schema: "dbo",
                table: "CarePlanIVTests",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanIVTests_PatientId",
                schema: "dbo",
                table: "CarePlanIVTests",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanMonitorFluidRecords_Id",
                schema: "dbo",
                table: "CarePlanMonitorFluidRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanMonitorFluidRecords_PatientId",
                schema: "dbo",
                table: "CarePlanMonitorFluidRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanOralRecords_Id",
                schema: "dbo",
                table: "CarePlanOralRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanOralRecords_PatientId",
                schema: "dbo",
                table: "CarePlanOralRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanTubeTests_Id",
                schema: "dbo",
                table: "CarePlanTubeTests",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanTubeTests_PatientId",
                schema: "dbo",
                table: "CarePlanTubeTests",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_CathetherRecords_Id",
                schema: "dbo",
                table: "CathetherRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CathetherRecords_PatientId",
                schema: "dbo",
                table: "CathetherRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_CheckIDBandsRecords_Id",
                schema: "dbo",
                table: "CheckIDBandsRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CheckIDBandsRecords_PatientId",
                schema: "dbo",
                table: "CheckIDBandsRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationRecords_Id",
                schema: "dbo",
                table: "CommunicationRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CommunicationRecords_PatientId",
                schema: "dbo",
                table: "CommunicationRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ContinentRecords_Id",
                schema: "dbo",
                table: "ContinentRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ContinentRecords_PatientId",
                schema: "dbo",
                table: "ContinentRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_CotsideRecords_Id",
                schema: "dbo",
                table: "CotsideRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CotsideRecords_PatientId",
                schema: "dbo",
                table: "CotsideRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseRecords_Id",
                schema: "dbo",
                table: "ExerciseRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ExerciseRecords_PatientId",
                schema: "dbo",
                table: "ExerciseRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_FullWardDietRecords_Id",
                schema: "dbo",
                table: "FullWardDietRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FullWardDietRecords_PatientId",
                schema: "dbo",
                table: "FullWardDietRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_HealthEducationRecords_Id",
                schema: "dbo",
                table: "HealthEducationRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_HealthEducationRecords_PatientId",
                schema: "dbo",
                table: "HealthEducationRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_InhalaNebsRecords_Id",
                schema: "dbo",
                table: "InhalaNebsRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_InhalaNebsRecords_PatientId",
                schema: "dbo",
                table: "InhalaNebsRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_IntravenousRecords_Id",
                schema: "dbo",
                table: "IntravenousRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_IntravenousRecords_PatientId",
                schema: "dbo",
                table: "IntravenousRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_IsolationRecords_Id",
                schema: "dbo",
                table: "IsolationRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_IsolationRecords_PatientId",
                schema: "dbo",
                table: "IsolationRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_KeepNpoRecords_Id",
                schema: "dbo",
                table: "KeepNpoRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_KeepNpoRecords_PatientId",
                schema: "dbo",
                table: "KeepNpoRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MaskRecords_Id",
                schema: "dbo",
                table: "MaskRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MaskRecords_PatientId",
                schema: "dbo",
                table: "MaskRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationRecords_Id",
                schema: "dbo",
                table: "MedicationRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MedicationRecords_PatientId",
                schema: "dbo",
                table: "MedicationRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MobileImmobileRecords_Id",
                schema: "dbo",
                table: "MobileImmobileRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MobileImmobileRecords_PatientId",
                schema: "dbo",
                table: "MobileImmobileRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_NasalCannulaRecords_Id",
                schema: "dbo",
                table: "NasalCannulaRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_NasalCannulaRecords_PatientId",
                schema: "dbo",
                table: "NasalCannulaRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_NeurologicalRecords_Id",
                schema: "dbo",
                table: "NeurologicalRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_NeurologicalRecords_PatientId",
                schema: "dbo",
                table: "NeurologicalRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_NeurovascularRecords_Id",
                schema: "dbo",
                table: "NeurovascularRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_NeurovascularRecords_PatientId",
                schema: "dbo",
                table: "NeurovascularRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_OralIntakeRecords_Id",
                schema: "dbo",
                table: "OralIntakeRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OralIntakeRecords_PatientId",
                schema: "dbo",
                table: "OralIntakeRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_OralOutputRecords_Id",
                schema: "dbo",
                table: "OralOutputRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OralOutputRecords_PatientId",
                schema: "dbo",
                table: "OralOutputRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDayFees_DayFeesId",
                schema: "dbo",
                table: "PatientDayFees",
                column: "DayFeesId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDayFees_Id",
                schema: "dbo",
                table: "PatientDayFees",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDayFees_PatientId",
                schema: "dbo",
                table: "PatientDayFees",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDoctor_DoctorId",
                schema: "dbo",
                table: "PatientDoctor",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDoctor_Id",
                schema: "dbo",
                table: "PatientDoctor",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PatientDoctor_PatientId",
                schema: "dbo",
                table: "PatientDoctor",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientICDCodes_IcdCodeId",
                schema: "dbo",
                table: "PatientICDCodes",
                column: "IcdCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientICDCodes_Id",
                schema: "dbo",
                table: "PatientICDCodes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PatientICDCodes_PatientId",
                schema: "dbo",
                table: "PatientICDCodes",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientNurses_Id",
                schema: "dbo",
                table: "PatientNurses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PatientNurses_NurseId",
                schema: "dbo",
                table: "PatientNurses",
                column: "NurseId");

            migrationBuilder.CreateIndex(
                name: "IX_PatientNurses_PatientId",
                schema: "dbo",
                table: "PatientNurses",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PolyMaskRecords_Id",
                schema: "dbo",
                table: "PolyMaskRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PolyMaskRecords_PatientId",
                schema: "dbo",
                table: "PolyMaskRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PostOperativeCareRecords_Id",
                schema: "dbo",
                table: "PostOperativeCareRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PostOperativeCareRecords_PatientId",
                schema: "dbo",
                table: "PostOperativeCareRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PressurePartRecords_Id",
                schema: "dbo",
                table: "PressurePartRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PressurePartRecords_PatientId",
                schema: "dbo",
                table: "PressurePartRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Previous24HourRecords_Id",
                schema: "dbo",
                table: "Previous24HourRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Previous24HourRecords_PatientId",
                schema: "dbo",
                table: "Previous24HourRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ReportRednessRecords_Id",
                schema: "dbo",
                table: "ReportRednessRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ReportRednessRecords_PatientId",
                schema: "dbo",
                table: "ReportRednessRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_SelfCareRecords_Id",
                schema: "dbo",
                table: "SelfCareRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SelfCareRecords_PatientId",
                schema: "dbo",
                table: "SelfCareRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialRecords_Id",
                schema: "dbo",
                table: "SpecialRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SpecialRecords_PatientId",
                schema: "dbo",
                table: "SpecialRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_StoolChartRecords_Id",
                schema: "dbo",
                table: "StoolChartRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StoolChartRecords_PatientId",
                schema: "dbo",
                table: "StoolChartRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_SupportRecords_Id",
                schema: "dbo",
                table: "SupportRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SupportRecords_PatientId",
                schema: "dbo",
                table: "SupportRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_TractionRecords_Id",
                schema: "dbo",
                table: "TractionRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TractionRecords_PatientId",
                schema: "dbo",
                table: "TractionRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_UrineTestRecords_Id",
                schema: "dbo",
                table: "UrineTestRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UrineTestRecords_PatientId",
                schema: "dbo",
                table: "UrineTestRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_VitalSignRecords_Id",
                schema: "dbo",
                table: "VitalSignRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_VitalSignRecords_PatientId",
                schema: "dbo",
                table: "VitalSignRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_WalkAssistanceRecords_Id",
                schema: "dbo",
                table: "WalkAssistanceRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WalkAssistanceRecords_PatientId",
                schema: "dbo",
                table: "WalkAssistanceRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_WoundCareRecords_Id",
                schema: "dbo",
                table: "WoundCareRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_WoundCareRecords_PatientId",
                schema: "dbo",
                table: "WoundCareRecords",
                column: "PatientId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AssistIntoChairRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BedBathAssistRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BedBathRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BedRestRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BloodGlucoseRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BloodRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CarePlanCheckIVSiteTests",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CarePlanIVTests",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CarePlanMonitorFluidRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CarePlanOralRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CarePlanTubeTests",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CathetherRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CheckIDBandsRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CommunicationRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ContinentRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CotsideRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ExerciseRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "FullWardDietRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HealthEducationRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "InhalaNebsRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "IntravenousRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "IsolationRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "KeepNpoRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MaskRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MedicationRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "MobileImmobileRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "NasalCannulaRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "NeurologicalRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "NeurovascularRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OralIntakeRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "OralOutputRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PatientDayFees",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PatientDoctor",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PatientICDCodes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PatientNurses",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PolyMaskRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PostOperativeCareRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "PressurePartRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Previous24HourRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ReportRednessRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SelfCareRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SpecialRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "StoolChartRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SupportRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TractionRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UrineTestRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "VitalSignRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WalkAssistanceRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "WoundCareRecords",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "CarePlanFluids",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    CheckIVSiteFrequency = table.Column<int>(type: "int", nullable: false),
                    CheckIVSiteSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckIVSiteTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IvTestFrequency = table.Column<int>(type: "int", nullable: false),
                    IvTestSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IvTestTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    MonitorFluidFrequency = table.Column<int>(type: "int", nullable: false),
                    MonitorFluidSignatures = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonitorFluidTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    OralTestFrequency = table.Column<int>(type: "int", nullable: false),
                    OralTestSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OralTestTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    TubeTestFrequency = table.Column<int>(type: "int", nullable: false),
                    TubeTestSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TubeTestTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CarePlanFluids", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CarePlanFluids_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EliminationRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    CathetherFrequency = table.Column<int>(type: "int", nullable: false),
                    CathetherSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CathetherTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ContinentFrequency = table.Column<int>(type: "int", nullable: false),
                    ContinentSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContinentTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EliminationRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EliminationRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FluidBalanceRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IntravenousIntakeCompleteVolume = table.Column<int>(type: "int", nullable: false),
                    IntravenousIntakeMl = table.Column<int>(type: "int", nullable: false),
                    IntravenousIntakeStartVolume = table.Column<int>(type: "int", nullable: false),
                    IntravenousIntakeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IntravenousIntakeTimeCompleted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IntravenousRunningTotal = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsUrine = table.Column<bool>(type: "bit", nullable: false),
                    IvCheck = table.Column<bool>(type: "bit", nullable: false),
                    IvCheckType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IvDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OralCheckType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OralIntakeMl = table.Column<int>(type: "int", nullable: false),
                    OralIntakeTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    OralIntakeVolume = table.Column<int>(type: "int", nullable: false),
                    OutputMl = table.Column<int>(type: "int", nullable: false),
                    Previous24HourIntake = table.Column<int>(type: "int", nullable: false),
                    Previous24HourOutput = table.Column<int>(type: "int", nullable: false),
                    Total24HourIntake = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluidBalanceRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FluidBalanceRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "HygieneRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    BedBathAssistFrequency = table.Column<int>(type: "int", nullable: false),
                    BedBathAssistSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BedBathAssistTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BedBathFrequency = table.Column<int>(type: "int", nullable: false),
                    BedBathSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BedBathTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SelfCareFrequency = table.Column<int>(type: "int", nullable: false),
                    SelfCareSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SelfCareTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HygieneRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HygieneRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "InterventionRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsolationFrequency = table.Column<int>(type: "int", nullable: false),
                    IsolationSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsolationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MedicationFrequency = table.Column<int>(type: "int", nullable: false),
                    MedicationSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostOperativeCareFrequency = table.Column<int>(type: "int", nullable: false),
                    PostOperativeCareSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PostOperativeCareTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TractionFrequency = table.Column<int>(type: "int", nullable: false),
                    TractionSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TractionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WoundCareFrequency = table.Column<int>(type: "int", nullable: false),
                    WoundCareSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WoundCareTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InterventionRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InterventionRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MobilityRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    AssistIntoChairFrequency = table.Column<int>(type: "int", nullable: false),
                    AssistIntoChairSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AssistIntoChairTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BedRestFrequency = table.Column<int>(type: "int", nullable: false),
                    BedRestSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BedRestTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ExercisesFrequency = table.Column<int>(type: "int", nullable: false),
                    ExercisesSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ExercisesTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MobileImmobileFrequency = table.Column<int>(type: "int", nullable: false),
                    MobileImmobileSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MobileImmobileTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    WalkWithAssistanceFrequency = table.Column<int>(type: "int", nullable: false),
                    WalkWithAssistanceSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    WalkWithAssistanceTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MobilityRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MobilityRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "NutritionRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    FullWardDietFrequency = table.Column<int>(type: "int", nullable: false),
                    FullWardDietSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FullWardDietTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    KeepNPOFrequency = table.Column<int>(type: "int", nullable: false),
                    KeepNPOSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    KeepNPOTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SpecialFrequency = table.Column<int>(type: "int", nullable: false),
                    SpecialSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SpecialTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NutritionRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NutritionRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ObservationRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    BloodFrequency = table.Column<int>(type: "int", nullable: false),
                    BloodGlucoseFrequency = table.Column<int>(type: "int", nullable: false),
                    BloodGlucoseId = table.Column<int>(type: "int", nullable: false),
                    BloodGlucoseSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodGlucoseTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BloodId = table.Column<int>(type: "int", nullable: false),
                    BloodSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BloodTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    NeuroLogicalFrequency = table.Column<int>(type: "int", nullable: false),
                    NeuroLogicalId = table.Column<int>(type: "int", nullable: false),
                    NeuroLogicalSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NeuroLogicalTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NeuroVascularFrequency = table.Column<int>(type: "int", nullable: false),
                    NeuroVascularId = table.Column<int>(type: "int", nullable: false),
                    NeuroVascularSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NeuroVascularTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UrineTestFrequency = table.Column<int>(type: "int", nullable: false),
                    UrineTestId = table.Column<int>(type: "int", nullable: false),
                    UrineTestSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UrineTestTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VitalSignId = table.Column<int>(type: "int", nullable: false),
                    VitalSignSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    VitalSignsFrequency = table.Column<int>(type: "int", nullable: false),
                    VitalSignsTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ObservationRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ObservationRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OxygenationRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    InhalaNebsFrequency = table.Column<int>(type: "int", nullable: false),
                    InhalaNebsSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InhalaNebsTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MaskFrequency = table.Column<int>(type: "int", nullable: false),
                    MaskSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaskTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NasalCannulaFrequency = table.Column<int>(type: "int", nullable: false),
                    NasalCannulaSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NasalCannulaTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PolyMaskFrequency = table.Column<int>(type: "int", nullable: false),
                    PolyMaskSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PolyMaskTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OxygenationRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OxygenationRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PsychologicalRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    CommunicationFrequency = table.Column<int>(type: "int", nullable: false),
                    CommunicationSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CommunicationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HealthEducationFrequency = table.Column<int>(type: "int", nullable: false),
                    HealthEducationSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HealthEducationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    SupportFrequency = table.Column<int>(type: "int", nullable: false),
                    SupportSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SupportTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PsychologicalRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PsychologicalRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SafetyRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    CheckIDBandsFrequency = table.Column<int>(type: "int", nullable: false),
                    CheckIDBandsSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CheckIDBandsTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CotsidesFrequency = table.Column<int>(type: "int", nullable: false),
                    CotsidesSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CotsidesTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SafetyRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SafetyRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SkinIntegrityReportRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    PressurePartCareFrequency = table.Column<int>(type: "int", nullable: false),
                    PressurePartCareSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PressurePartCareTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportRednessFrequency = table.Column<int>(type: "int", nullable: false),
                    ReportRednessSignature = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReportRednessTime = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkinIntegrityReportRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkinIntegrityReportRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoolReportRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    Blood = table.Column<bool>(type: "bit", nullable: false),
                    BowelAmount = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Consistency = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    MucousAmount = table.Column<int>(type: "int", nullable: false),
                    NormalBowelHabit = table.Column<bool>(type: "bit", nullable: false),
                    StoolChartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StoolChartTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StoolColour = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoolReportRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoolReportRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanFluids_Id",
                schema: "dbo",
                table: "CarePlanFluids",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_CarePlanFluids_PatientId",
                schema: "dbo",
                table: "CarePlanFluids",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_EliminationRecords_Id",
                schema: "dbo",
                table: "EliminationRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_EliminationRecords_PatientId",
                schema: "dbo",
                table: "EliminationRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_FluidBalanceRecords_Id",
                schema: "dbo",
                table: "FluidBalanceRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_FluidBalanceRecords_PatientId",
                schema: "dbo",
                table: "FluidBalanceRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_HygieneRecords_Id",
                schema: "dbo",
                table: "HygieneRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_HygieneRecords_PatientId",
                schema: "dbo",
                table: "HygieneRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_InterventionRecords_Id",
                schema: "dbo",
                table: "InterventionRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_InterventionRecords_PatientId",
                schema: "dbo",
                table: "InterventionRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_MobilityRecords_Id",
                schema: "dbo",
                table: "MobilityRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_MobilityRecords_PatientId",
                schema: "dbo",
                table: "MobilityRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionRecords_Id",
                schema: "dbo",
                table: "NutritionRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_NutritionRecords_PatientId",
                schema: "dbo",
                table: "NutritionRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ObservationRecords_Id",
                schema: "dbo",
                table: "ObservationRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ObservationRecords_PatientId",
                schema: "dbo",
                table: "ObservationRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_OxygenationRecords_Id",
                schema: "dbo",
                table: "OxygenationRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_OxygenationRecords_PatientId",
                schema: "dbo",
                table: "OxygenationRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_PsychologicalRecords_Id",
                schema: "dbo",
                table: "PsychologicalRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_PsychologicalRecords_PatientId",
                schema: "dbo",
                table: "PsychologicalRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyRecords_Id",
                schema: "dbo",
                table: "SafetyRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SafetyRecords_PatientId",
                schema: "dbo",
                table: "SafetyRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_SkinIntegrityReportRecords_Id",
                schema: "dbo",
                table: "SkinIntegrityReportRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SkinIntegrityReportRecords_PatientId",
                schema: "dbo",
                table: "SkinIntegrityReportRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_StoolReportRecords_Id",
                schema: "dbo",
                table: "StoolReportRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_StoolReportRecords_PatientId",
                schema: "dbo",
                table: "StoolReportRecords",
                column: "PatientId");
        }
    }
}
