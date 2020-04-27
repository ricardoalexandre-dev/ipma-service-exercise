using ipma_weather_service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipma_weather_service.Repositories
{
    public interface IWeatherServiceRepository
    {
        WeatherResponse GetForecast(int city);
    }
}
