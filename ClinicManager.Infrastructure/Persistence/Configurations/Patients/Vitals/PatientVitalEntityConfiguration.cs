using ClinicManager.Domain.Entities.PatientAggregate.Vitals;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Vitals
{
    public class PatientVitalEntityConfiguration : IEntityTypeConfiguration<PatientVitalEntity>
    {
        public void Configure(EntityTypeBuilder<PatientVitalEntity> conf)
        {
            conf.ToTable("PatientVitals", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.Temperature).IsRequired();
            conf.Property(c => c.BloodPressure).IsRequired();
            conf.Property(c => c.Pulse).IsRequired();
            conf.Property(c => c.RespitoryRate).IsRequired();
            conf.Property(c => c.BloodSaturation).IsRequired();
            conf.Property(c => c.Height).IsRequired();
            conf.Property(c => c.Weight).IsRequired();
            conf.Property(c => c.BodyMassIndex).IsRequired();
            conf.Property(c => c.LastTime).IsRequired();

            conf.HasOne(c => c.Patient).WithMany(c => c.PatientVitals).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
