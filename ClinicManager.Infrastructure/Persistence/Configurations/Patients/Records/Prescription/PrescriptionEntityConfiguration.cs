using ClinicManager.Domain.Entities.PatientAggregate.Records.Prescription;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Prescription
{
    public class PrescriptionEntityConfiguration : IEntityTypeConfiguration<PrescriptionEntity>
    {
        public void Configure(EntityTypeBuilder<PrescriptionEntity> conf)
        {
            conf.ToTable("Prescriptions", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.Date);
            conf.Property(c => c.MedicationName);
            conf.Property(c => c.Dose);
            conf.Property(c => c.Frequency);
            conf.Property(c => c.ReqWS);
            conf.Property(c => c.ReqDate);
            conf.Property(c => c.PharDate);
            conf.Property(c => c.ReqQuantity);
            conf.Property(c => c.PharQuantity);
            conf.Property(c => c.DurationOfQuantity);
            conf.Property(c => c.Route);

            conf.HasOne(c => c.Patient).WithMany(c => c.Prescriptions).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
