using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryDoggyGo.Entities
{
    public class District
    {
        public int DistrictId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
    }
}
