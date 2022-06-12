using ClinicManager.Domain.Entities.PatientAggregate.Records.FluidBalance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.FluidBalance
{
    public class OralOutputRecordEntityConfiguration : IEntityTypeConfiguration<OralOutputEntity>
    {
        public void Configure(EntityTypeBuilder<OralOutputEntity> conf)
        {
            conf.ToTable("OralOutputRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.OutputMl);
            conf.Property(c => c.RunningOutputTotal);
            conf.Property(c => c.OralOutputTime);
            conf.Property(c => c.IsUrine);

            conf.HasOne(c => c.Patient).WithMany(c => c.OralOutputRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
