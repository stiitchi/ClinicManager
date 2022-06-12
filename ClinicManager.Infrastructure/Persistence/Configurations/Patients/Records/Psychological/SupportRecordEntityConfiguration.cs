using ClinicManager.Domain.Entities.PatientAggregate.Records.Psychological;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Psychological
{
     public class SuportRecordEntityConfiguration0 : IEntityTypeConfiguration<SupportEntity>
    {
        public void Configure(EntityTypeBuilder<SupportEntity> conf)
        {
            conf.ToTable("SupportRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.SupportTime);
            conf.Property(c => c.SupportFrequency);
            conf.Property(c => c.SupportSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.SupportRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
