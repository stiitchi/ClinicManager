using ClinicManager.Domain.Entities.PatientAggregate.Records.SkinIntegrity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.SkinIntegrity
{
     public class ReportRednessEntityConfiguration : IEntityTypeConfiguration<RednessEntity>
    {
        public void Configure(EntityTypeBuilder<RednessEntity> conf)
        {
            conf.ToTable("ReportRednessRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.ReportRednessTime);
            conf.Property(c => c.ReportRednessFrequency);
            conf.Property(c => c.ReportRednessSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.RednessRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
