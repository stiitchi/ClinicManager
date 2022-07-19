using ClinicManager.Domain.Entities.UserAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.User
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> conf)
        {
            conf.ToTable("Users", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.IsActive).IsRequired();
            conf.Property(c => c.Email).HasMaxLength(200);
            conf.Property(c => c.MobileNo).HasMaxLength(50);
            conf.Property(c => c.FirstName).HasMaxLength(50).IsRequired();
            conf.Property(c => c.LastName).HasMaxLength(50).IsRequired();
            conf.Property(c => c.PasswordHash).IsRequired(false);
            conf.Property(c => c.PasswordSalt).IsRequired(false);
            conf.Property(c => c.PasswordResetToken).IsRequired(false);
            conf.Property(c => c.PasswordResetTokenExpiry).IsRequired(false);
            conf.Property(c => c.ActivationToken).IsRequired(false);
            conf.Property(c => c.EmailConfirmed);



            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.Email);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
