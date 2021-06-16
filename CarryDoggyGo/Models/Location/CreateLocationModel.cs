using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarryDoggyGo.Models.Location
{
    public class CreateLocationModel
    {
        [Required]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "Su direccion debe tener entre 2 a 500 caracteres")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Se debe incluir la posicion X")]
        public int NumX { get; set; }
        [Required(ErrorMessage = "Se debe incluir la posicion Y")]
        public int NumY { get; set; }
        public int DistrictId { get; set; }
    }
}
