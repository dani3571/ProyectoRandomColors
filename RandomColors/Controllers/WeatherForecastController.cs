using Entities.Models;
using LogicaNegocios;
using Microsoft.AspNetCore.Mvc;

namespace RandomColors.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly InteractionLN _interactionLN;
      

        public WeatherForecastController(ILogger<WeatherForecastController> logger, InteractionLN interactionLN)
        {
            _logger = logger;
            _interactionLN = interactionLN;
        }

//        [HttpGet(Name = "GetWeatherForecast")]

        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }


        [HttpGet]
        public async Task<List<Interaction>> GetInteractionsAsync()
        {
            // Puedes agregar lógica adicional aquí si es necesario
            return await _interactionLN.GetInteractionsAsync();
        }


    }
}