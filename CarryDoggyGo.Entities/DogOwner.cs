using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryDoggyGo.Entities
{
    public  class DogOwner: User
    {
        public int DogOwnerId { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Dog> Dogs { get; set; }

        //public virtual ICollection<DogWalk> DogWalks { get; set; }

        //by gsinuiri
        public int DistrictId { get; set; }
        public virtual District District { get; set; }

        public virtual ICollection<DogOwnerNotification> DogOwnerNotifications { get; set; }
    }
}
