using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Weather.API.Data
{
    public class WeatherAuthDbContext: IdentityDbContext
    {
        public WeatherAuthDbContext(DbContextOptions<WeatherAuthDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerRoleId = "ba0764d4-5ee4-42eb-a7d3-c5f419314c81";
            var writerRoleId = "39a787d1-ac21-40f1-bb46-eb825463ffc8";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerRoleId,
                    ConcurrencyStamp = readerRoleId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper()
                },
                new IdentityRole
                {
                    Id = writerRoleId,
                    ConcurrencyStamp = writerRoleId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper()
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);
        }
    }
}
