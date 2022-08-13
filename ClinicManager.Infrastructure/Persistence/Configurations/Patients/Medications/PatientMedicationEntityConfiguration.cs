using ClinicManager.Domain.Entities.PatientAggregate.Medications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Medications
{
    public class PatientMedicationEntityConfiguration : IEntityTypeConfiguration<PatientMedicationEntity>
    {
        public void Configure(EntityTypeBuilder<PatientMedicationEntity> conf)
        {
            conf.ToTable("PatientMedications", "dbo");
            conf.HasKey(c => c.Id);

            conf.HasOne(c => c.Patient).WithMany(c => c.PatientMedications).HasForeignKey(c => c.PatientId);
            conf.HasOne(c => c.Medication).WithMany(c => c.PatientMedications).HasForeignKey(c => c.MedicationId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasIndex(c => c.MedicationId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
