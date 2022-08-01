using ClinicManager.Domain.Entities.SubscriptionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Subscription
{
    public class SubscriptionEntityConfiguration : IEntityTypeConfiguration<SubscriptionEntity>
    {
        public void Configure(EntityTypeBuilder<SubscriptionEntity> conf)
        {
            conf.ToTable("Subscriptions", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.IsActive).IsRequired();
            conf.Property(c => c.Email).HasMaxLength(200);
            conf.Property(c => c.MobileNo).HasMaxLength(200);
            conf.Property(c => c.ClinicName).HasMaxLength(200);
            conf.Property(c => c.ClinicAddress).HasMaxLength(200);
            conf.Property(c => c.RepFirstName).HasMaxLength(200);
            conf.Property(c => c.RepLastName).HasMaxLength(200);
            conf.Property(c => c.PostalCode).HasMaxLength(200);
            conf.Property(c => c.City).HasMaxLength(200);
            conf.Property(c => c.Province).HasMaxLength(200);
            conf.Property(c => c.StoragePlan).HasMaxLength(200);
            conf.Property(c => c.AmountOfNurses);
            conf.Property(c => c.OverallTotal);
            conf.Property(c => c.IsChecked);
            conf.Property(c => c.IsScheduled);
            conf.Property(c => c.DateScheduled);

            var subscriptionCarts = conf.Metadata.FindNavigation(nameof(SubscriptionEntity.SubscriptionCarts));
            subscriptionCarts.SetPropertyAccessMode(PropertyAccessMode.Field);

            conf.HasIndex(c => c.Id);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
