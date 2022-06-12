using ClinicManager.Domain.Entities.DayFeesAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.DayFees
{
    public class DayFeeEntityConfiguration : IEntityTypeConfiguration<DayFeesEntity>
    {
        public void Configure(EntityTypeBuilder<DayFeesEntity> conf)
        {
            conf.ToTable("DayFees", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.DayFeeCode).IsRequired();
            conf.Property(c => c.DayFeeDescription).IsRequired();
            conf.Property(c => c.DateAdded).IsRequired();
            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
