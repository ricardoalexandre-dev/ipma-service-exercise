using ipma_weather_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipma_weather_service.Extensions
{
    public static class CityExtensions
    {
        public static string ExtendedWeather(this City city) 
        {
            if (city.TMax <= 20)
            {
                return "It's Cold";
            }
            else 
            {
                return "It's Hot";
            }
        }

    }
}
