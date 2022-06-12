using ClinicManager.Domain.Entities.ICDCodeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.ICDCode
{
    public class PatientICDCodeEntityConfiguration : IEntityTypeConfiguration<PatientICDCodeEntity>
    {
        public void Configure(EntityTypeBuilder<PatientICDCodeEntity> conf)
        {
            conf.ToTable("PatientICDCodes", "dbo");
            conf.HasKey(c => c.Id);

            conf.HasOne(c => c.Patient).WithMany().HasForeignKey(c => c.PatientId);
            conf.HasOne(c => c.ICDCode).WithMany().HasForeignKey(c => c.IcdCodeId);
            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasIndex(c => c.IcdCodeId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
