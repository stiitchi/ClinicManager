using ClinicManager.Domain.Entities.ChartsAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Charts
{
    public class BloodPressureChartEntityConfiguration : IEntityTypeConfiguration<BloodPressureChartEntity>
    {
        public void Configure(EntityTypeBuilder<BloodPressureChartEntity> conf)
        {
            conf.ToTable("BloodPressureCharts", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.BloodPressureChartEntry);
            conf.Property(c => c.Time);

            conf.HasOne(c => c.Patient).WithMany(c => c.BloodPressureCharts).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
