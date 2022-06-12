using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    public partial class InitialDBCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "Admissions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseInformationNo = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    AccountNo = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", maxLength: 200, nullable: false),
                    AdmissionTime = table.Column<TimeSpan>(type: "time", maxLength: 200, nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Initials = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDNo = table.Column<int>(type: "int", nullable: false),
                    HomeTelNo = table.Column<int>(type: "int", nullable: false),
                    WorkTelNo = table.Column<int>(type: "int", nullable: false),
                    CellNo = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoBox = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PoBoxCode = table.Column<int>(type: "int", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Race = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkAddressPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NextOfKin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelationshipOfKin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AltContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AltContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AltContactRelationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidOption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DependentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberIdNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberTelNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberCellNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberPostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberEmployer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberBusinessAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberBusinessPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Patients",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseInformationNo = table.Column<int>(type: "int", nullable: false),
                    AccountNo = table.Column<int>(type: "int", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdmissionTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Initials = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDNo = table.Column<int>(type: "int", nullable: false),
                    WorkTelNo = table.Column<int>(type: "int", nullable: false),
                    CellNo = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoBox = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoBoxCode = table.Column<int>(type: "int", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Race = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkAddressPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NextOfKin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelationshipOfKin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AltContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AltContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AltContactRelationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidOption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DependentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberSurname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberIdNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberTelNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberCellNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberPostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberEmployer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberBusinessAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberBusinessPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    PasswordResetToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordResetTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    ActivationToken = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CarePlanFluids",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IvTestTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IvTestFrequency = table.Column<int>(type: "int", nullable: false),
                    IvTestSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OralTestTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    OralTestFrequency = table.Column<int>(type: "int", nullable: false),
                    OralTestSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TubeTestTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    TubeTestFrequency = table.Column<int>(type: "int", nullable: false),
                    TubeTestSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MonitorFluidTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    MonitorFluidFrequency = table.Column<int>(type: "int", nullable: false),
                    MonitorFluidSignatures = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CheckIVSiteTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CheckIVSiteFrequency = table.Column<int>(type: "int", nullable: false),
                    CheckIVSiteSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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
                name: "ComfortSleepRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PainControlTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    PainControlFrequency = table.Column<int>(type: "int", nullable: false),
                    PainControlSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComfortSleepRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComfortSleepRecords_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DailyCareRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CareRecord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeAdded = table.Column<TimeSpan>(type: "time", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DailyCareRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DailyCareRecords_Patients_PatientId",
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
                    ContinentTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ContinentFrequency = table.Column<int>(type: "int", nullable: false),
                    ContinentSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CathetherTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CathetherFrequency = table.Column<int>(type: "int", nullable: false),
                    CathetherSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
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
                    IntravenousIntakeMl = table.Column<int>(type: "int", nullable: false),
                    IntravenousIntakeTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IntravenousIntakeTimeCompleted = table.Column<TimeSpan>(type: "time", nullable: false),
                    IntravenousIntakeStartVolume = table.Column<int>(type: "int", nullable: false),
                    IntravenousIntakeCompleteVolume = table.Column<int>(type: "int", nullable: false),
                    IvCheck = table.Column<bool>(type: "bit", nullable: false),
                    IvDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IntravenousRunningTotal = table.Column<int>(type: "int", nullable: false),
                    IvCheckType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OralIntakeMl = table.Column<int>(type: "int", nullable: false),
                    OralIntakeTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    OralIntakeVolume = table.Column<int>(type: "int", nullable: false),
                    OralCheckType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OutputMl = table.Column<int>(type: "int", nullable: false),
                    IsUrine = table.Column<bool>(type: "bit", nullable: false),
                    Previous24HourIntake = table.Column<int>(type: "int", nullable: false),
                    Previous24HourOutput = table.Column<int>(type: "int", nullable: false),
                    Total24HourIntake = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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
                    BedBathTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    BedBathFrequency = table.Column<int>(type: "int", nullable: false),
                    BedBathSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BedBathAssistTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    BedBathAssistFrequency = table.Column<int>(type: "int", nullable: false),
                    BedBathAssistSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SelfCareTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    SelfCareFrequency = table.Column<int>(type: "int", nullable: false),
                    SelfCareSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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
                    MedicationTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    MedicationFrequency = table.Column<int>(type: "int", nullable: false),
                    MedicationSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WoundCareTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    WoundCareFrequency = table.Column<int>(type: "int", nullable: false),
                    WoundCareSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostOperativeCareTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    PostOperativeCareFrequency = table.Column<int>(type: "int", nullable: false),
                    PostOperativeCareSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsolationTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    IsolationFrequency = table.Column<int>(type: "int", nullable: false),
                    IsolationSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TractionTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    TractionFrequency = table.Column<int>(type: "int", nullable: false),
                    TractionSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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
                    MobileImmobileTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    MobileImmobileFrequency = table.Column<int>(type: "int", nullable: false),
                    MobileImmobileSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WalkWithAssistanceTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    WalkWithAssistanceFrequency = table.Column<int>(type: "int", nullable: false),
                    WalkWithAssistanceSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssistIntoChairTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    AssistIntoChairFrequency = table.Column<int>(type: "int", nullable: false),
                    AssistIntoChairSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BedRestTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    BedRestFrequency = table.Column<int>(type: "int", nullable: false),
                    BedRestSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExercisesTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ExercisesFrequency = table.Column<int>(type: "int", nullable: false),
                    ExercisesSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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
                    KeepNPOTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    KeepNPOFrequency = table.Column<int>(type: "int", nullable: false),
                    KeepNPOSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FullWardDietTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    FullWardDietFrequency = table.Column<int>(type: "int", nullable: false),
                    FullWardDietSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpecialTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    SpecialFrequency = table.Column<int>(type: "int", nullable: false),
                    SpecialSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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
                    VitalSignsTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    VitalSignsFrequency = table.Column<int>(type: "int", nullable: false),
                    VitalSignSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NeuroLogicalTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    NeuroLogicalFrequency = table.Column<int>(type: "int", nullable: false),
                    NeuroLogicalSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NeuroVascularTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    NeuroVascularFrequency = table.Column<int>(type: "int", nullable: false),
                    NeuroVascularSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodGlucoseTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    BloodGlucoseFrequency = table.Column<int>(type: "int", nullable: false),
                    BloodGlucoseSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UrineTestTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    UrineTestFrequency = table.Column<int>(type: "int", nullable: false),
                    UrineTestSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BloodTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    BloodFrequency = table.Column<int>(type: "int", nullable: false),
                    BloodSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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
                    MaskTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    MaskFrequency = table.Column<int>(type: "int", nullable: false),
                    MaskSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PolyMaskTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    PolyMaskFrequency = table.Column<int>(type: "int", nullable: false),
                    PolyMaskSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NasalCannulaTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    NasalCannulaFrequency = table.Column<int>(type: "int", nullable: false),
                    NasalCannulaSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    InhalaNebsTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    InhalaNebsFrequency = table.Column<int>(type: "int", nullable: false),
                    InhalaNebsSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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
                name: "ProgressReportRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Allergy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RiskFactor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeAdded = table.Column<TimeSpan>(type: "time", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProgressReportRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProgressReportRecords_Patients_PatientId",
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
                    HealthEducationTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    HealthEducationFrequency = table.Column<int>(type: "int", nullable: false),
                    HealthEducationSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CommunicationTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CommunicationFrequency = table.Column<int>(type: "int", nullable: false),
                    CommunicationSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SupportTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    SupportFrequency = table.Column<int>(type: "int", nullable: false),
                    SupportSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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
                    CheckIDBandsTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CheckIDBandsFrequency = table.Column<int>(type: "int", nullable: false),
                    CheckIDBandsSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CotsidesTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    CotsidesFrequency = table.Column<int>(type: "int", nullable: false),
                    CotsidesSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
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
                    PressurePartCareTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    PressurePartCareFrequency = table.Column<int>(type: "int", nullable: false),
                    PressurePartCareSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReportRednessTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    ReportRednessFrequency = table.Column<int>(type: "int", nullable: false),
                    ReportRednessSignature = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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
                name: "SkinReportRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SacrumDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HipsDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HealsDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SkinReportRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SkinReportRecords_Patients_PatientId",
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
                    NormalBowelHabit = table.Column<bool>(type: "bit", nullable: false),
                    StoolChartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StoolChartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    StoolColour = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Blood = table.Column<bool>(type: "bit", nullable: false),
                    MucousAmount = table.Column<int>(type: "int", nullable: false),
                    BowelAmount = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Consistency = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "DayFees",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayFeeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DayFeeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    UserEntityId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayFees_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DayFees_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ICDCodes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IcdCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IcdDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    UserEntityId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICDCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ICDCodes_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ICDCodes_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Wards",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WardNumber = table.Column<int>(type: "int", nullable: false),
                    RoomNumber = table.Column<int>(type: "int", nullable: false),
                    TotalBeds = table.Column<int>(type: "int", nullable: false),
                    UserEntityId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Wards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Wards_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Beds",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedNumber = table.Column<int>(type: "int", nullable: false),
                    WardId = table.Column<int>(type: "int", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    NurseId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Beds", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Beds_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beds_Users_NurseId",
                        column: x => x.NurseId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Beds_Wards_WardId",
                        column: x => x.WardId,
                        principalSchema: "dbo",
                        principalTable: "Wards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_Id",
                schema: "dbo",
                table: "Admissions",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Beds_Id",
                schema: "dbo",
                table: "Beds",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Beds_NurseId",
                schema: "dbo",
                table: "Beds",
                column: "NurseId");

            migrationBuilder.CreateIndex(
                name: "IX_Beds_PatientId",
                schema: "dbo",
                table: "Beds",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Beds_WardId",
                schema: "dbo",
                table: "Beds",
                column: "WardId");

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
                name: "IX_ComfortSleepRecords_Id",
                schema: "dbo",
                table: "ComfortSleepRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ComfortSleepRecords_PatientId",
                schema: "dbo",
                table: "ComfortSleepRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DailyCareRecords_Id",
                schema: "dbo",
                table: "DailyCareRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DailyCareRecords_PatientId",
                schema: "dbo",
                table: "DailyCareRecords",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DayFees_Id",
                schema: "dbo",
                table: "DayFees",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_DayFees_PatientId",
                schema: "dbo",
                table: "DayFees",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_DayFees_UserEntityId",
                schema: "dbo",
                table: "DayFees",
                column: "UserEntityId");

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
                name: "IX_ICDCodes_Id",
                schema: "dbo",
                table: "ICDCodes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ICDCodes_PatientId",
                schema: "dbo",
                table: "ICDCodes",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ICDCodes_UserEntityId",
                schema: "dbo",
                table: "ICDCodes",
                column: "UserEntityId");

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
                name: "IX_Patients_Id",
                schema: "dbo",
                table: "Patients",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressReportRecords_Id",
                schema: "dbo",
                table: "ProgressReportRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProgressReportRecords_PatientId",
                schema: "dbo",
                table: "ProgressReportRecords",
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
                name: "IX_SkinReportRecords_Id",
                schema: "dbo",
                table: "SkinReportRecords",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SkinReportRecords_PatientId",
                schema: "dbo",
                table: "SkinReportRecords",
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

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_Id",
                schema: "dbo",
                table: "UserRoles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                schema: "dbo",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                schema: "dbo",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                schema: "dbo",
                table: "Users",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Id",
                schema: "dbo",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Wards_Id",
                schema: "dbo",
                table: "Wards",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Wards_UserEntityId",
                schema: "dbo",
                table: "Wards",
                column: "UserEntityId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Admissions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Beds",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "CarePlanFluids",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ComfortSleepRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DailyCareRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DayFees",
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
                name: "ICDCodes",
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
                name: "ProgressReportRecords",
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
                name: "SkinReportRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "StoolReportRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserRoles",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Wards",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Patients",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");
        }
    }
}
