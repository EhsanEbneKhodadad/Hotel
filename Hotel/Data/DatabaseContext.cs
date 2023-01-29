using Hotel.Configurations.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Data
{
    public class DatabaseContext: IdentityDbContext<ApiUser>
    {

        public DatabaseContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }   
        public DbSet<HotelData> HotelsData { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());
            builder.ApplyConfiguration(new CountryConfiguration());
            builder.ApplyConfiguration(new HotelConfiguration());

        }
    }
}
