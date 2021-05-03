using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryDoggyGo.Entities
{
    public class CareItem
    {
        public int CareItemId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<DogCareItem> DogCareItems { get; set; }

    }
}
