using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherAPI
{
    public class Settings
    {
        public static string Secret = Environment.GetEnvironmentVariable("secret");
    }
}
