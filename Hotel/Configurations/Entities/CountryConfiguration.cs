using Hotel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Configurations.Entities
{
    public class CountryConfiguration : IEntityTypeConfiguration<Country>
    {
        public void Configure(EntityTypeBuilder<Country> builder)
        {
            builder.HasData(
                 new Country
                 {
                     Id = 1,
                     Name = "Country 1",
                     ShortName = "C1"
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
        }
    }
}
