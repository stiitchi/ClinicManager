using ClinicManager.Domain.Entities.BedAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace ClinicManager.Infrastructure.Persistence.Configurations.Bed
{
    public class PatientBedEntityConfiguration : IEntityTypeConfiguration<PatientBedEntity>
    {
        public void Configure(EntityTypeBuilder<PatientBedEntity> conf)
        {
            conf.ToTable("PatientBeds", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.PatientName).IsRequired();

            conf.HasOne(c => c.Bed).WithMany(c => c.PatientBeds).HasForeignKey(c => c.BedId);
            conf.HasOne(c => c.Patient).WithMany(c => c.PatientBeds).HasForeignKey(c => c.PatientId);
            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.BedId);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
