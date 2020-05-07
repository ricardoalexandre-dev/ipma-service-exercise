using ipma_weather_service.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Net.Http;
using System.Threading.Tasks;

namespace ipma_weather_service.Repositories
{
    public class WeatherServiceRepository : IWeatherServiceRepository<WeatherResponse>
    {
        

        WeatherResponse IWeatherServiceRepository<WeatherResponse>.GetForecastByCity(int city)
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


        WeatherResponse IWeatherServiceRepository<WeatherResponse>.GetForecastForAllCities()
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


        public async Task<WeatherResponse> GetColdestCity()
        {
            // Connection String
            var httpClient = new HttpClient();
            
            var url = $"http://api.ipma.pt/open-data/forecast/meteorology/cities/daily/hp-daily-forecast-day0.json";
            httpClient.BaseAddress = new System.Uri(url);

            var response = await httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var contentstring = await response.Content.ReadAsStringAsync();
                var content = JsonConvert.DeserializeObject<WeatherResponse>(contentstring);

                return content;
            }

            return null;
        }

    }
}
