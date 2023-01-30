using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hotel.Models
{

    public class CreateCountryDTO
    {
        [Required]
        [StringLength(maximumLength: 50, ErrorMessage = "Maximum 50 characters")]
        public string Name { get; set; }
        [Required]
        [StringLength(maximumLength: 3, ErrorMessage = "Maximum 3 characters")]
        public string ShortName { get; set; }
    }

    public class UpdateCountryDTO : CreateCountryDTO { }

    public class CountryDTO: CreateCountryDTO
    {
        public int Id { get; set; }
        public IList<HotelDataDTO> Hotels { get; set; }
    }


}
