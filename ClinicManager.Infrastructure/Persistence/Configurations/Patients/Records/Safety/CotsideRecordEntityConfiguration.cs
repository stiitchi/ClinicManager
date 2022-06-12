using ClinicManager.Domain.Entities.PatientAggregate.Records.Safety;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Safety
{
     public class CotsideRecordEntityConfiguration : IEntityTypeConfiguration<CotsideEntity>
    {
        public void Configure(EntityTypeBuilder<CotsideEntity> conf)
        {
            conf.ToTable("CotsideRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.CotsidesTime);
            conf.Property(c => c.CotsidesFrequency);
            conf.Property(c => c.CotsidesSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.CotsideRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
