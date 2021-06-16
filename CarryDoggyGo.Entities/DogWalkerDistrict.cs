using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryDoggyGo.Entities
{
    public class DogWalkerDistrict
    {

        public int DogWalkerkId { get; set; }
        public DogWalker DogWalker { get; set; }

        public int DistrictId { get; set; }
        public District District { get; set; }
    }
}
