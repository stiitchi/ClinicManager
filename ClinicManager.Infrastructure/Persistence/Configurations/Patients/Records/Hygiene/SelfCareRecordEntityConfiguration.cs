using ClinicManager.Domain.Entities.PatientAggregate.Records.Hygiene;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Hygiene
{
    public class SelfCareRecordEntityConfiguration : IEntityTypeConfiguration<SelfCareEntity>
    {
        public void Configure(EntityTypeBuilder<SelfCareEntity> conf)
        {
            conf.ToTable("SelfCareRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.SelfCareTime);
            conf.Property(c => c.SelfCareFrequency);
            conf.Property(c => c.SelfCareSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.SelfCareRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
