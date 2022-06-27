using ClinicManager.Domain.Entities.BedAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Bed
{
    public class BedEntityConfiguration : IEntityTypeConfiguration<BedEntity>
    {
        public void Configure(EntityTypeBuilder<BedEntity> conf)
        {
            conf.ToTable("Beds", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.BedNumber).IsRequired();
            conf.Property(c => c.WardNumber).IsRequired(false);
            conf.HasOne(c => c.Ward).WithMany(c => c.Beds).HasForeignKey(c => c.WardId);
            conf.HasOne(c => c.Nurse).WithMany(c => c.Beds).HasForeignKey(c => c.NurseId).IsRequired(false);
            conf.HasOne(c => c.Patient).WithMany(c => c.Beds).HasForeignKey(c => c.PatientId).IsRequired(false);
            conf.Property(c => c.IsActive).IsRequired();

            var patientBeds = conf.Metadata.FindNavigation(nameof(BedEntity.PatientBeds));
            patientBeds.SetPropertyAccessMode(PropertyAccessMode.Field);

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.WardId);
            conf.HasIndex(c => c.NurseId);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
 