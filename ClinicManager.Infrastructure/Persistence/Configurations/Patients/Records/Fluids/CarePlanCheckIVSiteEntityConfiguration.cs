using ClinicManager.Domain.Entities.PatientAggregate.Records.CarePlanFluids;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Fluids
{
    public class CarePlanCheckIVSiteEntityConfiguration : IEntityTypeConfiguration<IVSiteEntity>
    {
        public void Configure(EntityTypeBuilder<IVSiteEntity> conf)
        {
            conf.ToTable("CarePlanCheckIVSiteTests", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.CheckIVSiteTime);
            conf.Property(c => c.CheckIVSiteFrequency);
            conf.Property(c => c.CheckIVSiteSignature);

            conf.HasOne(c => c.Patient).WithMany(c => c.IvSiteRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
