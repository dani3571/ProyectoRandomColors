using Dal;
using Entities.Models;
using LogicaNegocios;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
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
       
        private readonly InteractionService _interactionService;
      

        public WeatherForecastController(ILogger<WeatherForecastController> logger, InteractionService interactionService)
        {
            _logger = logger;
            _interactionService = interactionService;
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


        [HttpGet("GetWeatherForecast")]
        public async Task<List<Interaction>> GetInteractionsAsync()
        {
            // Puedes agregar lógica adicional aquí si es necesario
            return await _interactionService.GetInteractionsAsync();
        }


        [HttpPost("CreateInteraction")]
        public async Task<IActionResult> LikeAsync([FromBody] InteractionDTo interactionDTo)
        {
            try
            {
                string ip = HttpContext.Connection.RemoteIpAddress?.ToString();
                await _interactionService.CreateInteractionAsync(interactionDTo, ip);

                return Ok();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}