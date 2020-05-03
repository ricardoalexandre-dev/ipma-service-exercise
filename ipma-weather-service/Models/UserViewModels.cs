
namespace ipma_weather_service.Models
{
    public class UserViewModel
    {
        public SearchCity SearchCity { get; set; }
        public WeatherResponse WeatherResponse { get; set; }
        public City City { get; set; }
        public GetData GetData { get; set; }
    }
}
