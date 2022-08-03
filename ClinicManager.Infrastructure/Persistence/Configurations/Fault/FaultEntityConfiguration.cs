using ClinicManager.Domain.Entities.FaultAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.Fault
{
       public class FaultEntityConfiguration : IEntityTypeConfiguration<FaultEntity>
    {
        public void Configure(EntityTypeBuilder<FaultEntity> conf)
        {
            conf.ToTable("Faults", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.IsActive).IsRequired();
            conf.Property(c => c.Type);
            conf.Property(c => c.Description);
            conf.Property(c => c.Serverity);
            conf.Property(c => c.CreatedOn);
            conf.Property(c => c.SeenOn);
            conf.Property(c => c.IsResolved);

            conf.HasOne(c => c.User).WithMany(c => c.Faults).HasForeignKey(c => c.UserId);

            conf.HasIndex(c => c.Id);
            conf.HasIndex(c => c.UserId);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
