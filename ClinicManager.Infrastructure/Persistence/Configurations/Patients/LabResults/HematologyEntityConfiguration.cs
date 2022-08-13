using ClinicManager.Domain.Entities.PatientAggregate.LabResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.LabResults
{
    public class HematologyEntityConfiguration : IEntityTypeConfiguration<HematologyEntity>
    {
        public void Configure(EntityTypeBuilder<HematologyEntity> conf)
        {
            conf.ToTable("PatientHematologyEntries", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.WhiteBloodCount).IsRequired();
            conf.Property(c => c.RedBloodCount).IsRequired();
            conf.Property(c => c.Hemoglobin).IsRequired();
            conf.Property(c => c.Hematocrit).IsRequired();
            conf.Property(c => c.MacrocyticAnemia).IsRequired();
            conf.Property(c => c.HemoglobinConcentration).IsRequired();
            conf.Property(c => c.PitCount).IsRequired();
            conf.Property(c => c.TotalCounted).IsRequired();

            conf.HasOne(c => c.Patient).WithMany(c => c.HematologyEntries).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
