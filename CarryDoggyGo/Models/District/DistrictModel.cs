using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarryDoggyGo.Models.District
{
    public class DistrictModel
    {
        public int DistrictId { get; set; }
        public string Name { get; set; }
        public int CityId { get; set; }
    }
}
