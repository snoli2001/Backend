using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarryDoggyGo.Entities;

namespace CarryDoggyGo.Models.DogWalk
{
    public class CreateDogWalkModel
    {
        public int Hours { get; set; }
        public string AditionalInformation { get; set; }
        public string PaymentAmount { get; set; }
        public int DogWalkerId { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public List<int> dogsIds { get; set; }

        //public int QualificationId { get; set; }
        public int PaymentTypeId { get; set; }
        public int DistrictId { get; set; }
    }
}
