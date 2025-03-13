using Microsoft.EntityFrameworkCore;
using Weather.API.Models.Domain;
using Weather.API.Models.DTO;

namespace Weather.API.Data
{
    public class WeatherDataDbContext: DbContext
    {
        public WeatherDataDbContext(DbContextOptions<WeatherDataDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<WeatherData> WeatherDatas { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

    // Seed data for WeatherData     
    var dummyWeatherData = new List<WeatherData>()
    {
    new WeatherData { Id = Guid.NewGuid(), CityName = "New York", Temperature = 23.5m, WeatherCondition = "Sunny", LastUpdated = DateTime.Now.AddDays(-1) },
    new WeatherData { Id = Guid.NewGuid(), CityName = "Los Angeles", Temperature = 27.8m, WeatherCondition = "Cloudy", LastUpdated = DateTime.Now.AddDays(-2) },
    new WeatherData { Id = Guid.NewGuid(), CityName = "Chicago", Temperature = 15.2m, WeatherCondition = "Rainy", LastUpdated = DateTime.Now.AddDays(-3) },
    new WeatherData { Id = Guid.NewGuid(), CityName = "Houston", Temperature = 30.1m, WeatherCondition = "Sunny", LastUpdated = DateTime.Now.AddDays(-4) },
    new WeatherData { Id = Guid.NewGuid(), CityName = "Phoenix", Temperature = 35.6m, WeatherCondition = "Sunny", LastUpdated = DateTime.Now.AddDays(-5) },
    new WeatherData { Id = Guid.NewGuid(), CityName = "Philadelphia", Temperature = 18.9m, WeatherCondition = "Windy", LastUpdated = DateTime.Now.AddDays(-6) },
    new WeatherData { Id = Guid.NewGuid(), CityName = "San Antonio", Temperature = 29.3m, WeatherCondition = "Rainy", LastUpdated = DateTime.Now.AddDays(-7) },
    new WeatherData { Id = Guid.NewGuid(), CityName = "San Diego", Temperature = 24.5m, WeatherCondition = "Foggy", LastUpdated = DateTime.Now.AddDays(-8) },
    new WeatherData { Id = Guid.NewGuid(), CityName = "Dallas", Temperature = 32.2m, WeatherCondition = "Sunny", LastUpdated = DateTime.Now.AddDays(-9) },
    new WeatherData { Id = Guid.NewGuid(), CityName = "San Jose", Temperature = 26.4m, WeatherCondition = "Cloudy", LastUpdated = DateTime.Now.AddDays(-10) },
    new WeatherData { Id = Guid.NewGuid(), CityName = "Austin", Temperature = 28.5m, WeatherCondition = "Stormy", LastUpdated = DateTime.Now.AddDays(-11) },
    new WeatherData { Id = Guid.NewGuid(), CityName = "Jacksonville", Temperature = 22.0m, WeatherCondition = "Rainy", LastUpdated = DateTime.Now.AddDays(-12) },
    new WeatherData { Id = Guid.NewGuid(), CityName = "Fort Worth", Temperature = 31.5m, WeatherCondition = "Sunny", LastUpdated = DateTime.Now.AddDays(-13) },
    new WeatherData { Id = Guid.NewGuid(), CityName = "Columbus", Temperature = 20.3m, WeatherCondition = "Cloudy", LastUpdated = DateTime.Now.AddDays(-14) },
    new WeatherData { Id = Guid.NewGuid(), CityName = "Charlotte", Temperature = 25.1m, WeatherCondition = "Windy", LastUpdated = DateTime.Now.AddDays(-15) },
    new WeatherData { Id = Guid.NewGuid(), CityName = "San Francisco", Temperature = 19.8m, WeatherCondition = "Foggy", LastUpdated = DateTime.Now.AddDays(-16) },
    new WeatherData { Id = Guid.NewGuid(), CityName = "Indianapolis", Temperature = 17.4m, WeatherCondition = "Rainy", LastUpdated = DateTime.Now.AddDays(-17) },
    new WeatherData { Id = Guid.NewGuid(), CityName = "Seattle", Temperature = 21.9m, WeatherCondition = "Cloudy", LastUpdated = DateTime.Now.AddDays(-18) },
    new WeatherData { Id = Guid.NewGuid(), CityName = "Denver", Temperature = 16.3m, WeatherCondition = "Sunny", LastUpdated = DateTime.Now.AddDays(-19) },
    new WeatherData { Id = Guid.NewGuid(), CityName = "Washington", Temperature = 20.7m, WeatherCondition = "Windy", LastUpdated = DateTime.Now.AddDays(-20) },
    new WeatherData { Id = Guid.NewGuid(), CityName = "Boston", Temperature = 14.2m, WeatherCondition = "Rainy", LastUpdated = DateTime.Now.AddDays(-21) },
    new WeatherData { Id = Guid.NewGuid(), CityName = "El Paso", Temperature = 27.6m, WeatherCondition = "Sunny", LastUpdated = DateTime.Now.AddDays(-22) },
    new WeatherData { Id = Guid.NewGuid(), CityName = "Nashville", Temperature = 22.9m, WeatherCondition = "Cloudy", LastUpdated = DateTime.Now.AddDays(-23) },
    new WeatherData { Id = Guid.NewGuid(), CityName = "Detroit", Temperature = 19.1m, WeatherCondition = "Foggy", LastUpdated = DateTime.Now.AddDays(-24) },
    new WeatherData { Id = Guid.NewGuid(), CityName = "Oklahoma City", Temperature = 30.0m, WeatherCondition = "Sunny", LastUpdated = DateTime.Now.AddDays(-25) }
    };

            
          

            modelBuilder.Entity<WeatherData>().HasData(dummyWeatherData);
        }
    }
}
