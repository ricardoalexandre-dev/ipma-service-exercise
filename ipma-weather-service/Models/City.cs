using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ipma_weather_service.Models
{
    public class City
    {
        [Display(Name = "ForecastDate:")]
        public DateTime ForecastDate { get; set; }
        
        [Display(Name = "DataUpdate:")]
        public DateTime DataUpdate { get; set; } 
        
        [Display(Name = "GlobalIdLocal:")]
        public int GlobalIdLocal { get; set; } 

        [Display(Name = "IdWeatherType:")]
        public int IdWeatherType { get; set; } 

        [Display(Name = "TempMin:")]
        public double TMin { get; set; } 

        [Display(Name = "TempMax:")]
        public double TMax { get; set; } 

        [Display(Name = "ClassWindSpeed:")]
        public int ClassWindSpeed { get; set; } 

        [Display(Name = "PredWindDir:")]
        public string PredWindDir { get; set; } 

        [Display(Name = "ProbPrecipita:")]
        public double ProbPrecipita { get; set; } 
        
        [Display(Name = "ClassPrecInt:")]
        public int ClassPrecInt { get; set; } 
        
        [Display(Name = "Latitude:")]
        public double Latitude { get; set; } 
        
        [Display(Name = "Longitude:")]
        public double Longitude { get; set; } 
    }
}
