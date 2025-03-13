using Microsoft.EntityFrameworkCore;
using Weather.API.Data;
using Weather.API.Models.Domain;

namespace Weather.API.Repositories
{
    public class SQLWeatherDataRepository : IWeatherDataRepository
    {
        private readonly WeatherDataDbContext _dbContext;
        public SQLWeatherDataRepository(WeatherDataDbContext dbContext)
        { 
            this._dbContext = dbContext;
        }
        public async Task<List<WeatherData>> GetAllWeatherForCityAsync(string? filterOn = null, string? filterQuery = null,
            string? sortBy = null, bool isAscending = true, int pageNumber = 1, int pageSize = 1000)
        {
            var weatherData = _dbContext.WeatherDatas.AsQueryable();
            // Filtering
            if (string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false)
            {
                if (filterOn.Equals("CityName", StringComparison.OrdinalIgnoreCase))
                {
                    if(filterOn.Equals("CityName", StringComparison.OrdinalIgnoreCase))
                    {
                        weatherData = weatherData.Where(x => x.CityName.Contains(filterQuery));
                    }
                    //weatherData = weatherData.Where(x => x.CityName.Contains(filterQuery));
                }
            }

            //Sorting

            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("CityName", StringComparison.OrdinalIgnoreCase))
                {
                    weatherData = isAscending ? weatherData.OrderBy(x => x.CityName) : weatherData.OrderByDescending(x => x.CityName);
                }
                else if (sortBy.Equals("WeatherCondition", StringComparison.OrdinalIgnoreCase))
                {
                    weatherData = isAscending ? weatherData.OrderBy(x => x.WeatherCondition) : weatherData.OrderByDescending(x => x.WeatherCondition);
                }
            }

            //Pagination
           var skipResults = (pageNumber - 1) * pageSize;

            //return await weatherData.Skip(skipResults).Take(pageSize).ToListAsync();
            return await weatherData.ToListAsync();
        }

        public async Task<WeatherData?> GetWeatherByIDAsync(Guid id)
        {
            return await _dbContext.WeatherDatas.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WeatherData?> GetWeatherByCityAsync(string city)
        {
            return await _dbContext.WeatherDatas.FirstOrDefaultAsync(x => x.CityName == city);
        }

        public async Task<WeatherData?> CreateAsync(WeatherData weatherData)
        {
            await _dbContext.WeatherDatas.AddAsync(weatherData);
            await _dbContext.SaveChangesAsync();
            return weatherData;
        }

        public async Task<WeatherData?> UpdateAsync(Guid id, WeatherData weatherData)
        {
            var existingWeatherData = await _dbContext.WeatherDatas.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWeatherData == null)
            {
                return null;
            }

            existingWeatherData.CityName = weatherData.CityName;
            existingWeatherData.Temperature = weatherData.Temperature;
            existingWeatherData.WeatherCondition = weatherData.WeatherCondition;
            existingWeatherData.LastUpdated = weatherData.LastUpdated;

            await _dbContext.SaveChangesAsync();
            return existingWeatherData;
        }


        public async Task<WeatherData?> DeleteAsync(Guid id)
        {
            var existingWeatherData = await _dbContext.WeatherDatas.FirstOrDefaultAsync(x => x.Id == id);

            if (existingWeatherData == null)
            {
                return null;
            }

            _dbContext.WeatherDatas.Remove(existingWeatherData);
            await _dbContext.SaveChangesAsync();
            return existingWeatherData;
        }
    }
}
