using AutoMapper;
using Weather.API.Models.Domain;
using Weather.API.Models.DTO;

namespace Weather.API.Mappings
{
    public class AutoMapperProfiles: Profile
    {
       
        public AutoMapperProfiles()
        {
            CreateMap<WeatherData, WeatherDataDto>().ReverseMap();
            CreateMap<AddWeatherRequestDto, WeatherData>().ReverseMap();
            CreateMap<UpdateWeatherRequestDto, WeatherData>().ReverseMap();
        }

    }
}
