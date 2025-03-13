﻿using System.ComponentModel.DataAnnotations;

namespace Weather.API.Models.Domain
{
    public class WeatherData
    {
        public Guid Id { get; set; }
        public string CityName { get; set; }
        public decimal Temperature { get; set; }
        public string WeatherCondition { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
