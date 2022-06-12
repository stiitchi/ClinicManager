using ClinicManager.Domain.Entities.PatientAggregate.Records.Nutrition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Nutrition
{
   public class FullWardDietRecordEntityConfiguration : IEntityTypeConfiguration<WardDietEntity>
    {
        public void Configure(EntityTypeBuilder<WardDietEntity> conf)
        {
            conf.ToTable("FullWardDietRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.FullWardDietTime);
            conf.Property(c => c.FullWardDietFrequency);
            conf.Property(c => c.FullWardDietSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.WardDietRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
