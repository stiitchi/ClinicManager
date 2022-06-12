using ClinicManager.Domain.Entities.PatientAggregate.Records.CarePlanFluids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Fluids
{
    public class CarePlanFluidMonitorConfiguration : IEntityTypeConfiguration<MonitorFluidEntity>
    {
        public void Configure(EntityTypeBuilder<MonitorFluidEntity> conf)
        {
            conf.ToTable("CarePlanMonitorFluidRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.MonitorFluidTime);
            conf.Property(c => c.MonitorFluidFrequency);
            conf.Property(c => c.MonitorFluidSignature);

            conf.HasOne(c => c.Patient).WithMany(c => c.MonitorFluidRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
