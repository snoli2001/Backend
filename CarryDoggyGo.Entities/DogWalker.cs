using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryDoggyGo.Entities
{
    public class DogWalker : User
    {
        public int DogWalkerId { get; set; }
        public string Description { get; set; }
        public int PaymentAmount { get; set; }
        public int Qualification { get; set; }
        public virtual ICollection<DogWalk> DogWalks { get; set; }
        public virtual ICollection<NotificationDogWalker> NotificationDogWalkers { get; set; }

        //by gsinuiri
        public virtual ICollection<DogWalkerDistrict> DogWalkerDistricts { get; set; }
    }
}
