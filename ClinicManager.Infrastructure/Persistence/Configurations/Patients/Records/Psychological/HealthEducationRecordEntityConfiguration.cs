using ClinicManager.Domain.Entities.PatientAggregate.Records.Psychological;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Psychological
{
     public class HealthEducationRecordEntityConfiguration : IEntityTypeConfiguration<HealthCareEntity>
    {
        public void Configure(EntityTypeBuilder<HealthCareEntity> conf)
        {
            conf.ToTable("HealthEducationRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.HealthEducationTime);
            conf.Property(c => c.HealthEducationFrequency);
            conf.Property(c => c.HealthEducationSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.HealthCareRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
