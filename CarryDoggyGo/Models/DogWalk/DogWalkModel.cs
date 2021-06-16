using CarryDoggyGo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarryDoggyGo.Models.DogWalk
{
    public class DogWalkModel
    {
        public int DogWalkId { get; set; }
        public int Hours { get; set; }
        public string AditionalInformation { get; set; }
        public string PaymentAmount { get; set; }
        public Qualification Qualification { get; set; }
        public int DogWalkerId { get; set; }
        //public int DogOwnerId { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
    }
}
