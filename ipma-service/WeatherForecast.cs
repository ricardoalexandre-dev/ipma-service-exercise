using System;

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

        public DateTime ForecastDate { get; set; } // data da previs�o
        public DateTime DataUpdate { get; set; } // data de atualiza��o do ficheiro(taxa de atualiza��o hor�ria)
        public int GlobalIdLocal { get; set; } // identificador do local(consultar servi�o auxiliar "Lista de identificadores para as capitais distrito e ilhas")
        public int IdWeatherType { get; set; } // c�digo relativo ao tipo de tempo
        public double TempMin { get; set; } // temperatura m�nima di�ria
        public double TempMax { get; set; } // temperatura m�xima di�ria
        public int ClassWindSpeed { get; set; } // classe da intensidade do vento
        public string PredWindDir { get; set; } // rumo predominante do vento (N, NE, E, SE, S, SW, W, NW)
        public double ProbPrecipita { get; set; } // probabilidade da precipita��o
        public int ClassPrecInt { get; set; } // classe da intensidade da precipita��o
        public double Latitude { get; set; } // latitude
        public double Longitude { get; set; } // longitude
    }
}
