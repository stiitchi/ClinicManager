using ClinicManager.Domain.Entities.PatientAggregate.Records.CarePlanFluids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Fluids
{
    public class CarePlanIVTestConfiguration : IEntityTypeConfiguration<IVEntity>
    {
        public void Configure(EntityTypeBuilder<IVEntity> conf)
        {
            conf.ToTable("CarePlanIVTests", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.IvTestTime);
            conf.Property(c => c.IvTestFrequency);
            conf.Property(c => c.IvTestSignature);

            conf.HasOne(c => c.Patient).WithMany(c => c.CarePlanIVTests).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
