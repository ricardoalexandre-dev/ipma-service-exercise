using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ipma_service;
using ipma_weather_service.Extensions;
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

        public ActionResult UserViewModel()
        {
            UserViewModel vmDemo = new UserViewModel();
            vmDemo.GetData = new GetData();
            vmDemo.City = new City();
            vmDemo.SearchCity = new SearchCity();
            vmDemo.WeatherResponse = new WeatherResponse();
            return View(vmDemo);
        }

        // GET: IpmaWeatherService/GetData
        public IActionResult GetData()
        {
            var viewModel = new UserViewModel();
            return View(viewModel);
        }

        // POST: IpmaWeatherService/GetData
        [HttpPost]
        public IActionResult GetData(UserViewModel model)
        {
            // If the model is valid, consume the Weather API to bring the data of the city
            if (ModelState.IsValid)
            {
                return RedirectToAction("WeatherResponse", "IpmaWeatherService");
            }
            return View(model);
        }

        // GET: IpmaWeatherService/WeatherResponse
        public IActionResult WeatherResponse()
        {
            // Consume the IPMA API in order to bring Forecast data in our page.
            WeatherResponse weatherResponse = _weatherServiceRepository.GetForecastForAllCities();
            City viewModel = new City();

            UserViewModel vmObject = new UserViewModel();
            vmObject.WeatherResponse = weatherResponse;

            if (weatherResponse != null)
            {
                for (int i = 0; i <= weatherResponse.Data.Count() - 1; i++)
                {
                    viewModel.GlobalIdLocal = weatherResponse.Data[i].GlobalIdLocal;
                    viewModel.IdWeatherType = weatherResponse.Data[i].IdWeatherType;
                    viewModel.TMin = weatherResponse.Data[i].TMin;
                    viewModel.TMax = weatherResponse.Data[i].TMax;
                    viewModel.ClassWindSpeed = weatherResponse.Data[i].ClassWindSpeed;
                    viewModel.PredWindDir = weatherResponse.Data[i].PredWindDir;
                    viewModel.ProbPrecipita = weatherResponse.Data[i].PrecipitaProb;
                    viewModel.ClassPrecInt = weatherResponse.Data[i].ClassPrecInt;
                    viewModel.Latitude = weatherResponse.Data[i].Latitude;
                    viewModel.Longitude = weatherResponse.Data[i].Longitude;
                }
            }

            var str = viewModel.ExtendedWeather(); // <---- extension method

            return View(vmObject); // <---- return viewModel of the cities
        }

        // GET: IpmaWeatherService/SearchCity
        public IActionResult SearchCity()
        {
            UserViewModel vmObject = new UserViewModel();

            return View(vmObject);
        }

        // POST: IpmaWeatherService/SearchCity
        [HttpPost]
        public IActionResult SearchCity(UserViewModel model)
        {

            // If the model is valid, consume the Weather API to bring the data of the city
            if (ModelState.IsValid)
            {
                return RedirectToAction("City", "IpmaWeatherService", new { city = model.SearchCity.CityGlobalIdLocal });
            }
            return View(model);
        }

        // GET: IpmaWeatherService/City
        public IActionResult City(int city)
        {
            // Consume the IPMA API in order to bring Forecast data in our page.
            WeatherResponse weatherResponse = _weatherServiceRepository.GetForecastByCity(city);
            City viewModel = new City();

            UserViewModel vmObject = new UserViewModel();
            vmObject.City = viewModel;

            if (weatherResponse != null)
            {
                //viewModel.ForecastDate = weatherResponse.ForecastDate;
                //viewModel.DataUpdate = weatherResponse.DataUpdate;
                viewModel.GlobalIdLocal = weatherResponse.GlobalIdLocal;
                viewModel.IdWeatherType = weatherResponse.Data[0].IdWeatherType;
                viewModel.TMin = weatherResponse.Data[0].TMin;
                viewModel.TMax = weatherResponse.Data[0].TMax;
                viewModel.ClassWindSpeed = weatherResponse.Data[0].ClassWindSpeed;
                viewModel.PredWindDir = weatherResponse.Data[0].PredWindDir;
                viewModel.ProbPrecipita = weatherResponse.Data[0].PrecipitaProb;
                viewModel.ClassPrecInt = weatherResponse.Data[0].ClassPrecInt;
                viewModel.Latitude = weatherResponse.Data[0].Latitude;
                viewModel.Longitude = weatherResponse.Data[0].Longitude;
            }

            var str = viewModel.ExtendedWeather();

            return View(vmObject);
        }

        

        
    }
}