using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipma_weather_service.Models
{
    public class WeatherResponse
    {
        public string Owner { get; set; }

        public string Country { get; set; }

        public DateTime ForecastDate { get; set; }

        public List<City> Data { get; set; }

        public DateTime DataUpdate { get; set; } 

        public int GlobalIdLocal { get; set; } 
    }
}
