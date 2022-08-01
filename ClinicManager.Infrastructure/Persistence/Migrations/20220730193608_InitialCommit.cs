using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ClinicManager.Infrastructure.Persistence.Migrations
{
    public partial class InitialCommit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.EnsureSchema(
                name: "lut");

            migrationBuilder.CreateTable(
                name: "Admissions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaseInformationNo = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    AccountNo = table.Column<int>(type: "int", maxLength: 200, nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdmissionTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Initials = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDNo = table.Column<int>(type: "int", nullable: false),
                    HomeTelNo = table.Column<int>(type: "int", nullable: false),
                    WorkTelNo = table.Column<int>(type: "int", nullable: false),
                    CellNo = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    PostalCode = table.Column<int>(type: "int", nullable: false),
                    HomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoBox = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PoBoxCode = table.Column<int>(type: "int", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Race = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkAddressPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NextOfKin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RelationshipOfKin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherContact = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OtherContactRelationship = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalAidNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalAidName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalAidOption = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DependentCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalAidMemberFullName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberRelationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberHomeAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberHomePostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberPostalAddressCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberPostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidMemberEmployer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalAidMemberBusinessAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalAidMemberBusinessPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MedicalAidMemberIdNo = table.Column<int>(type: "int", nullable: false),
                    MedicalAidMemberTelNo = table.Column<int>(type: "int", nullable: false),
                    MedicalAidMemberCellNo = table.Column<int>(type: "int", nullable: false),
                    OtherContactNo = table.Column<int>(type: "int", nullable: false),
                    AltContactNoKin = table.Column<int>(type: "int", nullable: false),
                    OtherContactNoAlt = table.Column<int>(type: "int", nullable: false),
                    ContactNoKin = table.Column<int>(type: "int", nullable: false),
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
                    RoomNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Suburb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Province = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientCellNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientTelNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientWorkTelNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Initials = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DependentCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefferingDoctor = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RefferingHospital = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Race = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Language = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoBox = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoBoxCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Occupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmployerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkAddressCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkAddressProvince = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkAddressPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NextOfKin = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NextOfKinContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NextOfKinRelationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NextOfKinAltContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherContact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherContactRelationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OtherContactAltContactNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WardNO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BedNO = table.Column<int>(type: "int", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AdmissionDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DischargeDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IDNo = table.Column<long>(type: "bigint", nullable: false),
                    CaseInfomationNo = table.Column<int>(type: "int", nullable: false),
                    AccountNO = table.Column<int>(type: "int", nullable: false),
                    MedicalAidNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WoundLocation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WoundStage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainMemberFirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainMemberLastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainMemberTelNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainMemberStreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainMemberCellNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainMemberPostalAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainMemberPostalAddressCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainMemberOccupation = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainMemberEmployer = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainMemberBusinessStreetAddress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainMemberBusinessCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainMemberBusinessProvince = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainMemberBusinessPostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainMemberSuburb = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainMemberCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainMemberProvince = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MainMemberRelationship = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MedicalAidIdNumber = table.Column<long>(type: "bigint", nullable: false),
                    MedicalAidOption = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SpeechLanguage = table.Column<bool>(type: "bit", nullable: false),
                    Psychologist = table.Column<bool>(type: "bit", nullable: false),
                    SocialWorker = table.Column<bool>(type: "bit", nullable: false),
                    Physio = table.Column<bool>(type: "bit", nullable: false),
                    Ot = table.Column<bool>(type: "bit", nullable: false),
                    IsAdmitted = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                schema: "lut",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subscriptions",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AmountOfNurses = table.Column<int>(type: "int", nullable: false),
                    OverallTotal = table.Column<int>(type: "int", nullable: false),
                    StoragePlan = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClinicName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RepFirstName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    RepLastName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    ClinicAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    City = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    Province = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    DateScheduled = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsChecked = table.Column<bool>(type: "bit", nullable: false),
                    IsScheduled = table.Column<bool>(type: "bit", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subscriptions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IsLoggedIn = table.Column<bool>(type: "bit", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    PasswordHash = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordSalt = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    PasswordResetToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordResetTokenExpiry = table.Column<DateTime>(type: "datetime2", nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    ActivationToken = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

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
                name: "BloodOxygenCharts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodOxygenChartEntry = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodOxygenCharts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodOxygenCharts_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BloodPressureCharts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BloodPressureChartEntry = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodPressureCharts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BloodPressureCharts_Patients_PatientId",
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
                name: "ComfortSleepRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PainControlTime = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "DailyCareRecords",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CareRecord = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TimeAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "HeartRateCharts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HeartRateChartEntry = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HeartRateCharts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HeartRateCharts_Patients_PatientId",
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
                    TimeAdded = table.Column<DateTime>(type: "datetime2", nullable: false),
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
                name: "RespitoryCharts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RespitoryChartEntry = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespitoryCharts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespitoryCharts_Patients_PatientId",
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
                name: "TemperatureCharts",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TempRateEntry = table.Column<double>(type: "float", nullable: false),
                    Time = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PatientId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemperatureCharts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TemperatureCharts_Patients_PatientId",
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

            migrationBuilder.CreateTable(
                name: "SubscriptionCart",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CartEntryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Amount = table.Column<int>(type: "int", nullable: false),
                    SubscriptionId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubscriptionCart", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SubscriptionCart_Subscriptions_SubscriptionId",
                        column: x => x.SubscriptionId,
                        principalSchema: "dbo",
                        principalTable: "Subscriptions",
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
                    PatientEntityId = table.Column<int>(type: "int", nullable: true),
                    UserEntityId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DayFees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DayFees_Patients_PatientEntityId",
                        column: x => x.PatientEntityId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id");
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
                    PatientEntityId = table.Column<int>(type: "int", nullable: true),
                    UserEntityId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ICDCodes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ICDCodes_Patients_PatientEntityId",
                        column: x => x.PatientEntityId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ICDCodes_Users_UserEntityId",
                        column: x => x.UserEntityId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
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
                        principalSchema: "lut",
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
                    WardNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TotalRooms = table.Column<int>(type: "int", nullable: false),
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

            migrationBuilder.CreateTable(
                name: "PatientDayFees",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DayFeeCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DayFeeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "PatientICDCodes",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IcdCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IcdDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
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
                name: "Doctors",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    MobileNo = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    WardId = table.Column<int>(type: "int", nullable: false),
                    WardEntityId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Doctors_Wards_WardEntityId",
                        column: x => x.WardEntityId,
                        principalSchema: "dbo",
                        principalTable: "Wards",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Doctors_Wards_WardId",
                        column: x => x.WardId,
                        principalSchema: "dbo",
                        principalTable: "Wards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    WardId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rooms_Wards_WardId",
                        column: x => x.WardId,
                        principalSchema: "dbo",
                        principalTable: "Wards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Beds",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BedNumber = table.Column<int>(type: "int", nullable: false),
                    RoomNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PatientId = table.Column<int>(type: "int", nullable: true),
                    NurseId = table.Column<int>(type: "int", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: true),
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
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Beds_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalSchema: "dbo",
                        principalTable: "Rooms",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Beds_Users_NurseId",
                        column: x => x.NurseId,
                        principalSchema: "dbo",
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PatientBeds",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PatientName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BedId = table.Column<int>(type: "int", nullable: false),
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
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PatientBeds_Patients_PatientId",
                        column: x => x.PatientId,
                        principalSchema: "dbo",
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "lut",
                table: "Roles",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "SYSTEM ADMINISTRATOR" },
                    { 2, "ADMITTED" },
                    { 3, "DOCTOR" },
                    { 4, "NURSE" },
                    { 5, "SUPER USER" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Admissions_Id",
                schema: "dbo",
                table: "Admissions",
                column: "Id");

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
                name: "IX_Beds_RoomId",
                schema: "dbo",
                table: "Beds",
                column: "RoomId");

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
                name: "IX_BloodOxygenChartEntries_BloodOxygenChartId",
                schema: "dbo",
                table: "BloodOxygenChartEntries",
                column: "BloodOxygenChartId");

            migrationBuilder.CreateIndex(
                name: "IX_BloodOxygenChartEntries_Id",
                schema: "dbo",
                table: "BloodOxygenChartEntries",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BloodOxygenCharts_Id",
                schema: "dbo",
                table: "BloodOxygenCharts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BloodOxygenCharts_PatientId",
                schema: "dbo",
                table: "BloodOxygenCharts",
                column: "PatientId");

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
                name: "IX_BloodPressureCharts_Id",
                schema: "dbo",
                table: "BloodPressureCharts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_BloodPressureCharts_PatientId",
                schema: "dbo",
                table: "BloodPressureCharts",
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
                name: "IX_DayFees_PatientEntityId",
                schema: "dbo",
                table: "DayFees",
                column: "PatientEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_DayFees_UserEntityId",
                schema: "dbo",
                table: "DayFees",
                column: "UserEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Email",
                schema: "dbo",
                table: "Doctors",
                column: "Email");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_Id",
                schema: "dbo",
                table: "Doctors",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_WardEntityId",
                schema: "dbo",
                table: "Doctors",
                column: "WardEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Doctors_WardId",
                schema: "dbo",
                table: "Doctors",
                column: "WardId");

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
                name: "IX_HeartRateCharts_Id",
                schema: "dbo",
                table: "HeartRateCharts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_HeartRateCharts_PatientId",
                schema: "dbo",
                table: "HeartRateCharts",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_ICDCodes_Id",
                schema: "dbo",
                table: "ICDCodes",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ICDCodes_PatientEntityId",
                schema: "dbo",
                table: "ICDCodes",
                column: "PatientEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ICDCodes_UserEntityId",
                schema: "dbo",
                table: "ICDCodes",
                column: "UserEntityId");

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
                name: "IX_Patients_Id",
                schema: "dbo",
                table: "Patients",
                column: "Id");

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
                name: "IX_RespitoryCharts_Id",
                schema: "dbo",
                table: "RespitoryCharts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_RespitoryCharts_PatientId",
                schema: "dbo",
                table: "RespitoryCharts",
                column: "PatientId");

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
                name: "IX_Rooms_Id",
                schema: "dbo",
                table: "Rooms",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_WardId",
                schema: "dbo",
                table: "Rooms",
                column: "WardId");

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
                name: "IX_SubscriptionCart_Id",
                schema: "dbo",
                table: "SubscriptionCart",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_SubscriptionCart_SubscriptionId",
                schema: "dbo",
                table: "SubscriptionCart",
                column: "SubscriptionId");

            migrationBuilder.CreateIndex(
                name: "IX_Subscriptions_Id",
                schema: "dbo",
                table: "Subscriptions",
                column: "Id");

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
                name: "IX_TemperatureChartEntries_Id",
                schema: "dbo",
                table: "TemperatureChartEntries",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TemperatureChartEntries_TemperatureChartId",
                schema: "dbo",
                table: "TemperatureChartEntries",
                column: "TemperatureChartId");

            migrationBuilder.CreateIndex(
                name: "IX_TemperatureCharts_Id",
                schema: "dbo",
                table: "TemperatureCharts",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_TemperatureCharts_PatientId",
                schema: "dbo",
                table: "TemperatureCharts",
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
                name: "IX_Wards_Id",
                schema: "dbo",
                table: "Wards",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Wards_UserEntityId",
                schema: "dbo",
                table: "Wards",
                column: "UserEntityId");

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
                name: "Admissions",
                schema: "dbo");

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
                name: "BloodOxygenChartEntries",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BloodPressureChartEntries",
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
                name: "ComfortSleepRecords",
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
                name: "DailyCareRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Doctors",
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
                name: "HeartRateChartEntries",
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
                name: "PatientBeds",
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
                name: "ProgressReportRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ReportRednessRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RespitoryRateChartEntries",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SelfCareRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SkinReportRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SpecialRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "StoolChartRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SubscriptionCart",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "SupportRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TemperatureChartEntries",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TractionRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UrineTestRecords",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "UserRoles",
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

            migrationBuilder.DropTable(
                name: "BloodOxygenCharts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "BloodPressureCharts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "HeartRateCharts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Beds",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "DayFees",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "ICDCodes",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "RespitoryCharts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Subscriptions",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "TemperatureCharts",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Roles",
                schema: "lut");

            migrationBuilder.DropTable(
                name: "Rooms",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Patients",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Wards",
                schema: "dbo");

            migrationBuilder.DropTable(
                name: "Users",
                schema: "dbo");
        }
    }
}
