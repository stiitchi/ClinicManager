using ClinicManager.Domain.Entities.PatientAggregate.Records.Intervention;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Intervention
{
    public class WoundCareEntityConfiguration : IEntityTypeConfiguration<WoundCareEntity>
    {
        public void Configure(EntityTypeBuilder<WoundCareEntity> conf)
        {
            conf.ToTable("WoundCareRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.WoundCareTime);
            conf.Property(c => c.WoundCareFrequency);
            conf.Property(c => c.WoundCareSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.WoundCareRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
