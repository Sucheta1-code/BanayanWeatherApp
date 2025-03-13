namespace Weather.UI.Models
{
    public class AddWeatherDataViewModel
    {
        public string CityName { get; set; }
        public decimal Temperature { get; set; }
        public string WeatherCondition { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
