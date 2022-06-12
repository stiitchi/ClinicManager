using ClinicManager.Domain.Entities.PatientAggregate.Records.Oxygenation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Oxygenation
{
    public class PolyMaskRecordEntityConfiguration : IEntityTypeConfiguration<PolyMaskEntity>
    {
        public void Configure(EntityTypeBuilder<PolyMaskEntity> conf)
        {
            conf.ToTable("PolyMaskRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.PolyMaskTime);
            conf.Property(c => c.PolyMaskFrequency);
            conf.Property(c => c.PolyMaskSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.PolyMaskRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
