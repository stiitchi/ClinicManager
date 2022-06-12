using ClinicManager.Domain.Entities.PatientAggregate.Records.DailyCare;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.DailyCare
{
     public class DailyCareRecordEntityConfiguration : IEntityTypeConfiguration<DailyCareRecordEntity>
    {
        public void Configure(EntityTypeBuilder<DailyCareRecordEntity> conf)
        {
            conf.ToTable("DailyCareRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.CareRecord);
            conf.Property(c => c.DateAdded);
            conf.Property(c => c.TimeAdded);

            conf.HasOne(c => c.Patient).WithMany(c => c.DailyCareRecords).HasForeignKey(c => c.PatientId);


            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
