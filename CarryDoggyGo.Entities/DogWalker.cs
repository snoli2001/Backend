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
        public int Calification { get; set; }
        public virtual ICollection<DogWalk> DogWalks { get; set; }
    }
}
