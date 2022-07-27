using ClinicManager.Domain.Entities.PatientAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients
{
    public class PatientEntityConfiguration : IEntityTypeConfiguration<PatientEntity>
    {
        public void Configure(EntityTypeBuilder<PatientEntity> conf)
        {
            conf.ToTable("Patients", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.WardNO).IsRequired();
            conf.Property(c => c.BedNO).IsRequired();
            conf.Property(c => c.CaseInfomationNo).IsRequired();
            conf.Property(c => c.AccountNO).IsRequired();
            conf.Property(c => c.AdmissionDate).IsRequired();
            conf.Property(c => c.DischargeDate).IsRequired();
            conf.Property(c => c.ReportDate).IsRequired();
            conf.Property(c => c.DateOfBirth).IsRequired();
            conf.Property(c => c.Title).IsRequired();
            conf.Property(c => c.Initials).IsRequired();
            conf.Property(c => c.FirstName).IsRequired();
            conf.Property(c => c.LastName).IsRequired();
            conf.Property(c => c.IDNo).IsRequired();
            conf.Property(c => c.PatientTelNo).IsRequired();
            conf.Property(c => c.PatientCellNo).IsRequired();
            conf.Property(c => c.PatientWorkTelNo).IsRequired();
            conf.Property(c => c.Email).IsRequired();
            conf.Property(c => c.StreetAddress).IsRequired();
            conf.Property(c => c.City).IsRequired();
            conf.Property(c => c.Province).IsRequired();
            conf.Property(c => c.PostalCode).IsRequired();
            conf.Property(c => c.PoBox).IsRequired();
            conf.Property(c => c.PoBoxCode).IsRequired();
            conf.Property(c => c.Occupation).IsRequired();
            conf.Property(c => c.Language).IsRequired();
            conf.Property(c => c.Gender).IsRequired();
            conf.Property(c => c.Race).IsRequired();
            conf.Property(c => c.Suburb).IsRequired();
            conf.Property(c => c.EmployerName).IsRequired();
            conf.Property(c => c.WorkAddress).IsRequired();
            conf.Property(c => c.WorkAddressCity).IsRequired();
            conf.Property(c => c.WorkAddressProvince).IsRequired();
            conf.Property(c => c.WorkAddressPostalCode).IsRequired();
            conf.Property(c => c.NextOfKin).IsRequired();
            conf.Property(c => c.NextOfKinContactNo).IsRequired();
            conf.Property(c => c.NextOfKinRelationship).IsRequired();
            conf.Property(c => c.NextOfKinAltContactNo).IsRequired();
            conf.Property(c => c.OtherContact).IsRequired();
            conf.Property(c => c.OtherContactNo).IsRequired();
            conf.Property(c => c.OtherContactRelationship).IsRequired();
            conf.Property(c => c.OtherContactAltContactNo).IsRequired();
            conf.Property(c => c.RefferingDoctor).IsRequired();
            conf.Property(c => c.RefferingHospital).IsRequired();
            conf.Property(c => c.MedicalAidName).IsRequired();
            conf.Property(c => c.MedicalAidOption).IsRequired();
            conf.Property(c => c.MedicalAidNo).IsRequired();
            conf.Property(c => c.AuthNo).IsRequired();
            conf.Property(c => c.DependentCode).IsRequired();
            conf.Property(c => c.WoundLocation).IsRequired();
            conf.Property(c => c.WoundStage).IsRequired();
            conf.Property(c => c.Ot).IsRequired();
            conf.Property(c => c.IsActive).IsRequired();
            conf.Property(c => c.SpeechLanguage).IsRequired();
            conf.Property(c => c.Psychologist).IsRequired();
            conf.Property(c => c.SocialWorker).IsRequired();
            conf.Property(c => c.Physio).IsRequired();
            conf.Property(c => c.MainMemberFirstName).IsRequired();
            conf.Property(c => c.MainMemberLastName).IsRequired();
            conf.Property(c => c.MedicalAidIdNumber).IsRequired();
            conf.Property(c => c.MainMemberRelationship).IsRequired();
            conf.Property(c => c.MainMemberTelNo).IsRequired();
            conf.Property(c => c.MainMemberCellNo).IsRequired();
            conf.Property(c => c.MainMemberStreetAddress).IsRequired();
            conf.Property(c => c.MainMemberCity).IsRequired();
            conf.Property(c => c.MainMemberSuburb).IsRequired();
            conf.Property(c => c.MainMemberProvince).IsRequired();
            conf.Property(c => c.MainMemberPostalAddress).IsRequired();
            conf.Property(c => c.MainMemberPostalAddressCode).IsRequired();
            conf.Property(c => c.MainMemberOccupation).IsRequired();
            conf.Property(c => c.MainMemberEmployer).IsRequired();
            conf.Property(c => c.MainMemberBusinessStreetAddress).IsRequired();
            conf.Property(c => c.MainMemberBusinessCity).IsRequired();
            conf.Property(c => c.MainMemberBusinessProvince).IsRequired();
            conf.Property(c => c.MainMemberBusinessPostalCode).IsRequired();
            conf.Property(c => c.RoomNo).IsRequired();


            var bloodOxygenCharts = conf.Metadata.FindNavigation(nameof(PatientEntity.BloodOxygenCharts));
            bloodOxygenCharts.SetPropertyAccessMode(PropertyAccessMode.Field);

            var bloodPressureCharts = conf.Metadata.FindNavigation(nameof(PatientEntity.BloodPressureCharts));
            bloodPressureCharts.SetPropertyAccessMode(PropertyAccessMode.Field);

            var heartRateCharts = conf.Metadata.FindNavigation(nameof(PatientEntity.HeartRateCharts));
            heartRateCharts.SetPropertyAccessMode(PropertyAccessMode.Field);

            var respitoryRateCharts = conf.Metadata.FindNavigation(nameof(PatientEntity.RespitoryRateCharts));
            respitoryRateCharts.SetPropertyAccessMode(PropertyAccessMode.Field);

            var temperatureCharts = conf.Metadata.FindNavigation(nameof(PatientEntity.TemperatureCharts));
            temperatureCharts.SetPropertyAccessMode(PropertyAccessMode.Field);

            var patientBeds = conf.Metadata.FindNavigation(nameof(PatientEntity.PatientBeds));
            patientBeds.SetPropertyAccessMode(PropertyAccessMode.Field);

            var beds = conf.Metadata.FindNavigation(nameof(PatientEntity.Beds));
            beds.SetPropertyAccessMode(PropertyAccessMode.Field);

            var icdCodes = conf.Metadata.FindNavigation(nameof(PatientEntity.IcdCodes));
            icdCodes.SetPropertyAccessMode(PropertyAccessMode.Field);

            var dayFees = conf.Metadata.FindNavigation(nameof(PatientEntity.DayFees));
            dayFees.SetPropertyAccessMode(PropertyAccessMode.Field);

            var dailyCareRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.DailyCareRecords));
            dailyCareRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var oralIntakeTestRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.OralIntakeTestRecords));
            oralIntakeTestRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var oralOutputRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.OralOutputRecords));
            oralOutputRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var previous24HourIntakeRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.Previous24HourIntakeRecords));
            previous24HourIntakeRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var ivTestRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.IvTestRecords));
            ivTestRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var carePlanIVTests = conf.Metadata.FindNavigation(nameof(PatientEntity.CarePlanIVTests));
            carePlanIVTests.SetPropertyAccessMode(PropertyAccessMode.Field);

            var comfortSleepRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.ComfortSleepRecords));
            comfortSleepRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var cathetherRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.CathetherRecords));
            cathetherRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var continentRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.ContinentRecords));
            continentRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var ivSiteRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.IvSiteRecords));
            ivSiteRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var monitorFluidRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.MonitorFluidRecords));
            monitorFluidRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var oralRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.OralRecords));
            oralRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var testTubeRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.TestTubeRecords));
            testTubeRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var skinIntegrityReportRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.SkinIntegrityReportRecords));
            skinIntegrityReportRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var bedBathAssistRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.BedBathAssistRecords));
            bedBathAssistRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var bedBathRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.BedBathRecords));
            bedBathRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var selfCareRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.SelfCareRecords));
            selfCareRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var isolationRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.IsolationRecords));
            isolationRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var medicationRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.MedicationRecords));
            medicationRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var postOperativeCareRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.PostOperativeCareRecords));
            postOperativeCareRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var tractionRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.TractionRecords));
            tractionRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var woundCareRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.WoundCareRecords));
            woundCareRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var bedRestRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.BedRestRecords));
            bedRestRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var exerciseRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.ExerciseRecords));
            exerciseRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var mobileImmobileRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.MobileImmobileRecords));
            mobileImmobileRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var walkAssistanceRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.WalkAssistanceRecords));
            walkAssistanceRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var walkChairRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.WalkChairRecords));
            walkChairRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var keepNPORecords = conf.Metadata.FindNavigation(nameof(PatientEntity.KeepNPORecords));
            keepNPORecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var specialRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.SpecialRecords));
            specialRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var wardDietRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.WardDietRecords));
            wardDietRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var bloodRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.BloodRecords));
            bloodRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var bloodGlucoseRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.BloodGlucoseRecords));
            bloodGlucoseRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var neurologicalRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.NeurologicalRecords));
            neurologicalRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var neurovascularRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.NeurovascularRecords));
            neurovascularRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var urineTestRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.UrineTestRecords));
            urineTestRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var vitalSignRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.VitalSignRecords));
            vitalSignRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var inhalaNebsRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.InhalaNebsRecords));
            inhalaNebsRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var maskTimeRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.MaskTimeRecords));
            maskTimeRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var nasalCannulRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.NasalCannulRecords));
            nasalCannulRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var polyMaskRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.PolyMaskRecords));
            polyMaskRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var patientProgressRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.PatientProgressRecords));
            patientProgressRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var communicationRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.CommunicationRecords));
            communicationRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var healthCareRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.HealthCareRecords));
            communicationRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var supportRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.SupportRecords));
            supportRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var checkIdBandRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.CheckIdBandRecords));
            checkIdBandRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var cotsideRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.CotsideRecords));
            cotsideRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var pressurePartRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.PressurePartRecords));
            pressurePartRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var rednessRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.RednessRecords));
            rednessRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            var stoolChartRecords = conf.Metadata.FindNavigation(nameof(PatientEntity.StoolChartRecords));
            stoolChartRecords.SetPropertyAccessMode(PropertyAccessMode.Field);

            conf.Property(c => c.IsActive).IsRequired();
            conf.HasIndex(c => c.Id);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
