using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryDoggyGo.Entities
{
    public class DogWalk
    {   
        public int Id { get; set; }
        public int Hours { get; set; }
        public string AditionalInformation { get; set; }
        public string PaymentAmount { get; set; }
        public int Calification { get; set; }
        public int DogWalkerId { get; set; }
        public virtual DogWalker DogWalker { get; set; }
        public int DogOwnerId { get; set; }

        public virtual DogOwner DogOwner { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
<<<<<<< HEAD
       
          
=======
        public virtual ICollection<DogWalkDog> DogWalkDogs { get; set; }
        public DogWalkState state { get; set; }

        //by gsinuiri
        public int PaymentTypeId { get; set; }
        public virtual PaymentType PaymentType { get; set; }

        public virtual ICollection<Report> Reports { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
>>>>>>> 57af56379dc85de6637959f328a30cf5f42855e5
    }
}
