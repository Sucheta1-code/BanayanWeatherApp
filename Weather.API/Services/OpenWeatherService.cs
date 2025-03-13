using System.Net.Http;
using System.Text.Json;
using Weather.API.Models.Domain;

namespace Weather.API.Services
{
    public class OpenWeatherService: IOpenWeatherService
    {
        //private readonly IWeatherRepository _weatherRepository;
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public OpenWeatherService(IConfiguration configuration, IHttpClientFactory httpClientFactory)
        {
            //_weatherRepository = weatherRepository;
            _httpClient = httpClientFactory.CreateClient("OpenWeather");
            _apiKey = configuration["OpenWeather:ApiKey"] ?? throw new InvalidOperationException("OpenWeather API key is missing or null. Check appsettings.json.");
            if (string.IsNullOrEmpty(_apiKey))
            {
                throw new InvalidOperationException("OpenWeather API key is empty. Check appsettings.json.");
            }
        }
        public async Task<WeatherData> FetchWeatherAsync(string city)
        {
            var url = $"weather?q={city}&appid={_apiKey}&units=metric";
            var response = await _httpClient.GetStringAsync(url);
            var weatherJson = JsonSerializer.Deserialize<JsonElement>(response);

            if (!weatherJson.TryGetProperty("main", out JsonElement mainElement) ||
                !mainElement.TryGetProperty("temp", out JsonElement tempElement))
            {
                throw new Exception("Invalid weather data: Missing 'main.temp' property.");
            }

            if (!weatherJson.TryGetProperty("weather", out JsonElement weatherArray) ||
                weatherArray.ValueKind != JsonValueKind.Array || weatherArray.GetArrayLength() == 0 ||
                !weatherArray[0].TryGetProperty("description", out JsonElement weatherConditionElement))
            {
                throw new Exception("Invalid weather data: Missing 'weather[0].description' property.");
            }

            return new WeatherData
            {
                CityName = city,
                Temperature = tempElement.GetDecimal(),
                WeatherCondition = weatherConditionElement.GetString() ?? "Unknown",
                LastUpdated = DateTime.UtcNow
            };
        }
    }
}
