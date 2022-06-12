using ClinicManager.Domain.Entities.PatientAggregate.Records.Oxygenation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Oxygenation
{
    public class MaskTimeRecordEntityConfiguration : IEntityTypeConfiguration<MaskTimeEntity>
    {
        public void Configure(EntityTypeBuilder<MaskTimeEntity> conf)
        {
            conf.ToTable("MaskRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.MaskTime);
            conf.Property(c => c.MaskFrequency);
            conf.Property(c => c.MaskSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.MaskTimeRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}