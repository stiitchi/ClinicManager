using ClinicManager.Domain.Entities.PatientAggregate.Records.ComfortSleep;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.ComfortSleep
{
     public class ComfortSleepEntityConfiguration : IEntityTypeConfiguration<NurseCarePlanComfortSleepEntity>
    {
        public void Configure(EntityTypeBuilder<NurseCarePlanComfortSleepEntity> conf)
        {
            conf.ToTable("ComfortSleepRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.PainControlTime);
            conf.Property(c => c.PainControlFrequency);
            conf.Property(c => c.PainControlSignature);

            conf.HasOne(c => c.Patient).WithMany(c => c.ComfortSleepRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
