using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ipma_service
{
    public class Data
    {
        public DateTime ForecastDate { get; set; } // data da previsão
        public DateTime DataUpdate { get; set; } // data de atualização do ficheiro(taxa de atualização horária)
        public int GlobalIdLocal { get; set; } // identificador do local(consultar serviço auxiliar "Lista de identificadores para as capitais distrito e ilhas")
        public int IdWeatherType { get; set; } // código relativo ao tipo de tempo
        public double TMin { get; set; } // temperatura mínima diária
        public double TMax { get; set; } // temperatura máxima diária
        public int ClassWindSpeed { get; set; } // classe da intensidade do vento
        public string PredWindDir { get; set; } // rumo predominante do vento (N, NE, E, SE, S, SW, W, NW)
        public double PrecipitaProb { get; set; } // probabilidade da precipitação
        public int ClassPrecInt { get; set; } // classe da intensidade da precipitação
        public double Latitude { get; set; } // latitude
        public double Longitude { get; set; } // longitude
    }
}
