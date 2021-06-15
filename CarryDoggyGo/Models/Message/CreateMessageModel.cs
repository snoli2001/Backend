using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarryDoggyGo.Models.Message
{
    public class CreateMessageModel
    {
        public string Text { get; set; }
        public bool? IsImportant { get; set; }
    }
}
