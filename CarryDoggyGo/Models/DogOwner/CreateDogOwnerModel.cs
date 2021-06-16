using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarryDoggyGo.Models.DogOwner
{
    public class CreateDogOwnerModel
    {
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string Name { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 2)]
        public string LastName { get; set; }
        [Required]
        [StringLength(9, MinimumLength = 9)]
        public string Phone { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 6)]
        public string Password { get; set; }
        [Required]
        [StringLength(200, MinimumLength = 6)]
        public string Address { get; set; }

        public int DistrictId { get; set; }
    }
}
