using System.ComponentModel.DataAnnotations;

namespace CarryDoggyGo.Models.DogWalker
{
    public class CreateDogWalkerModel
    {
        [Required(ErrorMessage = "Debe ingresar un nombre")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Su nombre debe tener entre 2 a 50 caracteres")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Debe ingresar un apellido")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Su apellido debe tener entre 2 a 50 caracteres")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Debe ingresar su número de celular")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Su celular debe tener 9 dígitos")]
        public string Phone { get; set; }
        [Required(ErrorMessage = "Debe ingresar un correo")]
        [EmailAddress(ErrorMessage = "Debe ingresar un correo válido")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Debe ingresar una contraseña")]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Su contraseña debe tener entre 6 a 20 caracteres")]
        public string Password { get; set; }
        [StringLength(250, ErrorMessage = "La descripción debe tener un máximo de 250 caracteres")]
        public string Description { get; set; }
        public int PaymentAmount { get; set; }
      
    }
}
