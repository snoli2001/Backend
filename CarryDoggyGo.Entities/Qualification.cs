﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarryDoggyGo.Entities
{
    public class Qualification
    {
        public int QualificationId { get; set; }
        public int Starts { get; set; }
        public string Recomendations { get; set; }

        public virtual DogWalk DogWalk { get; set; }
        public int DogWalkId { get; set; }
    }
}