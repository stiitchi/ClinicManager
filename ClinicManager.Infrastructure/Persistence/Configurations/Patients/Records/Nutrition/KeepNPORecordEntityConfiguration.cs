using ClinicManager.Domain.Entities.PatientAggregate.Records.Nutrition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Nutrition
{
    public class KeepNPORecordEntityConfiguration : IEntityTypeConfiguration<KeepNPOEntity>
    {
        public void Configure(EntityTypeBuilder<KeepNPOEntity> conf)
        {
            conf.ToTable("KeepNpoRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.KeepNPOTime);
            conf.Property(c => c.KeepNPOFrequency);
            conf.Property(c => c.KeepNPOSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.KeepNPORecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
