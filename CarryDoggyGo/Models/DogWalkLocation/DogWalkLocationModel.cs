using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarryDoggyGo.Models.DogWalkLocation
{
    public class DogWalkLocationModel
    {
        public int DogWalkId { get; set; }
        public int LocationId { get; set; }
        public DateTime DateRegister { get; set; }
    }
}
