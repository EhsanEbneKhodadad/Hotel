using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Data
{
    public class HotelData
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address{ get; set; }
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public Country Country { get; set; }
    }
}
