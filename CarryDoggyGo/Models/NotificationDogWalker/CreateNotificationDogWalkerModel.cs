using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarryDoggyGo.Models.NotificationDogWalker
{
    public class CreateNotificationDogWalkerModel
    {
        [Required]
        public int DogWalkerId { get; set; }
        [Required]
        public DateTime ShippingDate { get; set; }
        [Required(ErrorMessage = "Debe ingresar un description")]
        [StringLength(500, MinimumLength = 2, ErrorMessage = "La descripción debe requerir entre 2 y 500 caracteres")]
        public string Description { get; set; }
        //public bool? AcceptDeny { get; set; }
    }
}
