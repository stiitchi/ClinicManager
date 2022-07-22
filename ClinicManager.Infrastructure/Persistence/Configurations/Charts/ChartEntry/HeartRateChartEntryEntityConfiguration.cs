using ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Charts.ChartEntry
{
    public class HeartRateChartEntryEntityConfiguration : IEntityTypeConfiguration<HeartRateChartEntryEntity>
    {
        public void Configure(EntityTypeBuilder<HeartRateChartEntryEntity> conf)
        {
            conf.ToTable("HeartRateChartEntries", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.HeartRateChartEntry);

            conf.HasOne(c => c.HeartRateChart).WithMany(c => c.HeartRateChartEntries).HasForeignKey(c => c.HeartRateChartId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.HeartRateChartId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
