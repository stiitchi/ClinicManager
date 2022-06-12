using ClinicManager.Domain.Entities.PatientAggregate.Records.Psychological;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Psychological
{
     public class CommunicationRecordEntityConfiguration : IEntityTypeConfiguration<CommunicationEntity>
    {
        public void Configure(EntityTypeBuilder<CommunicationEntity> conf)
        {
            conf.ToTable("CommunicationRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.CommunicationTime);
            conf.Property(c => c.CommunicationFrequency);
            conf.Property(c => c.CommunicationSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.CommunicationRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
