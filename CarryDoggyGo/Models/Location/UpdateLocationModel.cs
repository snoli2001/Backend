using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarryDoggyGo.Models.Location
{
    public class UpdateLocationModel
    {
        [StringLength(500, MinimumLength = 2, ErrorMessage = "Su nueva direccion debe tener entre 2 a 500 caracteres")]
        public string Address { get; set; }
        public int NumX { get; set; }
        public int NumY { get; set; }
    }
}
