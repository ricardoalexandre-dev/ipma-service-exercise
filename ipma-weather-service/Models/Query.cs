using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipma_weather_service.Models
{
    public class Query
    {
        public City querySingle { get; set; }

        public List<City> queryMultiple { get; set; }
    }
}
