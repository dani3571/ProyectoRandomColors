using Dal;
using Entities.Models;
using LogicaNegocios;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Microsoft.AspNetCore.Http;
using Google.Api;
using Microsoft.Extensions.Hosting;
using ZstdSharp.Unsafe;

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


        [HttpGet("GetWeatherForecast")]

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
        [HttpGet("GetNewInteraction")]
        public InteractionRequest GetNewInteraction()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return _interactionService.GetInteractionRequest();
        }
        [HttpGet("GetUserInteraction/{email}")]
        public async Task<UserRequest> GetUser(string email)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return await _interactionService.GetUserReactionAsync(email);
        }
        [HttpGet("GetInteractions")]
        public async Task<List<Interaction>> GetInteractionsAsync()
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return await _interactionService.GetInteractionsAsync();
        }
        [HttpGet("GetUserByEmail/{email}")]
        public async Task<Users> GetUserByEmail(string email)
        {
            Response.Headers.Add("Access-Control-Allow-Origin", "*");
            return await _interactionService.GetUser(email);
        }
        [HttpPost("CreateNewUser")]
        public async Task<IActionResult> CreateUser([FromBody] UserDTo user)
        {
            try
            {
                string ip = HttpContext.Connection.RemoteIpAddress?.ToString();
                await _interactionService.CreateUserAsync(user);
                Response.Headers.Add("Access-Control-Allow-Origin", "*");
                return Ok(user);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Response.Headers.Add("Access-Control-Allow-Origin", "*");
                return StatusCode(500, "Error interno del servidor");
            }
        }

        [HttpPost("CreateInteraction")]
        public async Task<IActionResult> LikeAsync([FromBody] InteractionDTo interactionDTo)
        {
            try
            {
                string ip = HttpContext.Connection.RemoteIpAddress?.ToString();
                await _interactionService.CreateInteractionAsync(interactionDTo, ip);
                Response.Headers.Add("Access-Control-Allow-Origin", "*");
                return Ok(interactionDTo);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                Response.Headers.Add("Access-Control-Allow-Origin", "*");
                return StatusCode(500, "Error interno del servidor");
            }
        }
    }
}