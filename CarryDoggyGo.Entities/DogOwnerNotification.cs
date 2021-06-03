using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//by gsinuiri
namespace CarryDoggyGo.Entities
{
    public class DogOwnerNotification
    {
        public int DogOwnerNotificationId { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public int DogOwnerId { get; set; }
        public virtual DogOwner DogOwner { get; set; }
    }
}
