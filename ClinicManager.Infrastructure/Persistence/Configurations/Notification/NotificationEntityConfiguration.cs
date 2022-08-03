using ClinicManager.Domain.Entities.NotificationAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Notification
{
    public class NotificationEntityConfiguration : IEntityTypeConfiguration<NotificationEntity>
    {
        public void Configure(EntityTypeBuilder<NotificationEntity> conf)
        {
            conf.ToTable("Notifications", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.IsActive).IsRequired();
            conf.Property(c => c.Type);
            conf.Property(c => c.Description);
            conf.Property(c => c.CreatedOn);
            conf.Property(c => c.SeenOn);

            conf.HasOne(c => c.User).WithMany(c => c.Notifications).HasForeignKey(c => c.UserId);

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.UserId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
