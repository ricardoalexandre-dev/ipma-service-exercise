using ipma_weather_service.Models;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ipma_weather_service.Repositories
{
    public class WeatherServiceRepository : RepositoryBase , IWeatherServiceRepository<WeatherResponse>
    {
        public async Task<WeatherResponse> GetForecastByCity(int city)
        {
            // Connection String
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(GetUrlForOneCity(city));

            var response = await httpClient.GetAsync(httpClient.BaseAddress);

            if (response.IsSuccessStatusCode)
            {
                var contentstring = await response.Content.ReadAsStringAsync();
                var content = JsonConvert.DeserializeObject<WeatherResponse>(contentstring);

                return content;
            }

            return null;
        }

        public async Task<WeatherResponse> GetForecastForAllCities()
        {
            // Connection String
            var httpClient = new HttpClient();
            httpClient.BaseAddress = new System.Uri(GetUrlForAllCities());

            var response = await httpClient.GetAsync(httpClient.BaseAddress);

            if (response.IsSuccessStatusCode)
            {
                var contentstring = await response.Content.ReadAsStringAsync();
                var content = JsonConvert.DeserializeObject<WeatherResponse>(contentstring);

                return content;
            }

            return null;
        }

        public override bool ValidateUrl(string url)
        {
            if (!string.IsNullOrEmpty(url))
            {
                return base.ValidateUrl(url);
            }
            return false;
        }


        protected override string GetUrlForAllCities()
        {
            var url = $"http://api.ipma.pt/open-data/forecast/meteorology/cities/daily/hp-daily-forecast-day0.json";
            if (ValidateUrl(url) == true) 
            {
                return url;
            }
            return null;
        }

        protected override string GetUrlForOneCity(int city)
        {
            var url = $"https://api.ipma.pt/open-data/forecast/meteorology/cities/daily/{city}.json";
            if (ValidateUrl(url) == true)
            {
                return url;
            }
            return null;
        }
    }
}
