 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryDoggyGo.Entities
{
    public class Dog
    {
        public int DogId { get; set; }
        public string Name { get; set; }
        public string Race { get; set; }
        public string Description { get; set; }
        public string Diseases { get; set; }

        public int DogOwnerId { get; set; }
        public virtual DogOwner DogOwner { get; set; }

        public string MedicalInformation { get; set; }
        public virtual ICollection<DogCareItem> DogCareItems{get; set;}
        public virtual ICollection<DogWalkDog> DogWalkDogs {get; set;}
    }
} 
