using ipma_weather_service.Config;
using ipma_weather_service.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;


namespace ipma_weather_service.Repositories
{
    public class WeatherServiceRepository : IWeatherServiceRepository
    {
        WeatherResponse IWeatherServiceRepository.GetForecastByCity(int city)
        {
            // Connection String
            var client = new RestClient($"https://api.ipma.pt/open-data/forecast/meteorology/cities/daily/{city}.json");

            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                // Deserialize the string content into JToken object
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);

                // Deserialize the JToken object into our WeatherResponse Class
                return content.ToObject<WeatherResponse>();
            }

            return null;
        }


        WeatherResponse IWeatherServiceRepository.GetForecastForAllCities()
        {
            // Connection String
            var client = new RestClient($"http://api.ipma.pt/open-data/forecast/meteorology/cities/daily/hp-daily-forecast-day0.json");

            var request = new RestRequest(Method.GET);
            IRestResponse response = client.Execute(request);

            if (response.IsSuccessful)
            {
                // Deserialize the string content into JToken object
                var content = JsonConvert.DeserializeObject<JToken>(response.Content);

                // Deserialize the JToken object into our WeatherResponse Class
                return content.ToObject<WeatherResponse>();
            }

            return null;
        }


    }
}
