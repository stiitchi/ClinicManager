using ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Charts.ChartEntry
{
    public class TemperatureChartEntryEntityConfiguration : IEntityTypeConfiguration<TemperatureChartEntryEntity>
    {
        public void Configure(EntityTypeBuilder<TemperatureChartEntryEntity> conf)
        {
            conf.ToTable("TemperatureChartEntries", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.TemperatureChartEntry);

            conf.HasOne(c => c.TemperatureChart).WithMany(c => c.TemperatureChartEntries).HasForeignKey(c => c.TemperatureChartId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.TemperatureChartId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
