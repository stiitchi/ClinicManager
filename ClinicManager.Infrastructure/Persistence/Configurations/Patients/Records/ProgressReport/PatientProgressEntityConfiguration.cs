using ClinicManager.Domain.Entities.PatientAggregate.Records.ProgressRecords;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.ProgressReport
{
     public class PatientProgressEntityConfiguration : IEntityTypeConfiguration<PatientProgressEntity>
    {
        public void Configure(EntityTypeBuilder<PatientProgressEntity> conf)
        {
            conf.ToTable("ProgressReportRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.Allergy);
            conf.Property(c => c.Description);
            conf.Property(c => c.RiskFactor);
            conf.Property(c => c.DateAdded);
            conf.Property(c => c.TimeAdded);

            conf.HasOne(c => c.Patient).WithMany(c => c.PatientProgressRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}

