using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryDoggyGo.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public string Text { get; set; }
        public bool? IsImportant { get; set; }
        public DateTime CreatedAt { get; set; }

        public int DogWalkId { get; set; }
        public virtual DogWalk DogWalk { get; set; }
    }
}
