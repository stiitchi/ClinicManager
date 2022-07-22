using ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Charts.ChartEntry
{
    public class BloodOxygenChartEntryEntityConfiguration : IEntityTypeConfiguration<BloodOxygenChartEntryEntity>
    {
        public void Configure(EntityTypeBuilder<BloodOxygenChartEntryEntity> conf)
        {
            conf.ToTable("BloodOxygenChartEntries", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.BloodOxygenChartEntry);

            conf.HasOne(c => c.BloodOxygenChart).WithMany(c => c.BloodOxygenChartEntries).HasForeignKey(c => c.BloodOxygenChartId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.BloodOxygenChartId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
