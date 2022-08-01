using ClinicManager.Domain.Entities.SubscriptionAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Subscription
{
    public class SubscriptionCartEntityConfiguration : IEntityTypeConfiguration<SubscriptionCartEntity>
    {
        public void Configure(EntityTypeBuilder<SubscriptionCartEntity> conf)
        {
            conf.ToTable("SubscriptionCart", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.IsActive).IsRequired();
            conf.Property(c => c.CartEntryName).IsRequired();
            conf.Property(c => c.Amount).IsRequired();

            conf.HasOne(c => c.Subscription).WithMany(c => c.SubscriptionCarts).HasForeignKey(c => c.SubscriptionId);

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.SubscriptionId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
