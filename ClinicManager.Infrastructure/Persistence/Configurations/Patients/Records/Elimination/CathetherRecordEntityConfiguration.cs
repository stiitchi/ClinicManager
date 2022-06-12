using ClinicManager.Domain.Entities.PatientAggregate.Records.Elimination;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Records.Elimination
{
    public class CathetherRecordEntityConfiguration : IEntityTypeConfiguration<CathetherEntity>
    {
        public void Configure(EntityTypeBuilder<CathetherEntity> conf)
        {
            conf.ToTable("CathetherRecords", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.CathetherFrequency);
            conf.Property(c => c.CathetherTime);
            conf.Property(c => c.CathetherSignature).IsRequired(false);

            conf.HasOne(c => c.Patient).WithMany(c => c.CathetherRecords).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
