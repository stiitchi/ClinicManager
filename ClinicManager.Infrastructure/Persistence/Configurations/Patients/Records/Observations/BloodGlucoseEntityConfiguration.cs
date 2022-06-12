using ClinicManager.Domain.Entities.PatientAggregate.Records.Observations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Observations
{
   public class BloodGlucoseEntityConfiguration : IEntityTypeConfiguration<BloodGlucoseEntity>
    {
        public void Configure(EntityTypeBuilder<BloodGlucoseEntity> conf)
        {
            conf.ToTable("BloodGlucoseRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.BloodGlucoseFrequency);
            conf.Property(c => c.BloodGlucoseTime);
            conf.Property(c => c.BloodGlucoseSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.BloodGlucoseRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
