using System;

namespace WeatherAPI
{
    public class Weather
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public float Lat { get; set; }
        public float Lon { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public double Temperature { get; set; }

    }
}
