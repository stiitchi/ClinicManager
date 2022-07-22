using ClinicManager.Domain.Entities.ChartsAggregate.ChartEntry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Charts.ChartEntry
{
    public class BloodPressureChartEntryEntityConfiguration : IEntityTypeConfiguration<BloodPressureChartEntryEntity>
    {
        public void Configure(EntityTypeBuilder<BloodPressureChartEntryEntity> conf)
        {
            conf.ToTable("BloodPressureChartEntries", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.BloodPressureChartEntry);

            conf.HasOne(c => c.BloodPressureChart).WithMany(c => c.BloodPressureChartEntries).HasForeignKey(c => c.BloodPressureChartId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.BloodPressureChartId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
