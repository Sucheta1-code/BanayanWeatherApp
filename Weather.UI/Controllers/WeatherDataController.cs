using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Text;
using Weather.UI.Models.DTO;
using Weather.UI.Models;
using System.Reflection;

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
                //Get All WeatherData from Web API
                var client = _httpClientFactory.CreateClient();

                var httpResponseMessage = await client.GetAsync("https://localhost:7110/api/WeatherData");

                httpResponseMessage.EnsureSuccessStatusCode();

                response.AddRange(await httpResponseMessage.Content.ReadFromJsonAsync<IEnumerable<WeatherDataDto>>());
            }
            catch (Exception ex)
            {
                // Log the exception
            }

            return View(response);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> Add(AddWeatherDataViewModel model)
        {
            var client = _httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Post,
                RequestUri = new Uri("https://localhost:7110/api/WeatherData"),
                Content = new StringContent(JsonSerializer.Serialize(model), Encoding.UTF8, "application/json")
            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            var respose = await httpResponseMessage.Content.ReadFromJsonAsync<WeatherDataDto>();

            if (respose is not null)
            {
                return RedirectToAction("Index", "WeatherData");
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid Id)
        {
            var client = _httpClientFactory.CreateClient();

            var response = await client.GetFromJsonAsync<WeatherDataDto>($"https://localhost:7110/api/WeatherData/{Id.ToString()}");

            if (response is not null)
            {
                return View(response);
            }

            return View(null);
        }


        [HttpPost]
        public async Task<IActionResult> Edit(WeatherDataDto request)
        {
            var client = _httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage()
            {
                Method = HttpMethod.Put,
                RequestUri = new Uri($"https://localhost:7110/api/WeatherData/{request.Id}"),
                Content = new StringContent(JsonSerializer.Serialize(request), Encoding.UTF8, "application/json")
            };

            var httpResponseMessage = await client.SendAsync(httpRequestMessage);
            httpResponseMessage.EnsureSuccessStatusCode();

            var respose = await httpResponseMessage.Content.ReadFromJsonAsync<WeatherDataDto>();

            if (respose is not null)
            {
                return RedirectToAction("Edit", "WeatherData");
            }

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Delete(WeatherDataDto request)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();

                var httpResponseMessage = await client.DeleteAsync($"https://localhost:7110/api/WeatherData/{request.Id}");

                httpResponseMessage.EnsureSuccessStatusCode();

                return RedirectToAction("Index", "WeatherData");
            }
            catch (Exception ex)
            {
                // Console
            }

            return View("Edit");
        }

    }
}
