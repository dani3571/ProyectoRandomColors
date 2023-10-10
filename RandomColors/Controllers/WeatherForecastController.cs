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


        [HttpGet]
        public async Task<List<Interaction>> GetInteractionsAsync()
        {
            // Puedes agregar l�gica adicional aqu� si es necesario
            return await _interactionService.GetInteractionsAsync();
        }
      

        [HttpPost]
        public async Task<IActionResult> LikeAsync()
        {
            try
            {
                // Obtener la direcci�n IP del usuario
                string ip = HttpContext.Connection.RemoteIpAddress?.ToString();

                // Obtener la hora actual y convertirla a un formato deseado
                string hora = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

                // Llamar al m�todo de servicio para crear la interacci�n con "like"
                await _interactionService.CreateInteractionAsync(ip, hora, "Like");

                return Ok();
            }
            catch (Exception ex)
            {
                // Manejar cualquier excepci�n que pueda ocurrir al guardar la interacci�n.
                // Puedes registrar el error o realizar cualquier otra acci�n necesaria.
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}