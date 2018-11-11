using System;
using System.Net.Http;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RummageSale.Helpers;
using RummageSale.Models;
using Microsoft.AspNetCore.Cors;

namespace RummageSale.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("SiteCorsPolicy")]
    public class WeatherController : Controller
    {
        [HttpGet("zip/{zip:int}")]
        public async Task<IActionResult> GetByZip(int zip)
        {
            using (var client = new HttpClient())
            {
                try
                {
                    client.BaseAddress = new Uri("http://api.openweathermap.org");
                    string apiKey = "eedd3e1f0693443483d92e92f060dd11";
                    var response = await client.GetAsync($"/data/2.5/weather?zip={zip},us&appid={apiKey}&units=metric");
                    response.EnsureSuccessStatusCode();
                    var stringResult = await response.Content.ReadAsStringAsync();

                    OpenWeatherResponse openWeatherResponse = JsonConvert.DeserializeObject<OpenWeatherResponse>(stringResult);

                    WeatherResponse weatherResponse = new WeatherResponse
                    {
                        City = openWeatherResponse.Name,
                        Weather = openWeatherResponse.Weather[0].Main,
                        Country = openWeatherResponse.Sys.Country,
                        Temp = openWeatherResponse.Main.Temp,
                        Temp_min = openWeatherResponse.Main.Temp_min,
                        Temp_max = openWeatherResponse.Main.Temp_max
                    };
                    return Ok(weatherResponse);
                }
                catch (HttpRequestException httpRequestException)
                {
                    return BadRequest($"Error getting weather from OpenWeatherMap: {httpRequestException.Message}");
                }
            }
        }
    }
}