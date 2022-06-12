using ClinicManager.Domain.Entities.PatientAggregate.Records.Nutrition;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Nutrition
{
    public class SpecialRecordsEntityConfiguration : IEntityTypeConfiguration<SpecialEntity>
    {
        public void Configure(EntityTypeBuilder<SpecialEntity> conf)
        {
            conf.ToTable("SpecialRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.SpecialTime);
            conf.Property(c => c.SpecialFrequency);
            conf.Property(c => c.SpecialSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.SpecialRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
