using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarryDoggyGo.Models.City
{
    public class CreateCityModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Su nombre debe tener entre 2 a 50 caracteres")]
        public string Name { get; set; }
    }
}
