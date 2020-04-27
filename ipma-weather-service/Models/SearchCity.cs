﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ipma_weather_service.Models
{
    public class SearchCity
    {
        // Annotations required to validate input data in our model.
        [Required(ErrorMessage = "You must enter a city name!")]
        //[StringLength(20, MinimumLength = 2, ErrorMessage = "Enter a city name greater than 2 and lesser than 20 characters!")]
        [Display(Name = "City Global Id Local")]
        public int CityGlobalIdLocal { get; set; }

    }
}
