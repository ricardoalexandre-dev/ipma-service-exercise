using System;
using System.Collections.Generic;

namespace ipma_service
{
    public class WeatherForecast
    {
        /*
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string Summary { get; set; }
        */

        public List<Data> Data { get; set; }

        public string Owner { get; set; }

        public string Country { get; set; }
    }
}
