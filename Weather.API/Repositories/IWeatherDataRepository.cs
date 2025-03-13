using Microsoft.EntityFrameworkCore;
using Weather.API.Models.Domain;

namespace Weather.API.Repositories
{
    public interface IWeatherDataRepository
    {
        Task<List<WeatherData>> GetAllWeatherForCityAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000);
            //,
            //string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000);

        Task<WeatherData?> GetWeatherByIDAsync(Guid id);

        Task<WeatherData?> GetWeatherByCityAsync(string city);

        Task<WeatherData?> CreateAsync(WeatherData weatherData);

        Task<WeatherData?> UpdateAsync(Guid id, WeatherData weatherData);
        Task<WeatherData?> DeleteAsync(Guid id);
    }
}
