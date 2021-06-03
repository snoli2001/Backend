using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarryDoggyGo.Models.Dog
{
    public class CreateDogModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Su nombre debe tener entre 2 a 50 caracteres")]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Su raza debe tener entre 2 a 50 caracteres")]
        public string Race { get; set; }
        public string Description { get; set; }
        public string Diseases { get; set; }
        public string MedicalInformation { get; set; }
    }
}
