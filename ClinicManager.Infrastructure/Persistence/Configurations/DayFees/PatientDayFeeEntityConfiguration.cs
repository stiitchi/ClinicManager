using ClinicManager.Domain.Entities.DayFeesAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.DayFees
{
    public class PatientDayFeeEntityConfiguration : IEntityTypeConfiguration<PatientDayFeesEntity>
    {
        public void Configure(EntityTypeBuilder<PatientDayFeesEntity> conf)
        {
            conf.ToTable("PatientDayFees", "dbo");
            conf.HasKey(c => c.Id);

            conf.HasOne(c => c.Patient).WithMany().HasForeignKey(c => c.PatientId);
            conf.HasOne(c => c.DayFees).WithMany().HasForeignKey(c => c.DayFeesId);
            conf.Property(c => c.DayFeeCode).IsRequired();
            conf.Property(c => c.DayFeeDescription).IsRequired();
            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasIndex(c => c.DayFeesId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
