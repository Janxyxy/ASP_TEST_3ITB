using Microsoft.AspNetCore.Mvc;
using ASP_TEST_3ITB.Models;

namespace ASP_TEST_3ITB.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        string[] summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };


        [HttpGet]
        [Route("forecast/{count}")]
        public IEnumerable<WeatherForecast> GetForecast(int count)
        {
            var forecast = Enumerable.Range(1, count).Select(index =>
                new WeatherForecast
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ))
        .ToArray();
            return forecast;
        }
    }
}
