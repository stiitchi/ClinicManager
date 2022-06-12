using ClinicManager.Domain.Entities.PatientAggregate.Records.Mobility;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Mobility
{
    public class ExerciseRecordEntityConfiguration : IEntityTypeConfiguration<ExerciseEntity>
    {
        public void Configure(EntityTypeBuilder<ExerciseEntity> conf)
        {
            conf.ToTable("ExerciseRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.ExercisesTime);
            conf.Property(c => c.ExercisesFrequency);
            conf.Property(c => c.ExercisesSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.ExerciseRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
