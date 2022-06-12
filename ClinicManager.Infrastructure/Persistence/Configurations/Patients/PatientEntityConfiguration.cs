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
            conf.Property(c => c.CaseInformationNo).IsRequired();
            conf.Property(c => c.AccountNo).IsRequired();
            conf.Property(c => c.AdmissionDate).IsRequired();
            conf.Property(c => c.AdmissionTime).IsRequired();
            conf.Property(c => c.FullName).IsRequired();
            conf.Property(c => c.LastName).IsRequired();
            conf.Property(c => c.Title).IsRequired();
            conf.Property(c => c.Initials).IsRequired();
            conf.Property(c => c.IDNo).IsRequired();
            conf.Property(c => c.CellNo).IsRequired();
            conf.Property(c => c.WorkTelNo).IsRequired();
            conf.Property(c => c.DateOfBirth).IsRequired();
            conf.Property(c => c.Address).IsRequired();
            conf.Property(c => c.PoBox).IsRequired();
            conf.Property(c => c.PoBoxCode).IsRequired();
            conf.Property(c => c.Occupation).IsRequired();
            conf.Property(c => c.Language).IsRequired();
            conf.Property(c => c.Gender).IsRequired();
            conf.Property(c => c.Race).IsRequired();
            conf.Property(c => c.Race).IsRequired();
            conf.Property(c => c.EmployerName).IsRequired();
            conf.Property(c => c.WorkAddress).IsRequired();
            conf.Property(c => c.WorkAddressPostalCode).IsRequired();
            conf.Property(c => c.NextOfKin).IsRequired();
            conf.Property(c => c.ContactNo).IsRequired();
            conf.Property(c => c.RelationshipOfKin).IsRequired();
            conf.Property(c => c.AltContact).IsRequired();
            conf.Property(c => c.AltContactNo).IsRequired();
            conf.Property(c => c.AltContactRelationship).IsRequired();
            conf.Property(c => c.MedicalAidOption).IsRequired();
            conf.Property(c => c.MedicalAidName).IsRequired();
            conf.Property(c => c.MedicalAidNo).IsRequired();
            conf.Property(c => c.AuthNo).IsRequired();
            conf.Property(c => c.DependentCode).IsRequired();
            conf.Property(c => c.MedicalAidMemberName).IsRequired();
            conf.Property(c => c.MedicalAidMemberSurname).IsRequired();
            conf.Property(c => c.MedicalAidMemberIdNo).IsRequired();
            conf.Property(c => c.MedicalAidMemberTelNo).IsRequired();
            conf.Property(c => c.MedicalAidMemberCellNo).IsRequired();
            conf.Property(c => c.MedicalAidMemberPostalAddress).IsRequired();
            conf.Property(c => c.MedicalAidMemberCode).IsRequired();
            conf.Property(c => c.MedicalAidMemberOccupation).IsRequired();
            conf.Property(c => c.MedicalAidMemberEmployer).IsRequired();
            conf.Property(c => c.MedicalAidMemberBusinessAddress).IsRequired();
            conf.Property(c => c.MedicalAidMemberBusinessPostalCode).IsRequired();


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
