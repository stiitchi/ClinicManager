using ClinicManager.Domain.Entities.PatientAggregate.Records.Observations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Observations
{
    public class BloodEntityConfiguration : IEntityTypeConfiguration<BloodEntity>
    {
        public void Configure(EntityTypeBuilder<BloodEntity> conf)
        {
            conf.ToTable("BloodRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.BloodFrequency);
            conf.Property(c => c.BloodTime);
            conf.Property(c => c.BloodSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.BloodRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
