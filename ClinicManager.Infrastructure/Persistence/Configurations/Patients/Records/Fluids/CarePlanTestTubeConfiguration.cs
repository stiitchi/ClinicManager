using ClinicManager.Domain.Entities.PatientAggregate.Records.CarePlanFluids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Fluids
{
    public class CarePlanTestTubeConfiguration : IEntityTypeConfiguration<TestTubeEntity>
    {
        public void Configure(EntityTypeBuilder<TestTubeEntity> conf)
        {
            conf.ToTable("CarePlanTubeTests", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.TubeTestTime);
            conf.Property(c => c.TubeTestFrequency);
            conf.Property(c => c.TubeTestSignature);

            conf.HasOne(c => c.Patient).WithMany(c => c.TestTubeRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
