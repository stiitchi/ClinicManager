using ClinicManager.Domain.Entities.PatientAggregate.Records.Safety;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Safety
{
     public class CheckIDBandsRecordEntityConfiguration : IEntityTypeConfiguration<CheckIdBandEntity>
    {
        public void Configure(EntityTypeBuilder<CheckIdBandEntity> conf)
        {
            conf.ToTable("CheckIDBandsRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.CheckIDBandsTime);
            conf.Property(c => c.CheckIDBandsFrequency);
            conf.Property(c => c.CheckIDBandsSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.CheckIdBandRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
