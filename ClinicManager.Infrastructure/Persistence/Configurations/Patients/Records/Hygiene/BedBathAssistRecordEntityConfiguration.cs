using ClinicManager.Domain.Entities.PatientAggregate.Records.Hygiene;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Hygiene
{
    public class BedBathAssistRecordEntityConfiguration : IEntityTypeConfiguration<BedBathAssistEntity>
    {
        public void Configure(EntityTypeBuilder<BedBathAssistEntity> conf)
        {
            conf.ToTable("BedBathAssistRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.BedBathAssistTime);
            conf.Property(c => c.BedBathAssistFrequency);
            conf.Property(c => c.BedBathAssistSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.BedBathAssistRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
