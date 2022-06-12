using ClinicManager.Domain.Entities.PatientAggregate.Records.Observations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Observations
{
    public class UrineTestEntityConfiguration : IEntityTypeConfiguration<UrineTestEntity>
    {
        public void Configure(EntityTypeBuilder<UrineTestEntity> conf)
        {
            conf.ToTable("UrineTestRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.UrineTestTime);
            conf.Property(c => c.UrineTestFrequency);
            conf.Property(c => c.UrineTestSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.UrineTestRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
