using ClinicManager.Domain.Entities.PatientAggregate.Records.Oxygenation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Oxygenation
{
    public class InhalaNebsRecordEntityConfiguration : IEntityTypeConfiguration<InhalaNebsEntity>
    {
        public void Configure(EntityTypeBuilder<InhalaNebsEntity> conf)
        {
            conf.ToTable("InhalaNebsRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.InhalaNebsTime);
            conf.Property(c => c.InhalaNebsFrequency);
            conf.Property(c => c.InhalaNebsSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.InhalaNebsRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
