using ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Charts.ChartEntry
{
    public class RespitoryRateChartEntryEntityConfiguration : IEntityTypeConfiguration<RespitoryRateChartEntryEntity>
    {
        public void Configure(EntityTypeBuilder<RespitoryRateChartEntryEntity> conf)
        {
            conf.ToTable("RespitoryRateChartEntries", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.RespitoryRateChartEntry);

            conf.HasOne(c => c.RespitoryRateChart).WithMany(c => c.RespitoryRateChartEntries).HasForeignKey(c => c.RespitoryRateChartId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.RespitoryRateChartId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
