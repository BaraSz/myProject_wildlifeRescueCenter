using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WildlifeRescueCenter
{
    public class Enclosures
    {
        public string PlaceForAnimal { get; set; }
        public int Capacity { get; set; }

        public Enclosures(string placeForAnimal, int capacity)
        {
            PlaceForAnimal = placeForAnimal;
            Capacity = capacity;
        }
    }
}