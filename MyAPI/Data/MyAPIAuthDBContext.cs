using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MyAPI.Data
{
    public class MyAPIAuthDBContext : IdentityDbContext
    {
        public MyAPIAuthDBContext(DbContextOptions<MyAPIAuthDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "8f06d963-fedc-419f-b85f-0e6b3e7ef780";
            var writerRoleId = "491fcf26-c63b-4638-ab9e-2ae37fedcb28";
            var roles = new List<IdentityRole>
            {
                new IdentityRole { Id = readerRoleId, ConcurrencyStamp = readerRoleId, Name = "Reader", NormalizedName = "Reader".ToUpper() },
                new IdentityRole { Id = writerRoleId, ConcurrencyStamp = writerRoleId, Name = "Writer", NormalizedName = "Writer".ToUpper() },
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
