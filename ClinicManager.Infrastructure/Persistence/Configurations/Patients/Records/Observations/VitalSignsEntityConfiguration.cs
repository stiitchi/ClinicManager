using ClinicManager.Domain.Entities.PatientAggregate.Records.Observations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Observations
{
  public class VitalSignsEntityConfiguration : IEntityTypeConfiguration<VitalSignEntity>
    {
        public void Configure(EntityTypeBuilder<VitalSignEntity> conf)
        {
            conf.ToTable("VitalSignRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.VitalSignsTime);
            conf.Property(c => c.VitalSignsFrequency);
            conf.Property(c => c.VitalSignSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.VitalSignRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
