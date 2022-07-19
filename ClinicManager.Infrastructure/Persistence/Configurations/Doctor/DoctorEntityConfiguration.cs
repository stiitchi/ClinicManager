using ClinicManager.Domain.Entities.DoctorsAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Doctor
{
    public class DoctorEntityConfiguration : IEntityTypeConfiguration<DoctorEntity>
    {
        public void Configure(EntityTypeBuilder<DoctorEntity> conf)
        {
            conf.ToTable("Doctors", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.IsActive).IsRequired();
            conf.Property(c => c.Email).HasMaxLength(200);
            conf.Property(c => c.MobileNo).HasMaxLength(50);
            conf.Property(c => c.FirstName).HasMaxLength(50).IsRequired();
            conf.Property(c => c.LastName).HasMaxLength(50).IsRequired();

            conf.HasOne(c => c.Ward).WithMany().HasForeignKey(c => c.WardId);

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.Email);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
