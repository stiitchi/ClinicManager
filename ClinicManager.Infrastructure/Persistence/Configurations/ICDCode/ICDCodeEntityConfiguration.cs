using ClinicManager.Domain.Entities.ICDCodeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClinicManager.Infrastructure.Persistence.Configurations.ICDCode
{
    public class ICDCodeEntityConfiguration : IEntityTypeConfiguration<ICDCodeEntity>
    {
        public void Configure(EntityTypeBuilder<ICDCodeEntity> conf)
        {
            conf.ToTable("ICDCodes", "dbo");
            conf.HasKey(c => c.Id);
            conf.Property(c => c.IcdCode).IsRequired();
            conf.Property(c => c.IcdDescription).IsRequired();
            conf.Property(c => c.DateAdded).IsRequired();

            conf.Property(c => c.IsActive).IsRequired();

            conf.HasIndex(c => c.Id);
            conf.HasQueryFilter(t => t.IsActive);
        }
    }
}
