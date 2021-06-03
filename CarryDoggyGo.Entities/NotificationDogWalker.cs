using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryDoggyGo.Entities
{
    public class NotificationDogWalker
    {
        public int NotificationDogWalkerID { get; set; }
        public int DogWalkerID { get; set; }
        public DateTime ShippingDate { get; set; }
        public string Description { get; set; }
        public bool? AcceptDeny { get; set; }
        public virtual DogWalker DogWalker { get; set; }
    }
}
