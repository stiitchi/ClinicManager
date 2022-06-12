using ClinicManager.Domain.Entities.PatientAggregate.Records.CarePlanFluids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Fluids
{
     public class CarePlanOralTestConfiguration : IEntityTypeConfiguration<OralEntity>
    {
        public void Configure(EntityTypeBuilder<OralEntity> conf)
        {
            conf.ToTable("CarePlanOralRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.OralTestTime);
            conf.Property(c => c.OralTestFrequency);
            conf.Property(c => c.OralTestSignature);

            conf.HasOne(c => c.Patient).WithMany(c => c.OralRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
