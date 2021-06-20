using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarryDoggyGo.Models.QualificationModel
{
    public class QualificationModel
    {
        public int QualificationId { get; set; }
        public int Starts { get; set; }
        public string Recomendations { get; set; }
        public int DogWalkId { get; set; }
    }
}
