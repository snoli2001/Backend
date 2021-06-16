using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryDoggyGo.Entities
{
    public class Location
    {
        public int LocationId { get; set; }
        public string Address { get; set; }
        public int NumX { get; set; }
        public int NumY { get; set; }

        //public int DistrictId { get; set; }
        //public virtual District District { get; set; }
        public virtual ICollection<DogWalkLocation> DogWalkLocations { get; set; }
    }
}
