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
            conf.Property(c => c.RoomNumber).IsRequired(false);
            conf.Property(c => c.IsOccupied).IsRequired();
            conf.HasOne(c => c.Room).WithMany(c => c.Beds).HasForeignKey(c => c.RoomId);
            conf.HasOne(c => c.Nurse).WithMany(c => c.Beds).HasForeignKey(c => c.NurseId).IsRequired(false);
            conf.HasOne(c => c.Patient).WithMany(c => c.Beds).HasForeignKey(c => c.PatientId).IsRequired(false);

            var patientBeds = conf.Metadata.FindNavigation(nameof(BedEntity.PatientBeds));
            patientBeds.SetPropertyAccessMode(PropertyAccessMode.Field);

            conf.Property(c => c.IsActive).IsRequired();
            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.RoomId);
            conf.HasIndex(c => c.NurseId);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
 