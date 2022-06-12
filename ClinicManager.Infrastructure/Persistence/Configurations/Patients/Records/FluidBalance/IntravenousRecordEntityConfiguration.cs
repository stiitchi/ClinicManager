using ClinicManager.Domain.Entities.PatientAggregate.Records.FluidBalance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.FluidBalance
{
    public class IntravenousRecordEntityConfiguration : IEntityTypeConfiguration<IVTestEntity>
    {
        public void Configure(EntityTypeBuilder<IVTestEntity> conf)
        {
            conf.ToTable("IntravenousRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.IntravenousIntakeMl);
            conf.Property(c => c.IntravenousIntakeTime);
            conf.Property(c => c.IntravenousIntakeTimeCompleted);
            conf.Property(c => c.IntravenousIntakeStartVolume);
            conf.Property(c => c.IntravenousIntakeCompleteVolume);
            conf.Property(c => c.IvCheck);
            conf.Property(c => c.IvDescription).IsRequired(false);
            conf.Property(c => c.IntravenousRunningTotal);
            conf.Property(c => c.IvCheckType).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.IvTestRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
