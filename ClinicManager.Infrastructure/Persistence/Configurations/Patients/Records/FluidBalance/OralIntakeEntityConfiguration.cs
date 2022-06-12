using ClinicManager.Domain.Entities.PatientAggregate.Records.FluidBalance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.FluidBalance
{
    public class OralIntakeEntityConfiguration : IEntityTypeConfiguration<OralIntakeTestEntity>
    {
        public void Configure(EntityTypeBuilder<OralIntakeTestEntity> conf)
        {
            conf.ToTable("OralIntakeRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.OralIntakeMl);
            conf.Property(c => c.OralIntakeTime);
            conf.Property(c => c.OralIntakeVolume);
            conf.Property(c => c.OralCheckType).IsRequired(false);
            conf.Property(c => c.OutputMl);
            conf.Property(c => c.IsUrine);

            conf.HasOne(c => c.Patient).WithMany(c => c.OralIntakeTestRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
