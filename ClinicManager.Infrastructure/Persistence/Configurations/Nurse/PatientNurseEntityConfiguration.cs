using ClinicManager.Domain.Entities.NurseAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Nurse
{
    public class PatientNurseEntityConfiguration : IEntityTypeConfiguration<PatientNurseEntity>
    {
        public void Configure(EntityTypeBuilder<PatientNurseEntity> conf)
        {
            conf.ToTable("PatientNurses", "dbo");
            conf.HasKey(c => c.Id);

            conf.HasOne(c => c.Patient).WithMany().HasForeignKey(c => c.PatientId);
            conf.HasOne(c => c.Nurse).WithMany().HasForeignKey(c => c.NurseId);
            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasIndex(c => c.NurseId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
