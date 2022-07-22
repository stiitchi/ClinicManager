using ClinicManager.Domain.Entities.ChartsAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Charts
{
    public class HeartRateChartEntityConfiguration : IEntityTypeConfiguration<HeartRateChartEntity>
    {
        public void Configure(EntityTypeBuilder<HeartRateChartEntity> conf)
        {
            conf.ToTable("HeartRateCharts", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.HeartRateChartEntry);
            conf.Property(c => c.Time);

            conf.HasOne(c => c.Patient).WithMany(c => c.HeartRateCharts).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
