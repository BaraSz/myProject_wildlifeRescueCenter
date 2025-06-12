using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Transactions;

namespace WildlifeRescueCenter
{
    public class Animals
    {
        public string AnimalSpecies { get; set; }
        public string IDofAnimal { get; set; }
        public string Injury { get; set; }
        public bool BackToWild { get; set; }
        public DateTime? VetVisitDate { get; set; }
        public DateTime? ReleaseDate { get; set; }

        public Animals(string animalSpecies, string idOfAnimal, string injury, bool backToWild)
        {
            AnimalSpecies = animalSpecies;
            IDofAnimal = idOfAnimal;
            Injury = injury;
            BackToWild = backToWild;
        }

        public void listOfAnimals()
        {
            Console.WriteLine($"Animal species: {AnimalSpecies}, ID:{IDofAnimal}, injury: {Injury}, Back to wild: {BackToWild}");
        }

        public void infoAboutAnimal()
        {
            Console.WriteLine($"Animal species: {AnimalSpecies}, ID:{IDofAnimal}, injury: {Injury}, Back to wild: {BackToWild}");
        }

        public string IDofAnimalSplit()
        {
            string[] animalIDsplit = IDofAnimal.Split("-", StringSplitOptions.RemoveEmptyEntries);
            string animalPlaceToStay = animalIDsplit[1];
            return animalPlaceToStay;
        }
    }
    
    
}

