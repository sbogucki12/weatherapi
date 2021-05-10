using System;

namespace WeatherAPI
{
    public class Weather
    {
        private double _lat;
        private double _lon;
        private double _temperature;
        public int Id { get; set; }
        public string Date { get; set; }
        public double Lat
        {
            get => _lat;
            set
            {
                _lat = Math.Round(value, 4);
            }
        }
        public double Lon
        {
            get => _lon;
            set
            {
                _lon = Math.Round(value, 4);
            }
        }
        public string City { get; set; }
        public string State { get; set; }
        public double Temperature
        {
            get => _temperature;
            set
            {
                _temperature = Math.Round(value, 1);
            }
        }

    }
}
