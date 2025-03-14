using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text.Json;
using Weather.API.CustomActionFilters;
using Weather.API.Data;
using Weather.API.Models.Domain;
using Weather.API.Models.DTO;
using Weather.API.Repositories;
using Weather.API.Services;

namespace Weather.API.Controllers
{
    // https://localhost:7110/api/WeatherData
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherDataController : ControllerBase
    {

        private readonly IOpenWeatherService _openWeatherService;
        private readonly WeatherDataDbContext _dbContext;
        private readonly IWeatherDataRepository _weatherDataRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<WeatherDataController> _logger;
        public WeatherDataController(IOpenWeatherService openWeatherService, WeatherDataDbContext dbContext, IWeatherDataRepository weatherDataRepository, IMapper mapper, ILogger<WeatherDataController> logger)
        {
            this._openWeatherService = openWeatherService;
            this._dbContext = dbContext;
            this._weatherDataRepository = weatherDataRepository;
            this._mapper = mapper;
            _logger = logger;
        }

        // GET ALL WEATHERS
        // GET: /api/weather?filterOn=Name&filterQuery=Track&sortBy=Name&isAscending=true&pageNumber=1&pageSize=10
        // GET:https://localhost:7110/api/WeatherData
        [HttpGet]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetAllWeatherForCity([FromQuery] string? filterOn, [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy, [FromQuery] bool? isAscending,
            [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 1000)
          
        {
            

                //get the data from domainmodel-domain model
                var weatherDataDomain = await _weatherDataRepository.GetAllWeatherForCityAsync(filterOn, filterQuery, sortBy,
                       isAscending ?? true, pageNumber, pageSize);
            

            return Ok(_mapper.Map<List<WeatherDataDto>>(weatherDataDomain));
           

        }


        //GET: SINGLE Weather(Get Weather By Id)
        //GET: :https://localhost:7110/api/WeatherData/{id}
        [HttpGet]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetWeatherByID([FromRoute] Guid id)
        {
            //get the data from domainmodel-domain model
            var weatherDataDomain = await _weatherDataRepository.GetWeatherByIDAsync(id);
            if (weatherDataDomain == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WeatherDataDto>(weatherDataDomain));
        }

        // GET SINGLE Weather (Get Region By City)
        //GET: :https://localhost:7110/api/WeatherData/{city}
        [HttpGet("{city}")]
        //[Authorize(Roles = "Reader")]
        public async Task<IActionResult> GetWeatherByCity([FromRoute] string city)
        {
            //get the data from domainmodel-domain model
            var weatherDataDomain = await _weatherDataRepository.GetWeatherByCityAsync(city);
            if (weatherDataDomain == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WeatherDataDto>(weatherDataDomain));
        }


        // POST To fetch and store weather
        // POST: https://localhost:7110/api/WeatherData    
        [HttpPost]
        //[Authorize(Roles = "Writer")]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWeatherRequestDto addWeatherRequestDto)
        //public async Task<IActionResult> Create(string city)
        {
            var weatherData = await _openWeatherService.FetchWeatherAsync(addWeatherRequestDto.CityName);

            if (weatherData == null)
            {
                return BadRequest($"Failed to fetch weather data for {addWeatherRequestDto.CityName}.");
            }

            // Ensure unique weather data storage (Optional: Prevent duplicate entries)
            var existingWeather = await _weatherDataRepository.GetWeatherByCityAsync(addWeatherRequestDto.CityName);
            if (existingWeather != null)
            {
                return Conflict($"Weather data for {addWeatherRequestDto.CityName} already exists.");
            }

            // Map fetched weather data to the domain model
            var weatherDataDomain = new WeatherData
            {
                CityName = weatherData.CityName,
                Temperature = weatherData.Temperature,
                WeatherCondition = weatherData.WeatherCondition,
                LastUpdated = DateTime.UtcNow
            };
            
            // Save the weather data in the repository
            weatherDataDomain = await _weatherDataRepository.CreateAsync(weatherDataDomain);
            // Map Domain model back to DTO
            //var weatherDataDto = _mapper.Map<WeatherDataDto>(weatherDataDomain);

            // Map Domain model back to DTO
            var weatherDataDto = _mapper.Map<WeatherDataDto>(weatherDataDomain);
            return CreatedAtAction(nameof(GetWeatherByCity), new { city = weatherDataDto.CityName }, weatherDataDto);

            //return CreatedAtAction(nameof(GetWeatherByCity), new { id = weatherDataDto.Id }, weatherDataDto);                  

        }

        // Update weather
        // PUT:  https://localhost:7110/api/WeatherData
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        //[Authorize(Roles = "Writer")]
        public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] UpdateWeatherRequestDto updateWeatherRequestDto)
        {
            // Map DTO to Domain Model
            var weatherDataDomain = _mapper.Map<WeatherData>(updateWeatherRequestDto);


            // Check if weather exists
            weatherDataDomain = await _weatherDataRepository.UpdateAsync(id, weatherDataDomain);

            if (weatherDataDomain == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<WeatherDataDto>(weatherDataDomain));         

        }

        // Delete Region
        // DELETE: https://localhost:7110/api/WeatherData{id}
        [HttpDelete]
        [Route("{id:Guid}")]
        //[Authorize(Roles = "Writer,Reader")]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
              var weatherDataDomain = await _weatherDataRepository.DeleteAsync(id);

                if (weatherDataDomain == null)
                {
                    return NotFound();
                  
                }
            return Ok(_mapper.Map<WeatherDataDto>(weatherDataDomain));

        }
           
         }


   }

 
