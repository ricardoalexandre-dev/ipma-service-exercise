using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ipma_weather_service.Models;
using ipma_weather_service.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ipma_weather_service.Controllers
{
    public class IpmaWeatherServiceController : Controller
    {
        private readonly IWeatherServiceRepository _weatherServiceRepository;

        // Dependency Injection
        public IpmaWeatherServiceController(IWeatherServiceRepository weatherServiceRepository)
        {
            _weatherServiceRepository = weatherServiceRepository;
        }

        // GET: IpmaWeatherService/SearchCity
        public IActionResult SearchCity()
        {
            var viewModel = new SearchCity();
            return View(viewModel);
        }

        // POST: IpmaWeatherService/SearchCity
        [HttpPost]
        public IActionResult SearchCity(SearchCity model)
        {
            // If the model is valid, consume the Weather API to bring the data of the city
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "IpmaWeatherService", new { city = model.CityGlobalIdLocal });
            }
            return View(model);
        }

        // GET: IpmaWeatherService/City
        public IActionResult City(int city)
        {
            // Consume the IPMA API in order to bring Forecast data in our page.
            WeatherResponse weatherResponse = _weatherServiceRepository.GetForecast(city);
            City viewModel = new City();

            if (weatherResponse != null)
            {
                viewModel.ForecastDate = weatherResponse.ForecastDate;
                viewModel.DataUpdate = weatherResponse.DataUpdate;
                viewModel.GlobalIdLocal = weatherResponse.GlobalIdLocal;
                viewModel.IdWeatherType = weatherResponse.IdWeatherType;
                viewModel.TempMin = weatherResponse.TempMin;
                viewModel.TempMax = weatherResponse.TempMax;
                viewModel.ClassWindSpeed = weatherResponse.ClassWindSpeed;
                viewModel.PredWindDir = weatherResponse.PredWindDir;
                viewModel.ProbPrecipita = weatherResponse.ProbPrecipita;
                viewModel.ClassPrecInt = weatherResponse.ClassPrecInt;
                viewModel.Latitude = weatherResponse.Latitude;
                viewModel.Longitude = weatherResponse.Longitude;
            }
            return View(viewModel);
        }
    }
}