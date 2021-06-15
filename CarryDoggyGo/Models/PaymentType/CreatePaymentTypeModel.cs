using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarryDoggyGo.Models.PaymentType
{
    public class CreatePaymentTypeModel
    {
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        [StringLength(30, MinimumLength = 2, ErrorMessage = "Su nombre debe tener entre 2 a 30 caracteres")]
        public string Name { get; set; }
    }
}
