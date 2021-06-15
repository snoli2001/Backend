using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryDoggyGo.Entities
{
    public class DogWalkLocation
    {
        public int DogWalkId { get; set; }
        public int LocationId { get; set; }
        public DateTime DateRegister { get; set; }
        public virtual DogWalk DogWalk { get; set; }
        public virtual Location Location { get; set; }
    }
}
