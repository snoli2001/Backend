using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarryDoggyGo.Models.DogOwnerNotification
{
    public class DogOwnerNotificationModel
    {
        public int DogOwnerNotificationId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int DogOwnerId { get; set; }
    }
}
