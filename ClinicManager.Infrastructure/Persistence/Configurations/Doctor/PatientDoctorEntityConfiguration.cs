using ClinicManager.Domain.Entities.DoctorsAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Doctor
{
     public class PatientDoctorEntityConfiguration : IEntityTypeConfiguration<PatientDoctorEntity>
    {
        public void Configure(EntityTypeBuilder<PatientDoctorEntity> conf)
        {
            conf.ToTable("PatientDoctor", "dbo");
            conf.HasKey(c => c.Id);

            conf.HasOne(c => c.Patient).WithMany().HasForeignKey(c => c.PatientId);
            conf.HasOne(c => c.Doctor).WithMany().HasForeignKey(c => c.DoctorId);
            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasIndex(c => c.DoctorId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
