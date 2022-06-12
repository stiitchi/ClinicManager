using ClinicManager.Domain.Entities.PatientAggregate.Records.CarePlanSkinIntegrity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.SkinReport
{
       public class SkinReportEntityConfiguration : IEntityTypeConfiguration<SkinIntegrityReport>
       {
        public void Configure(EntityTypeBuilder<SkinIntegrityReport> conf)
        {
            conf.ToTable("SkinReportRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.SacrumDescription);
            conf.Property(c => c.HipsDescription);
            conf.Property(c => c.HealsDescription);
            conf.Property(c => c.OtherDescription);
            conf.Property(c => c.Comments);

            conf.HasOne(c => c.Patient).WithMany(c => c.SkinIntegrityReportRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}

