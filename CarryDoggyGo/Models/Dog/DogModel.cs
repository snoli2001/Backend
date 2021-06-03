using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarryDoggyGo.Models.Dog
{
    public class DogModel
    {
        public int DogId { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Description { get; set; }
        public string Diseases { get; set; }
        public int DogOwnerId { get; set; }
        public string MedicalInformation { get; set; }
    }
}
