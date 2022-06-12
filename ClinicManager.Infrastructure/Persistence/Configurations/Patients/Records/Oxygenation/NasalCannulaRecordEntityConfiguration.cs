using ClinicManager.Domain.Entities.PatientAggregate.Records.Oxygenation;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Oxygenation
{
    public class NasalCannulaRecordEntityConfiguration : IEntityTypeConfiguration<NasalCannulEntity>
    {
        public void Configure(EntityTypeBuilder<NasalCannulEntity> conf)
        {
            conf.ToTable("NasalCannulaRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.NasalCannulaTime);
            conf.Property(c => c.NasalCannulaFrequency);
            conf.Property(c => c.NasalCannulaSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.NasalCannulRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
