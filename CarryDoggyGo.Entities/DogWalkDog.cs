using System;

namespace CarryDoggyGo.Entities
{
    public class DogWalkDog
    {
        public int DogWalkId { get; set; }
        public virtual DogWalk DogWalk { get; set; }

        public int DogId { get; set; }
        public virtual Dog Dog { get; set; }

    }
}
