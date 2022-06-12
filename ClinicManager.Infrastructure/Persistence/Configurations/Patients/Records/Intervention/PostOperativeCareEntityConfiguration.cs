using ClinicManager.Domain.Entities.PatientAggregate.Records.Intervention;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Intervention
{
    public class PostOperativeCareEntityConfiguration : IEntityTypeConfiguration<PostOperativeCareEntity>
    {
        public void Configure(EntityTypeBuilder<PostOperativeCareEntity> conf)
        {
            conf.ToTable("PostOperativeCareRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.PostOperativeCareTime);
            conf.Property(c => c.PostOperativeCareFrequency);
            conf.Property(c => c.PostOperativeCareSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.PostOperativeCareRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
