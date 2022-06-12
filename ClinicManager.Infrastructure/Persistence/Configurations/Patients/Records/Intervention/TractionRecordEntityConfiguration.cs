using ClinicManager.Domain.Entities.PatientAggregate.Records.Intervention;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Intervention
{
     public class TractionRecordEntityConfiguration : IEntityTypeConfiguration<TractionEntity>
    {
        public void Configure(EntityTypeBuilder<TractionEntity> conf)
        {
            conf.ToTable("TractionRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.TractionTime);
            conf.Property(c => c.TractionFrequency);
            conf.Property(c => c.TractionSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.TractionRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
