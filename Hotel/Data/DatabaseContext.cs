using Microsoft.EntityFrameworkCore;

namespace Hotel.Data
{
    public class DatabaseContext: DbContext
    {

        public DatabaseContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }   
        public DbSet<HotelData> HotelsData { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Country>().HasData(
                new Country
                {
                    Id=1,
                    Name="Country 1",
                    ShortName="C1"
                },
                 new Country
                 {
                     Id = 2,
                     Name = "Country 2",
                     ShortName = "C2"
                 }, 
                 new Country
                 {
                     Id = 3,
                     Name = "Country 3",
                     ShortName = "C3"
                 }

            );
            builder.Entity<HotelData>().HasData(
            new HotelData
            {
                Id = 1,
                Name = "Hotel 1",
                Address = "A 1",
                CountryId = 1
        
            },
             new HotelData
             {
                 Id = 2,
                 Name = "Hotel 2",
                 Address = "A 2",
                 CountryId = 2

             },
             new HotelData
             {
                 Id = 3,
                 Name = "Hotel 3",
                 Address = "A 3",
                 CountryId = 3

             }

        );
        }
    }
}
