using ClinicManager.Domain.Entities.PatientAggregate.Records.Mobility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Mobility
{
    public class MobilityRecordEntityConfiguration : IEntityTypeConfiguration<MobileImmobileEntity>
    {
        public void Configure(EntityTypeBuilder<MobileImmobileEntity> conf)
        {
            conf.ToTable("MobileImmobileRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.MobileImmobileTime);
            conf.Property(c => c.MobileImmobileFrequency);
            conf.Property(c => c.MobileImmobileSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.MobileImmobileRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
