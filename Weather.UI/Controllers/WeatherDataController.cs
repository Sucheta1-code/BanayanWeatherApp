using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using Weather.UI.Models.DTO;

namespace Weather.UI.Controllers
{
    public class WeatherDataController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public WeatherDataController(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<WeatherDataDto> response = new List<WeatherDataDto>();
            try
            {
                // Get All WeatherData from Web API
                var client = _httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7110/api/WeatherData");

                httpResponseMessage.EnsureSuccessStatusCode();
                string responseBody= await httpResponseMessage.Content.ReadAsStringAsync();

                //ViewBag.Resonse= responseBody;

                response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<WeatherDataDto>>());
            }
            catch (Exception ex)
            {
                // Log the exception
            }

            return View();


           
        }
    }
}
