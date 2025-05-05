using CloneCode.Database;
using CloneCode.Entity;
using Microsoft.AspNetCore.Mvc;

namespace CloneCode.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private DatabaseContext _context;

        public WeatherForecastController(DatabaseContext context)
        {
            this._context = context;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public List<Book> Get()
        {
            List<Book> list = this._context.Books.ToList();

            return list;
        }
    }
}
