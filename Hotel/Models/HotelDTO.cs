using Hotel.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotel.Models
{
    public class CreateHotelDataDTO
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Maximum 50 characters")]
        public string Name { get; set; }
        public string Address { get; set; }
        [Required]
        [ForeignKey(nameof(Country))]
        public int CountryId { get; set; }
        public Country Country { get; set; }

    }

    public class HotelDataDTO: CreateHotelDataDTO
    {
        public int Id { get; set; }
    }
   
}
