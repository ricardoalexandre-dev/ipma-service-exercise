using System.Threading.Tasks;

namespace ipma_weather_service.Repositories
{
    public interface IWeatherServiceRepository<T>
    {
        Task<T> GetForecastByCity(int city);
        
        Task<T> GetForecastForAllCities();
    }
}
