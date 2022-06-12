using ClinicManager.Domain.Entities.PatientAggregate.Records.Observations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Observations
{
    public class NeuroLogicalEntityConfiguration : IEntityTypeConfiguration<NeurologicalEntity>
    {
        public void Configure(EntityTypeBuilder<NeurologicalEntity> conf)
        {
            conf.ToTable("NeurologicalRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.NeuroLogicalFrequency);
            conf.Property(c => c.NeuroLogicalTime);
            conf.Property(c => c.NeuroLogicalSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.NeurologicalRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
