using ClinicManager.Domain.Entities.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.User
{
    public class UserRoleEntityConfiguration : IEntityTypeConfiguration<UserRolesEntity>
    {
        public void Configure(EntityTypeBuilder<UserRolesEntity> conf)
        {
            conf.ToTable("UserRoles", "dbo");
            conf.HasKey(c => c.Id);

            conf.HasOne(c => c.Role).WithMany().HasForeignKey(c => c.RoleId);
            conf.HasOne(c => c.User).WithMany(c => c.UserRoles).HasForeignKey(c => c.UserId);
            conf.Property(c => c.IsActive).IsRequired();


            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.RoleId);
            conf.HasIndex(c => c.UserId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
