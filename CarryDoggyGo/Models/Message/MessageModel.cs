using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarryDoggyGo.Models.Message
{
    public class MessageModel
    {
        public int MessageId { get; set; }
        public string Text { get; set; }
        public bool? IsImportant { get; set; }
        public DateTime CreatedAt { get; set; }
        public int DogWalkId { get; set; }
    }
}
