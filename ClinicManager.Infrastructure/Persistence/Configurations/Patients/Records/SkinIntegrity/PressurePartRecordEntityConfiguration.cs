using ClinicManager.Domain.Entities.PatientAggregate.Records.SkinIntegrity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.SkinIntegrity
{
   public class PressurePartRecordEntityConfiguration : IEntityTypeConfiguration<PressurePartEntity>
    {
        public void Configure(EntityTypeBuilder<PressurePartEntity> conf)
        {
            conf.ToTable("PressurePartRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.PressurePartCareTime);
            conf.Property(c => c.PressurePartCareFrequency);
            conf.Property(c => c.PressurePartCareSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.PressurePartRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
