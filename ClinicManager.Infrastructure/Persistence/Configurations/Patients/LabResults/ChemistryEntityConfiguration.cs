using ClinicManager.Domain.Entities.PatientAggregate.LabResults;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.LabResults
{
    public class ChemistryEntityConfiguration : IEntityTypeConfiguration<ChemistryEntity>
    {
        public void Configure(EntityTypeBuilder<ChemistryEntity> conf)
        {
            conf.ToTable("PatientChemistryEntries", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.Sodium).IsRequired();
            conf.Property(c => c.Potassium).IsRequired();
            conf.Property(c => c.Chloride).IsRequired();
            conf.Property(c => c.CarbonDioxide).IsRequired();
            conf.Property(c => c.AnionGap).IsRequired();
            conf.Property(c => c.Creatinine).IsRequired();
            conf.Property(c => c.Glucose).IsRequired();
            conf.Property(c => c.Bun).IsRequired();
            conf.Property(c => c.HemoglobinA1c).IsRequired();
            conf.Property(c => c.Calcium).IsRequired();

            conf.HasOne(c => c.Patient).WithMany(c => c.ChemistryEntries).HasForeignKey(c => c.PatientId);


            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
