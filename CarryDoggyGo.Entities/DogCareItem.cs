using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryDoggyGo.Entities
{
    public class DogCareItem
    {
        public int DogId { get; set; }
        public virtual Dog Dog{ get; set; }

        public int CareItemId{ get; set; }
        public virtual CareItem CareItem{ get; set; }
    }
}
