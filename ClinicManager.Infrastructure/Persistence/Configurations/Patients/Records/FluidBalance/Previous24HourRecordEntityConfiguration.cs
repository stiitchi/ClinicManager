using ClinicManager.Domain.Entities.PatientAggregate.Records.FluidBalance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.FluidBalance
{
    public class Previous24HourRecordEntityConfiguration : IEntityTypeConfiguration<Previous24HourIntakeEntity>
    {
        public void Configure(EntityTypeBuilder<Previous24HourIntakeEntity> conf)
        {
            conf.ToTable("Previous24HourRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.Previous24HourIntake);
            conf.Property(c => c.Previous24HourOutput);
            conf.Property(c => c.Total24HourIntake);

            conf.HasOne(c => c.Patient).WithMany(c => c.Previous24HourIntakeRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
