using System.ComponentModel.DataAnnotations;

namespace Weather.API.Models.DTO
{
    public class AddWeatherRequestDto
    {
        [Required]
        [MaxLength(100, ErrorMessage = "CityName has to be a maximum of 100 characters")]
        public string CityName { get; set; }
        ////[Required]
        //public decimal Temperature { get; set; }
        ////[Required]
        //public string WeatherCondition { get; set; }
        ////[Required]
        //public DateTime LastUpdated { get; set; }
    }
}
