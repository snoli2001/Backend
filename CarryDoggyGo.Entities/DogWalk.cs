using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryDoggyGo.Entities
{
    public class DogWalk
    {   
        public int DogWalkId { get; set; }
        public int Hours { get; set; }
        public string AditionalInformation { get; set; }
        public string PaymentAmount { get; set; }

        public int DogWalkerId { get; set; }
        public virtual DogWalker DogWalker { get; set; }

        public virtual Qualification Qualification { get; set; }
        public int? QualificationId { get; set; }

        public DateTime Date { get; set; }
        public string Address { get; set; }

        public virtual ICollection<DogWalkDog> DogWalkDogs { get; set; }
        public DogWalkState state { get; set; }

        //by gsinuiri
        public int PaymentTypeId { get; set; }
        public virtual PaymentType PaymentType { get; set; }

        public int DistrictId { get; set; }
        public virtual District District { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Message> Messages { get; set; }

        //by alejandro
        public virtual ICollection<DogWalkLocation> DogWalkLocations { get; set; }
    }
}
