using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace WeatherAPI.Controllers
{
    [ApiController]    
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {

        private static readonly Weather Weather0 = new Weather
        {
            Id = 0,
            Date = "2021-05-09",
            Lat = 36.1189F,
            Lon = -86.6892F,
            City = "Nashville",
            State = "Tennesee",
            Temperature = 17.3
        };

        private static readonly Weather Weather1 = new Weather
        {
            Id = 232,
            Date = "2021-05-09",
            Lat = 36.1189F,
            Lon = -86.6892F,
            City = "San Diego",
            State = "California",
            Temperature = 17.3
        };

        private static readonly Weather Weather2 = new Weather
        {
            Id = 121,
            Date = "2021-05-09",
            Lat = 36.1189F,
            Lon = -86.6892F,
            City = "Philadelphia",
            State = "Pennsylvania",
            Temperature = 17.3
        };

        private static readonly List<Weather> Weathers = new List<Weather>
        {
            Weather0, Weather1, Weather2
        };


        private readonly ILogger<WeatherController> _logger;

        public WeatherController(ILogger<WeatherController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Weather> Get()
        {
            var sortedWeathers = Weathers.OrderBy(w => w.Id).ToList();
            return sortedWeathers;
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var weather = Weathers.Where(w => w.Id == id).FirstOrDefault();
            if(weather == null)
            {
                return NotFound();
            }

            return Ok(weather);            
        }

       
        [HttpPost]
        public ActionResult Post([FromBody] Weather weather)
        {

            if (!User.Identity.IsAuthenticated)
            {
                return Forbid();
            }

            string pattern = @"^\d{4}\-(0[1-9]|1[012])\-(0[1-9]|[12][0-9]|3[01])$";
            
            if (!Regex.IsMatch(weather.Date, pattern))
            {
                return BadRequest("Date format invalid. Please use YYYY-MM-DD.");
            }

            var newWeather = weather;
            newWeather.Id = newWeather.GetHashCode();

            //newWeather.Lat = Math.Round(weather.Lat, 4);
            //newWeather.Lon = Math.Round(weather.Lon, 4);
           // newWeather.Temperature = Math.Round(weather.Temperature, 1);

            Weathers.Add(newWeather);

            return Ok(newWeather);
        }

    
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return Forbid();
            }

            var weather = Weathers.Where(w => w.Id == id).FirstOrDefault();
            if (weather == null)
            {
                return NotFound();
            }

            Weathers.Remove(weather);

            return NoContent();
        }
    }
}
