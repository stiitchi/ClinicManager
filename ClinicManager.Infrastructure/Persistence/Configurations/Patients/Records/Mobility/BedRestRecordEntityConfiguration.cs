using ClinicManager.Domain.Entities.PatientAggregate.Records.Mobility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Mobility
{
    public class BedRestRecordEntityConfiguration : IEntityTypeConfiguration<BedRestEntity>
    {
        public void Configure(EntityTypeBuilder<BedRestEntity> conf)
        {
            conf.ToTable("BedRestRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.BedRestTime);
            conf.Property(c => c.BedRestFrequency);
            conf.Property(c => c.BedRestSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.BedRestRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
