using ClinicManager.Application.Common.Interfaces;
using ClinicManager.Domain.Entities;
using ClinicManager.Domain.Entities.AdmissionAggregate;
using ClinicManager.Domain.Entities.BedAggregate;
using ClinicManager.Domain.Entities.ChartsAggregate;
using ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry;
using ClinicManager.Domain.Entities.DayFeesAggregate;
using ClinicManager.Domain.Entities.DoctorsAggregate;
using ClinicManager.Domain.Entities.ICDCodeAggregate;
using ClinicManager.Domain.Entities.PatientAggregate;
using ClinicManager.Domain.Entities.PatientAggregate.Records.CarePlanFluids;
using ClinicManager.Domain.Entities.PatientAggregate.Records.CarePlanSkinIntegrity;
using ClinicManager.Domain.Entities.PatientAggregate.Records.ComfortSleep;
using ClinicManager.Domain.Entities.PatientAggregate.Records.DailyCare;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Elimination;
using ClinicManager.Domain.Entities.PatientAggregate.Records.FluidBalance;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Hygiene;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Intervention;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Mobility;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Nutrition;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Observations;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Oxygenation;
using ClinicManager.Domain.Entities.PatientAggregate.Records.ProgressRecords;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Psychological;
using ClinicManager.Domain.Entities.PatientAggregate.Records.Safety;
using ClinicManager.Domain.Entities.PatientAggregate.Records.SkinIntegrity;
using ClinicManager.Domain.Entities.PatientAggregate.Records.StoolCharts;
using ClinicManager.Domain.Entities.UserAggregate;
using ClinicManager.Domain.Entities.WardAggregate;
using ClinicManager.Infrastructure.Persistence.SeedMethods;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace ClinicManager.Infrastructure.Persistence
{
    public class ApplicationDbContext : DbContext, IApplicationDbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {}
        public DbSet<AdmissionEntity> Admissions { get; set; }
        public DbSet<WardEntity> Wards { get; set; }
        public DbSet<BedEntity> Beds { get; set; }
        public DbSet<ICDCodeEntity> ICDCodes { get; set; }
        public DbSet<DayFeesEntity> DayFees { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<DoctorEntity> Doctors { get; set; }
        public DbSet<PatientEntity> Patients { get; set; }
        public DbSet<PatientBedEntity> PatientBeds { get; set; }
        public DbSet<UserRolesEntity> UserRoles { get; set; }
        public DbSet<RoleEntity> Roles { get; set; }
        public DbSet<PatientICDCodeEntity> PatientICDCodes { get; set; }
        public DbSet<PatientDayFeesEntity> PatientDayFees { get; set; }

        //Patient Records
        public DbSet<IVEntity> CareplanIVTest { get; set; }
        public DbSet<IVSiteEntity> CareplanIVSiteTest { get; set; }
        public DbSet<MonitorFluidEntity> MonitorFluidTest { get; set; }
        public DbSet<OralEntity> OralTests { get; set; }
        public DbSet<TestTubeEntity> TestTubeTests { get; set; }
        public DbSet<SkinIntegrityReport> SkinIntegrityReports { get; set; }
        public DbSet<PressurePartEntity> PressurePartRecords { get; set; }
        public DbSet<NurseCarePlanComfortSleepEntity> NurseCarePlanComfortSleepRecords { get; set; }
        public DbSet<DailyCareRecordEntity> DailyCareRecords { get; set; }
        public DbSet<CathetherEntity> CathetherRecords { get; set; }
        public DbSet<ContinentEntity> ContinentRecords { get; set; }
        public DbSet<IVTestEntity> IVTestRecords { get; set; }
        public DbSet<OralIntakeTestEntity> OralIntakeTests { get; set; }
        public DbSet<OralOutputEntity> OralOutputTests { get; set; }
        public DbSet<Previous24HourIntakeEntity> Previous24HourIntakeTests { get; set; }
        public DbSet<BedBathAssistEntity> BedBathAssistTests { get; set; }
        public DbSet<BedBathEntity> BedBathTests { get; set; }
        public DbSet<SelfCareEntity> SelfCareTests { get; set; }
        public DbSet<IsolationEntity> IsolationTests { get; set; }
        public DbSet<MedicationEntity> MedicationTests { get; set; }
        public DbSet<PostOperativeCareEntity> PostOperativeCareTests { get; set; }
        public DbSet<TractionEntity> TractionTests { get; set; }
        public DbSet<WoundCareEntity> WoundCareTests { get; set; }
        public DbSet<BedRestEntity> BedRestTests { get; set; }
        public DbSet<ExerciseEntity> ExerciseTests { get; set; }
        public DbSet<MobileImmobileEntity> MobileImmobileTests { get; set; }
        public DbSet<WalkAssistanceEntity> WalkAssistanceTests { get; set; }
        public DbSet<WalkChairEntity> WalkChairTests { get; set; }
        public DbSet<KeepNPOEntity> KeepNPOTests { get; set; }
        public DbSet<SpecialEntity> SpecialTests { get; set; }
        public DbSet<WardDietEntity> WardDietTests { get; set; }
        public DbSet<BloodEntity> BloodTests { get; set; }
        public DbSet<BloodGlucoseEntity> BloodGlucoseTests { get; set; }
        public DbSet<NeurologicalEntity> NeurologicalTests { get; set; }
        public DbSet<NeurovascularEntity> NeurovascularTests { get; set; }
        public DbSet<UrineTestEntity> UrineTestTests { get; set; }
        public DbSet<VitalSignEntity> VitalSignTests { get; set; }
        public DbSet<InhalaNebsEntity> InhalaNebsTests { get; set; }
        public DbSet<PolyMaskEntity> PolyMaskTests { get; set; }
        public DbSet<NasalCannulEntity> NasalCannulTests { get; set; }
        public DbSet<MaskTimeEntity> MaskTimeTests { get; set; }
        public DbSet<PatientProgressEntity> PatientProgressTests { get; set; }
        public DbSet<CommunicationEntity> CommunicationTests { get; set; }
        public DbSet<HealthCareEntity> HealthCareTests { get; set; }
        public DbSet<SupportEntity> SupportTests { get; set; }
        public DbSet<CheckIdBandEntity> CheckIdBandTests { get; set; }
        public DbSet<CotsideEntity> CotsideRecords { get; set; }
        public DbSet<PressurePartEntity> PressurePartTests { get; set; }
        public DbSet<RednessEntity> RednessTests { get; set; }
        public DbSet<StoolChartEntity> StoolChartTests { get; set; }
        //Charts
        public DbSet<BloodOxygenChartEntity> BloodOxygenCharts { get; set; }
        public DbSet<BloodPressureChartEntity> BloodPressureCharts { get; set; }
        public DbSet<RespitoryRateChartEntity> RespitoryRateCharts { get; set; }
        public DbSet<HeartRateChartEntity> HeartRateCharts { get; set; }
        public DbSet<TemperatureChartEntity> TemperatureCharts { get; set; }
        //Chart Entries
        public DbSet<BloodOxygenChartEntryEntity> BloodOxygenChartEntries { get; set; }
        public DbSet<BloodPressureChartEntryEntity> BloodPressureChartEntries { get; set; }
        public DbSet<RespitoryRateChartEntryEntity> RespitoryRateChartEntries { get; set; }
        public DbSet<HeartRateChartEntryEntity> HeartRateChartEntries { get; set; }
        public DbSet<TemperatureChartEntryEntity> TemperatureChartEntries { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            //RunAllSeedMethods(ref modelBuilder);
        }
        public void RunAllSeedMethods(ref ModelBuilder modelBuilder)
        {
            new RoleSeed(ref modelBuilder);
        }

        private void UpdateSoftDeleteStatuses()
        {
            foreach (var entry in ChangeTracker.Entries())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        {
                            if (entry is EntityBase)
                                entry.CurrentValues["IsActive"] = true;
                            break;
                        }

                    case EntityState.Deleted:
                        if (entry is EntityBase)
                        {
                            entry.State = EntityState.Modified;
                            entry.CurrentValues["IsActive"] = false;
                        }

                        break;
                }
            }
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            UpdateSoftDeleteStatuses();
            var result = await base.SaveChangesAsync(cancellationToken);
            return result;
        }

        public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
        {
            public ApplicationDbContext CreateDbContext(string[] args)
            {
                IConfiguration configuration = new ConfigurationBuilder()
                    .SetBasePath(Path.Combine(Directory.GetCurrentDirectory()))
                    .AddJsonFile("appsettings.json", optional: false)
                    .Build();
                var connectionString = configuration.GetConnectionString("DefaultConnection");
                var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
                builder.UseSqlServer(connectionString,
                    x => x.MigrationsAssembly(typeof(ApplicationDbContext).GetTypeInfo().Assembly.GetName().Name));
                return new ApplicationDbContext(builder.Options);
            }
        }
    }
}
