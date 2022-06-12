using ClinicManager.Domain.Entities.PatientAggregate.Records.Observations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Observations
{
    public class NeuroVascularEntityConfiguration : IEntityTypeConfiguration<NeurovascularEntity>
    {
        public void Configure(EntityTypeBuilder<NeurovascularEntity> conf)
        {
            conf.ToTable("NeurovascularRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.NeuroVascularFrequency);
            conf.Property(c => c.NeuroVascularTime);
            conf.Property(c => c.NeuroVascularSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.NeurovascularRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
