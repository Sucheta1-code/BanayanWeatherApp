using Weather.API.Models.Domain;

namespace Weather.API.Services
{
    public interface IOpenWeatherService
    {
        Task<WeatherData> FetchWeatherAsync(string city);
    }
}
