using ClinicManager.Domain.Entities.PatientAggregate.Records.Hygiene;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Hygiene
{
    public class BedBathRecordEntityConfiguration : IEntityTypeConfiguration<BedBathEntity>
    {
        public void Configure(EntityTypeBuilder<BedBathEntity> conf)
        {
            conf.ToTable("BedBathRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.BedBathTime);
            conf.Property(c => c.BedBathFrequency);
            conf.Property(c => c.BedBathSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.BedBathRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
