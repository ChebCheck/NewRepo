using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using WebApplication1.Services;
using WebApplication1.validation;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
        private IPostHandler _postHandler;
        private BookValidator _bookValidator;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IPostHandler postHandler, BookValidator bookValidator)
        {
            _logger = logger;
            _postHandler = postHandler;
            _bookValidator = bookValidator;
        }

        [HttpGet(Name = "GetWeatherForecast")]
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

        [HttpPost(Name = "PostBook")]
        public string Post(Book book)
        {
            if (_bookValidator.IsValid(book))
                return "completed";
            else return "not valid";
        }
    }
}