using ClinicManager.Domain.Entities.PatientAggregate.Records.Mobility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Mobility
{
    public class WalkAssistanceRecordEntityConfiguration : IEntityTypeConfiguration<WalkAssistanceEntity>
    {
        public void Configure(EntityTypeBuilder<WalkAssistanceEntity> conf)
        {
            conf.ToTable("WalkAssistanceRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.WalkWithAssistanceTime);
            conf.Property(c => c.WalkWithAssistanceFrequency);
            conf.Property(c => c.WalkWithAssistanceSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.WalkAssistanceRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
