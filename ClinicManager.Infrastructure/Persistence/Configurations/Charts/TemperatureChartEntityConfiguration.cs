using ClinicManager.Domain.Entities.ChartsAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Charts
{
    public class TemperatureChartEntityConfiguration : IEntityTypeConfiguration<TemperatureChartEntity>
    {
        public void Configure(EntityTypeBuilder<TemperatureChartEntity> conf)
        {
            conf.ToTable("TemperatureCharts", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.TempRateEntry);
            conf.Property(c => c.Time);

            conf.HasOne(c => c.Patient).WithMany(c => c.TemperatureCharts).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
