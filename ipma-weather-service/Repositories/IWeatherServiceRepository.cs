using System.Threading.Tasks;

namespace ipma_weather_service.Repositories
{
    public interface IWeatherServiceRepository<T>
    {
        T GetForecastByCity(int city);
        
        T GetForecastForAllCities();

        Task<T> GetColdestCity(); 

    }
}
