using ClinicManager.Domain.Entities.WardAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Ward
{
    public class WardEntityConfiguration : IEntityTypeConfiguration<WardEntity>
    {
        public void Configure(EntityTypeBuilder<WardEntity> conf)
        {
            conf.ToTable("Wards", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.RoomNumber).IsRequired();
            conf.Property(c => c.WardNumber).IsRequired();
            conf.Property(c => c.TotalBeds).IsRequired();

            var beds = conf.Metadata.FindNavigation(nameof(WardEntity.Beds));
            beds.SetPropertyAccessMode(PropertyAccessMode.Field);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
