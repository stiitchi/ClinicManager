using ClinicManager.Domain.Entities.ChartsAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Charts
{
    public class RespitoryRateChartEntityConfiguration : IEntityTypeConfiguration<RespitoryRateChartEntity>
    {
        public void Configure(EntityTypeBuilder<RespitoryRateChartEntity> conf)
        {
            conf.ToTable("RespitoryCharts", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.RespitoryChartEntry);
            conf.Property(c => c.Time);

            conf.HasOne(c => c.Patient).WithMany(c => c.RespitoryRateCharts).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
