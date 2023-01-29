using Hotel.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Hotel.Configurations.Entities
{
    public class HotelConfiguration : IEntityTypeConfiguration<HotelData>
    {
        public void Configure(EntityTypeBuilder<HotelData> builder)
        {
            builder.HasData(
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
