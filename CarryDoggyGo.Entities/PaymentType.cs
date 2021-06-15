using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryDoggyGo.Entities
{
    public class PaymentType
    {
        public int PaymentTypeId { get; set; }
        public string  Name { get; set; }

        public virtual ICollection<DogWalk> DogWalks { get; set; }
    }
}
