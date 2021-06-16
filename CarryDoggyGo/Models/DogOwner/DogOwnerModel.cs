using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarryDoggyGo.Models.DogOwner
{
    public class DogOwnerModel
    {
        public int DogOnwerId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

        //by gsinuiri
        public int DistrictId { get; set; }

    }
}
