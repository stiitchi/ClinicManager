using ClinicManager.Domain.Entities.PatientAggregate.Records.Elimination;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Elimination
{
  public class ContinentRecordEntityConfiguration : IEntityTypeConfiguration<ContinentEntity>
    {
        public void Configure(EntityTypeBuilder<ContinentEntity> conf)
        {
            conf.ToTable("ContinentRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.ContinentFrequency);
            conf.Property(c => c.ContinentSignature).IsRequired(false);
            conf.Property(c => c.ContinentTime); 

            conf.HasOne(c => c.Patient).WithMany(c => c.ContinentRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
