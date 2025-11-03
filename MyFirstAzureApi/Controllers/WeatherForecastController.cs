using Microsoft.AspNetCore.Mvc;

namespace MyFirstAzureApi.Controllers
{
    [ApiController]
    [Route("[controller]")] // <-- Ruta base: /weatherforecast
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Testing", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        // MÉTODO 1: Se queda como está.
        // Ruta final: GET /weatherforecast
        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        // MÉTODO 2: CORREGIDO
        // Ruta final: GET /weatherforecast/testing
        [HttpGet("testing")] // <-- ¡LA SOLUCIÓN! Esto se añade a la ruta base.
        public IActionResult GetTesting()
        {
            return Ok("Hola deploy");
        }

        // MÉTODO 3: CORREGIDO
        // Ruta final: GET /weatherforecast/hello
        [HttpGet("hello")] // <-- ¡LA SOLUCIÓN! Esto se añade a la ruta base.
        public IActionResult GetHello()
        {
            return Ok("Hello world");
        }
    }
}