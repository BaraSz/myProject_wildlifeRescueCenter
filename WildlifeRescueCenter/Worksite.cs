using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WildlifeRescueCenter
{
    public class Worksite
    {
        public string PlaceForAnimal { get; set; }
        public int Capacity { get; set; }

        public Worksite(string placeForAnimal, int capacity)
        {
            PlaceForAnimal = placeForAnimal;
            Capacity = capacity;
        }

        public void infoWorksite()
        {
            
        }
    }
}