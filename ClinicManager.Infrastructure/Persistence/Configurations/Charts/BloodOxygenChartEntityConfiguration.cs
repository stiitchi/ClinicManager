using ClinicManager.Domain.Entities.ChartsAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Charts
{
    public class BloodOxygenChartEntityConfiguration : IEntityTypeConfiguration<BloodOxygenChartEntity>
    {
        public void Configure(EntityTypeBuilder<BloodOxygenChartEntity> conf)
        {
            conf.ToTable("BloodOxygenCharts", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.BloodOxygenChartEntry);
            conf.Property(c => c.Time);

            conf.HasOne(c => c.Patient).WithMany(c => c.BloodOxygenCharts).HasForeignKey(c => c.PatientId);

            var bloodOxygenChartEntries = conf.Metadata.FindNavigation(nameof(BloodOxygenChartEntity.BloodOxygenChartEntries));
            bloodOxygenChartEntries.SetPropertyAccessMode(PropertyAccessMode.Field);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
