using ClinicManager.Domain.Entities.PatientAggregate.Records.StoolCharts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.StoolChart
{
       public class StoolChartEntityConfiguration : IEntityTypeConfiguration<StoolChartEntity>
    {
        public void Configure(EntityTypeBuilder<StoolChartEntity> conf)
        {
            conf.ToTable("StoolChartRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.NormalBowelHabit);
            conf.Property(c => c.StoolChartDate);
            conf.Property(c => c.StoolChartTime);
            conf.Property(c => c.StoolColour).IsRequired(false);
            conf.Property(c => c.Blood);
            conf.Property(c => c.MucousAmount);
            conf.Property(c => c.BowelAmount).IsRequired(false);
            conf.Property(c => c.StoolColour).IsRequired(false);
            conf.Property(c => c.Consistency).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.StoolChartRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
