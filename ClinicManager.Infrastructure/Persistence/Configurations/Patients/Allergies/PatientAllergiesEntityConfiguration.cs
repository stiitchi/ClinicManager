using ClinicManager.Domain.Entities.PatientAggregate.Allergies;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Allergies
{
    public class PatientAllergiesEntityConfiguration : IEntityTypeConfiguration<PatientAllergiesEntity>
    {
        public void Configure(EntityTypeBuilder<PatientAllergiesEntity> conf)
        {
            conf.ToTable("PatientAllergies", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.Description).IsRequired();

            conf.HasOne(c => c.Patient).WithMany(c => c.PatientAllergies).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
