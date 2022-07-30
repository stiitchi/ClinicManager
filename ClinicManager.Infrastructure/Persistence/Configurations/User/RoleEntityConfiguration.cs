using ClinicManager.Domain.Entities.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.User
{
    public class RoleEntityConfiguration : IEntityTypeConfiguration<RoleEntity>
    {
        public void Configure(EntityTypeBuilder<RoleEntity> conf)
        {
            conf.ToTable("Roles", "lut");

            conf.HasKey(o => o.Id);

            conf.Property(o => o.Id)
                .ValueGeneratedNever()
                .IsRequired();

            conf.Property(o => o.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
