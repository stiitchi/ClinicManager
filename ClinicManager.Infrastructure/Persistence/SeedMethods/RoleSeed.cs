using ClinicManager.Domain.Entities.UserAggregate;
using Microsoft.EntityFrameworkCore;

namespace ClinicManager.Infrastructure.Persistence.SeedMethods
{
    public class RoleSeed
    {
        public RoleSeed(ref ModelBuilder builder)
        {
            var list = new List<RoleEntity>();

            RoleEntity.List().ToList().ForEach(i =>
            {
                list.Add(new RoleEntity(i.Id, i.Name));
            });

            builder.Entity<RoleEntity>().HasData(list.ToArray());
        }
    }
}
