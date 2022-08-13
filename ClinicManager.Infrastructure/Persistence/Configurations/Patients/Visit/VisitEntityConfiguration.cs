using ClinicManager.Domain.Entities.PatientAggregate.Visits;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Patients.Visit
{
    public class VisitEntityConfiguration : IEntityTypeConfiguration<VisitEntity>
    {
        public void Configure(EntityTypeBuilder<VisitEntity> conf)
        {
            conf.ToTable("PatientVisits", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.StartDate).IsRequired();
            conf.Property(c => c.EndDate).IsRequired();
            conf.Property(c => c.ProblemDescription).IsRequired();
            conf.Property(c => c.Address).IsRequired();
            conf.Property(c => c.City).IsRequired();
            conf.Property(c => c.PostalCode).IsRequired();
            conf.Property(c => c.Province).IsRequired();

            conf.HasOne(c => c.Patient).WithMany(c => c.Visits).HasForeignKey(c => c.PatientId);

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.PatientId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
