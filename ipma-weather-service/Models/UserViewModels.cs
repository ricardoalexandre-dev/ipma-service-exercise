
namespace ipma_weather_service.Models
{
    public class UserViewModel
    {
        public HomePage HomePage { get; set; }
        public SearchCity SearchCity { get; set; }
        public WeatherResponse WeatherResponse { get; set; }
        public City City { get; set; }
        public Query Query { get; set; }
    }
}
