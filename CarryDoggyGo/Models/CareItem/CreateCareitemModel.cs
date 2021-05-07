using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;


namespace CarryDoggyGo.Models.CaresItem
{
    public class CreateCareitemModel
    {
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Su nombre debe tener entre 2 a 50 caracteres")]
        public string Name { get; set; }
        public string Description { get; set; }



    }
}
