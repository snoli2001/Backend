using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarryDoggyGo.Models.DogWalker
{
    public class UpdateDogWalkerModel
    {
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Su nuevo nombre debe tener entre 2 a 50 caracteres")]
        public string Name { get; set; }
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Su nuevo apellido debe tener entre 2 a 50 caracteres")]
        public string LastName { get; set; }
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Su nuevo celular debe tener 9 dígitos")]
        public string Phone { get; set; }
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Su nueva contraseña debe tener entre 6 a 20 caracteres")]
        public string Password { get; set; }
        [StringLength(250, ErrorMessage = "Su nueva descripción debe tener un máximo de 250 caracteres")]
        public string Description { get; set; }
        public int PaymentAmount { get; set; }
    }
}
