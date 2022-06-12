using ClinicManager.Domain.Entities.PatientAggregate.Records.Mobility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Mobility
{
    public class AssistIntoChairEntityConfiguration : IEntityTypeConfiguration<WalkChairEntity>
    {
        public void Configure(EntityTypeBuilder<WalkChairEntity> conf)
        {
            conf.ToTable("AssistIntoChairRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.AssistIntoChairTime);
            conf.Property(c => c.AssistIntoChairFrequency);
            conf.Property(c => c.AssistIntoChairSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.WalkChairRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
