using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {

        private static readonly Weather Weather0 = new Weather
        {
            Id = 0,
            Date = DateTime.Now,
            Lat = 36.1189F,
            Lon = -86.6892F,
            City = "Nashville",
            State = "Tennesee",
            Temperature = 17.3
        };

        private static readonly List<Weather> Weathers = new List<Weather>
        {
            Weather0
        };


        private readonly ILogger<WeatherController> _logger;

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Weather> Get()
        {
            return Weathers;
        }
    }
}
