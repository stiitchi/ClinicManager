using ClinicManager.Domain.Entities.AdmissionAggregate;
using ClinicManager.Domain.Entities.BedAggregate;
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
using Microsoft.EntityFrameworkCore;


namespace ClinicManager.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DbSet<AdmissionEntity> Admissions { get; set; }
        DbSet<WardEntity> Wards { get; set; }
        DbSet<BedEntity> Beds { get; set; }
        DbSet<PatientICDCodeEntity> PatientICDCodes { get; set; }
        DbSet<PatientDayFeesEntity> PatientDayFees { get; set; }
        DbSet<ICDCodeEntity> ICDCodes { get; set; }
        DbSet<DayFeesEntity> DayFees { get; set; }
        DbSet<UserEntity> Users { get; set; }
        DbSet<DoctorEntity> Doctors { get; set; }
        DbSet<UserRolesEntity> UserRoles { get; set; }
        DbSet<RoleEntity> Roles { get; set; }
        DbSet<PatientEntity> Patients { get; set; }
        DbSet<PatientBedEntity> PatientBeds { get; set; }
        DbSet<IVEntity> CareplanIVTest { get; set; }
        DbSet<IVSiteEntity> CareplanIVSiteTest { get; set; }
        DbSet<MonitorFluidEntity> MonitorFluidTest { get; set; }
        DbSet<OralEntity> OralTests { get; set; }
        DbSet<PressurePartEntity> PressurePartRecords { get; set; }
        DbSet<TestTubeEntity> TestTubeTests { get; set; }
        DbSet<SkinIntegrityReport> SkinIntegrityReports { get; set; }
        DbSet<NurseCarePlanComfortSleepEntity> NurseCarePlanComfortSleepRecords { get; set; }
        DbSet<DailyCareRecordEntity> DailyCareRecords { get; set; }
        DbSet<CathetherEntity> CathetherRecords { get; set; }
        DbSet<ContinentEntity> ContinentRecords { get; set; }
        DbSet<IVTestEntity> IVTestRecords { get; set; }
        DbSet<OralIntakeTestEntity> OralIntakeTests { get; set; }
        DbSet<OralOutputEntity> OralOutputTests { get; set; }
        DbSet<Previous24HourIntakeEntity> Previous24HourIntakeTests { get; set; }
        DbSet<BedBathAssistEntity> BedBathAssistTests { get; set; }
        DbSet<BedBathEntity> BedBathTests { get; set; }
        DbSet<SelfCareEntity> SelfCareTests { get; set; }
        DbSet<IsolationEntity> IsolationTests { get; set; }
        DbSet<MedicationEntity> MedicationTests { get; set; }
        DbSet<PostOperativeCareEntity> PostOperativeCareTests { get; set; }
        DbSet<TractionEntity> TractionTests { get; set; }
        DbSet<WoundCareEntity> WoundCareTests { get; set; }
        DbSet<BedRestEntity> BedRestTests { get; set; }
        DbSet<ExerciseEntity> ExerciseTests { get; set; }
        DbSet<MobileImmobileEntity> MobileImmobileTests { get; set; }
        DbSet<WalkAssistanceEntity> WalkAssistanceTests { get; set; }
        DbSet<WalkChairEntity> WalkChairTests { get; set; }
        DbSet<KeepNPOEntity> KeepNPOTests { get; set; }
        DbSet<SpecialEntity> SpecialTests { get; set; }
        DbSet<WardDietEntity> WardDietTests { get; set; }
        DbSet<BloodEntity> BloodTests { get; set; }
        DbSet<BloodGlucoseEntity> BloodGlucoseTests { get; set; }
        DbSet<NeurologicalEntity> NeurologicalTests { get; set; }
        DbSet<NeurovascularEntity> NeurovascularTests { get; set; }
        DbSet<UrineTestEntity> UrineTestTests { get; set; }
        DbSet<VitalSignEntity> VitalSignTests { get; set; }
        DbSet<InhalaNebsEntity> InhalaNebsTests { get; set; }
        DbSet<PolyMaskEntity> PolyMaskTests { get; set; }
        DbSet<NasalCannulEntity> NasalCannulTests { get; set; }
        DbSet<MaskTimeEntity> MaskTimeTests { get; set; }
        DbSet<PatientProgressEntity> PatientProgressTests { get; set; }
        DbSet<CommunicationEntity> CommunicationTests { get; set; }
        DbSet<HealthCareEntity> HealthCareTests { get; set; }
        DbSet<SupportEntity> SupportTests { get; set; }
        DbSet<CheckIdBandEntity> CheckIdBandTests { get; set; }
        DbSet<RednessEntity> RednessTests { get; set; }
        DbSet<StoolChartEntity> StoolChartTests { get; set; }
        DbSet<CotsideEntity> CotsideRecords { get; set; }
    }
}
