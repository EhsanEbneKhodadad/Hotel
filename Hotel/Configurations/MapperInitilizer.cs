using AutoMapper;
using Hotel.Data;
using Hotel.Models;

namespace Hotel.Configurations
{
    public class MapperInitilizer: Profile
    {
        public MapperInitilizer()
        {
            CreateMap<Country, CountryDTO>().ReverseMap();
            CreateMap<Country, CreateCountryDTO>().ReverseMap();
            CreateMap<HotelData, HotelDataDTO>().ReverseMap();
            CreateMap<HotelData, CreateHotelDataDTO>().ReverseMap();
            CreateMap<ApiUser, UserDTO>().ReverseMap();
        }
    }
}
