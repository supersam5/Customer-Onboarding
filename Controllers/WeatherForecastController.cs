using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Text.Json;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;


namespace Customer_Onboarding.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        int stateCount = 1;
        int lgaCount = 1;
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public List<StatesAndLgas> Get()
        {
            var rng = new Random();
            List<StatesAndLgas> data = new List<StatesAndLgas>();
            using (StreamReader r = new StreamReader("StatesAndLgas.json"))
            {
                string json = r.ReadToEnd();

                data = JsonSerializer.Deserialize<List<StatesAndLgas>>(json);
                Console.WriteLine(data.ToList());
            }
            /*
             Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
             */
            return data.ToList();
            
        }
    }
}
