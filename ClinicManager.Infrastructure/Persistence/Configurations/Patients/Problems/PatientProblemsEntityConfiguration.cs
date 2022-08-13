using ClinicManager.Domain.Entities.PatientAggregate.Problems;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Problems
{
    public class PatientProblemsEntityConfiguration : IEntityTypeConfiguration<PatientProblemsEntity>
    {
        public void Configure(EntityTypeBuilder<PatientProblemsEntity> conf)
        {
            conf.ToTable("PatientProblems", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.Description).IsRequired();
            conf.Property(c => c.OnSetDate).IsRequired();

            conf.HasOne(c => c.Patient).WithMany(c => c.PatientProblems).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
