using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarryDoggyGo.Models.NotificationDogWalker
{
    public class NotificationDogWalkerModel
    {
        public int NotificationDogWalkerId { get; set; }
        public int DogWalkerId { get; set; }
        public DateTime ShippingDate { get; set; }
        public string Description { get; set; }
        public bool? AcceptDeny { get; set; }
    }
}
