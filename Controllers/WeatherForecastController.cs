using CloneCode.Domains.Models;
using Microsoft.AspNetCore.Mvc;

namespace CloneCode.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        public WeatherForecastController()
        {
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public List<Book> Get()
        {
            return null;
        }
    }
}
