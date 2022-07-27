using ClinicManager.Domain.Entities.RoomAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Room
{
    public class RoomEntityConfiguration : IEntityTypeConfiguration<RoomEntity>
    {
        public void Configure(EntityTypeBuilder<RoomEntity> conf)
        {
            conf.ToTable("Rooms", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.IsActive).IsRequired();
            conf.Property(c => c.RoomNumber).HasMaxLength(200);

            conf.HasOne(c => c.Ward).WithMany(c => c.Rooms).HasForeignKey(c => c.WardId);

            var beds = conf.Metadata.FindNavigation(nameof(RoomEntity.Beds));
            beds.SetPropertyAccessMode(PropertyAccessMode.Field);

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.WardId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
