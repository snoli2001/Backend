﻿using System;
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
        public int CityId { get; set; }
        public virtual ICollection<Location> Locations { get; set; }
        public virtual City City { get; set; }
    }
}
