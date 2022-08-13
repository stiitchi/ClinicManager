using ClinicManager.Domain.Entities.PatientAggregate.Medications;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Medications
{
    public class MedicationEntityConfiguration : IEntityTypeConfiguration<MedicationEntity>
    {
        public void Configure(EntityTypeBuilder<MedicationEntity> conf)
        {
            conf.ToTable("Medications", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.MedicineName).IsRequired();
            conf.Property(c => c.AdministorAmount).IsRequired();
            conf.Property(c => c.Weight).IsRequired();

            var patientMedications = conf.Metadata.FindNavigation(nameof(MedicationEntity.PatientMedications));
            patientMedications.SetPropertyAccessMode(PropertyAccessMode.Field);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
