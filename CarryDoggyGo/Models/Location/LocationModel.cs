using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarryDoggyGo.Models.Location
{
    public class LocationModel
    {
        public int LocationId { get; set; }
        public string Address { get; set; }
        public int NumX { get; set; }
        public int NumY { get; set; }
        public int DistrictId { get; set; }
    }
}
