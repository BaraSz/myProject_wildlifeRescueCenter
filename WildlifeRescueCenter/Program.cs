using System.Runtime.CompilerServices;
using System.Globalization;
using WildlifeRescueCenter;
using Microsoft.VisualBasic;
using System.Linq.Expressions;

namespace WildlifeRescueCenter;

class Program
{
    static void Main(string[] args)
    {
        /*--IE = Indoor enclosures , OE-OutDoor enclosures  Junior - Senior TakeCarer-*/
        Animals Hedgehog = new Animals("Hedgehog", "HO1-IE-J", "bad condition", true);
        Animals Kingfisher = new Animals("Kingfisher", "KO2-IE-S", "broken wing", false);
        Animals Roedeer_K03 = new Animals("Roe deer", "RO3-OE-S", "orphan", true);
        Animals Roedeer_R04 = new Animals("Roe deer", "RO4-OE-S", "orphan", true);
        Animals Fox = new Animals("Fox", "FO5-OE-J", "blind", false);

        List<Animals> currentAnimals = new List<Animals>() { Hedgehog, Kingfisher, Roedeer_K03, Roedeer_R04, Fox };

        /*-IE = Indoor enclosures , OE-OutDoor enclosures  J 0-3 S 3+ -*/
        Employees Albert = new Employees("Albert", "V&05", new DateTime(1984, 10, 20), "Caretaker", new DateTime(2025, 2, 1), 28000);
        Employees Jakub = new Employees("Jakub", "V&02", new DateTime(1984, 10, 20), "Vet", new DateTime(2020, 8, 1), 45000);
        Employees Meda = new Employees("Meda", "T&04", new DateTime(2000, 4, 15), "Caretaker", new DateTime(2021, 6, 1), 28000);
        Employees Lubos = new Employees("Lubos", "T&01", new DateTime(1988, 7, 23), "Caretaker", new DateTime(2015, 10, 1), 28000);
        Employees Monika = new Employees("Monika", "O&03", new DateTime(1995, 11, 4), "Office", new DateTime(2020, 10, 1), 35000);
        Employees Zuzana = new Employees("Zuzana", "T&05", new DateTime(1998, 6, 20), "Caretaker", new DateTime(2024, 6, 1), 28000);

        List<Employees> currentEmployees = new List<Employees>() { Albert, Jakub, Meda, Lubos, Monika, Zuzana };
        List<Employees> takecarerOddWeek = new List<Employees>() { Albert, Meda };
        List<Employees> takecarerEvenWeek = new List<Employees>() { Lubos, Zuzana };

        Enclosures Outdoorenclosures = new Enclosures("Outdoor enclosures", 15);
        Enclosures Indoorenclosures = new Enclosures("Indoor enclosures", 2);

        List<Enclosures> worksites = new List<Enclosures>() { Outdoorenclosures, Indoorenclosures };

        int numberOfAnimal = 0;
        int numberOfAnimalIndoor = 0;
        int numberOfAnimalOutdoor = 0;


        while (true)
        {
            Console.WriteLine("Choose an option:");
            Console.WriteLine("[1]EMPLOYEES");
            Console.WriteLine("[2]ANIMALS");
            Console.WriteLine("[3]ENCLOSURES");
            Console.WriteLine("[4]TODAYINFO");
            Console.WriteLine("[5]END");

            string userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                while (true)
                {
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("[1]ADD new employees");
                    Console.WriteLine("[2]REMOVE employee");
                    Console.WriteLine("[3]Employee Info");
                    Console.WriteLine("[4]LIST of employees");
                    Console.WriteLine("[5]END");

                    string employeesChoice = Console.ReadLine();

                    if (employeesChoice == "1")
                    {
                        Console.WriteLine("Enter a new employee name, ID, date of birth, position, start date and salary in the format: [name]; [ID]; [YYYY-MM-DD]; [position]; [YYYY-MM-DD]; [numeric value].");
                        string newEmployee = Console.ReadLine();
                        string[] newEmployeeSplit = newEmployee.Split(";", StringSplitOptions.RemoveEmptyEntries);

                        while (true)
                        {
                            if (newEmployeeSplit.Length == 6)
                            {
                                try
                                {
                                    string name = newEmployeeSplit[0];
                                    string id = newEmployeeSplit[1];
                                    DateTime dateOfBirth = DateTime.ParseExact(newEmployeeSplit[2], "yyyy-MM-dd",
                                    CultureInfo.InvariantCulture);
                                    string position = newEmployeeSplit[3];
                                    DateTime startDay = DateTime.ParseExact(newEmployeeSplit[4], "yyyy-MM-dd", CultureInfo.InvariantCulture);
                                    double salary = double.Parse(newEmployeeSplit[5]);

                                    Employees addEmployee = new Employees(name, id, dateOfBirth, position, startDay, salary);
                                    currentEmployees.Add(addEmployee);
                                    Console.WriteLine($"A new employee {addEmployee.Name} with ID:{addEmployee.ID} has been added to the list.");
                                    break;
                                }
                                catch
                                {
                                    Console.WriteLine("Invalid format for date of Birth, start day or salary. Please enter date of Birth and start day in the format YYYY-MM-DD and salary as a numeric value.");
                                    newEmployee = Console.ReadLine();
                                    newEmployeeSplit = newEmployee.Split(";", StringSplitOptions.RemoveEmptyEntries);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid enter");
                                Console.WriteLine("Enter a new employee name, date of birth, position, start date and salary in the format: [name]; [YYYY-MM-DD]; [position]; [YYYY-MM-DD]; [numeric value].");
                                newEmployee = Console.ReadLine();
                                newEmployeeSplit = newEmployee.Split(";", StringSplitOptions.RemoveEmptyEntries);
                            }
                        }
                    }

                    else if (employeesChoice == "2")
                    {
                        Console.WriteLine("Which employee do you want to remove from the list? Please enter the employee's ID:");
                        string employeeRemove = Console.ReadLine();

                        var employeeToRemove = currentEmployees.FirstOrDefault(e => e.ID == employeeRemove);

                        if (employeeToRemove != null)
                        {
                            currentEmployees.Remove(employeeToRemove);
                            Console.WriteLine($"Employee with ID {employeeRemove} has been removed.");
                        }
                        else
                        {
                            Console.WriteLine($"Employee with ID {employeeRemove} was not found.");
                        }
                    }

                    else if (employeesChoice == "3")
                    {
                        Console.WriteLine("Which employee do you want to check? Please enter the employee's ID:");
                        string employeeCheck = Console.ReadLine();

                        var employeeToCheck = currentEmployees.FirstOrDefault(e => e.ID == employeeCheck);
                        if (employeeToCheck != null)
                        {
                            employeeToCheck.SalaryRaise(employeeToCheck.StartDate);
                            employeeToCheck.EmployeeInfo();
                            Console.WriteLine();
                        }
                        else
                        {
                            Console.WriteLine($"Employee with ID {employeeToCheck.ID} was not found.");
                            Console.WriteLine();
                        }
                    }
                    else if (employeesChoice == "4")
                    {
                        foreach (var employee in currentEmployees.OrderBy(e => e.Name))
                        {
                            employee.ListOfEmployees();
                        }
                    }

                    else if (employeesChoice == "5")
                    {
                        Console.WriteLine("The program is closing.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Enter a number from 1 to 5");
                    }
                }
            }

            else if (userChoice == "2")
            {
                while (true)
                {
                    Console.WriteLine("Choose an option:");
                    Console.WriteLine("[1]ADD new animal");
                    Console.WriteLine("[2]REMOVE animal");
                    Console.WriteLine("[3]LIST of animals");
                    Console.WriteLine("[4]ANIMAL Info");
                    Console.WriteLine("[5]END");

                    string animalsChoice = Console.ReadLine();

                    if (animalsChoice == "1")
                    {
                        Console.WriteLine("Enter a new animal the format: [AnimalSpecies]; [IDofAnimal]; [Injury]; [true/false]");
                        string newAnimal = Console.ReadLine();
                        string[] newAnimalSplit = newAnimal.Split(";", StringSplitOptions.RemoveEmptyEntries);

                        while (true)
                        {
                            if (newAnimalSplit.Length == 4)
                            {
                                try
                                {
                                    string animalSpecies = newAnimalSplit[0];
                                    string idOfAnimal = newAnimalSplit[1];
                                    string injury = newAnimalSplit[2];
                                    string backToWildText = newAnimalSplit[3];
                                    bool backToWild = bool.Parse(backToWildText);

                                    Animals addAnimal = new Animals(animalSpecies, idOfAnimal, injury, backToWild);

                                    foreach (var a in currentAnimals)
                                    {
                                        if (a.IDofAnimalSplitEnclosure() == "IE")
                                        {
                                            numberOfAnimalIndoor++;
                                        }
                                        else if (a.IDofAnimalSplitEnclosure() == "OE")
                                        {
                                            numberOfAnimalOutdoor++;
                                        }
                                    }

                                    if (addAnimal.IDofAnimalSplitEnclosure() == "IE" && numberOfAnimalIndoor >= Indoorenclosures.Capacity)
                                    {
                                        Console.WriteLine($"The capacity of Indoor enclosure is {numberOfAnimalIndoor}/{Indoorenclosures.Capacity}  full. The animal {addAnimal.AnimalSpecies} with ID: {addAnimal.IDofAnimal} is not posible to add");
                                        break;
                                    }
                                    else if (addAnimal.IDofAnimalSplitEnclosure() == "OE" && numberOfAnimalOutdoor >= Outdoorenclosures.Capacity)
                                    {
                                        Console.WriteLine($"The capacity of Outdoor enclosure is {numberOfAnimalOutdoor}/{Outdoorenclosures.Capacity}  full. The animal {addAnimal.AnimalSpecies} with ID: {addAnimal.IDofAnimal} is not posible to add");
                                        break;
                                    }
                                    else if (addAnimal.IDofAnimalSplitEnclosure() != "IE" && addAnimal.IDofAnimalSplitEnclosure() != "OE")
                                    {
                                        Console.WriteLine("Enter the ID of animal in the format [Capital letter of animal species - IE/OE - J/S]");
                                        newAnimal = Console.ReadLine();
                                        newAnimalSplit = newAnimal.Split(";", StringSplitOptions.RemoveEmptyEntries);
                                    }
                                    else
                                    {
                                        currentAnimals.Add(addAnimal);
                                        Console.WriteLine($"The {addAnimal.AnimalSpecies} with ID {addAnimal.IDofAnimal} was added.");
                                        break;
                                    }
                                    Console.WriteLine();
                                }
                                catch
                                {
                                    Console.WriteLine("Please write -backToWild- in the format [true/false]");
                                    newAnimal = Console.ReadLine();
                                    newAnimalSplit = newAnimal.Split(";", StringSplitOptions.RemoveEmptyEntries);
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid enter");
                                Console.WriteLine("Enter a new animal the format: [AnimalSpecies]; [IDofAnimal]; [Injury]; [true/false]");
                                newAnimal = Console.ReadLine();
                                newAnimalSplit = newAnimal.Split(";", StringSplitOptions.RemoveEmptyEntries);
                            }
                        }
                    }

                    else if (animalsChoice == "2")
                    {
                        Console.WriteLine("Which animal do you want to remove from the list? Please enter the animal's ID:");
                        string animalRemove = Console.ReadLine();

                        var animalToRemove = currentAnimals.FirstOrDefault(a => a.IDofAnimal == animalRemove);

                        if (animalToRemove != null)
                        {
                            currentAnimals.Remove(animalToRemove);
                            Console.WriteLine($"Animal with ID {animalToRemove.IDofAnimal} has been removed.");
                        }
                        else
                        {
                            Console.WriteLine($"Animal with ID: {animalRemove} was not found.");
                        }
                        Console.WriteLine();
                    }

                    else if (animalsChoice == "3")
                    {
                        foreach (var animal in currentAnimals.OrderBy(a => a.AnimalSpecies))
                        {
                            animal.ListOfAnimals();
                        }
                        Console.WriteLine();
                    }

                    else if (animalsChoice == "4")
                    {
                        Console.WriteLine("Which animal do you want to check? Please enter an ID");
                        string animalCheckText = Console.ReadLine();

                        var animalToCheck = currentAnimals.FirstOrDefault(a => a.IDofAnimal == animalCheckText);

                        if (animalToCheck != null)
                        {
                            Console.WriteLine($"Animal species: {animalToCheck.AnimalSpecies}, ID:{animalToCheck.IDofAnimal}, injury: {animalToCheck.Injury}, Back to wild: {animalToCheck.BackToWild}");

                            Console.WriteLine("IMPORTANT DATE:");
                            if (animalToCheck.VetVisitDate != null && animalToCheck.ReleaseDate != null)
                            {
                                Console.WriteLine($"NEXT vet visit: {animalToCheck.VetVisitDate?.ToString("yyyy-MM-dd")}");
                                Console.WriteLine($"BACK to the wild {animalToCheck.ReleaseDate?.ToString("yyyy-MM-dd")}");
                            }
                            else if (animalToCheck.VetVisitDate == null && animalToCheck.ReleaseDate != null)
                            {
                                Console.WriteLine($"NEXT vet visit: {animalToCheck.VetVisitDate?.ToString("yyyy-MM-dd")} Not set");
                                Console.WriteLine($"BACK to the wild {animalToCheck.ReleaseDate?.ToString("yyyy-MM-dd")}");
                            }
                            else if (animalToCheck.VetVisitDate != null && animalToCheck.ReleaseDate == null)
                            {
                                Console.WriteLine($"NEXT vet visit: {animalToCheck.VetVisitDate?.ToString("yyyy-MM-dd")}");
                                Console.WriteLine($"BACK to the wild {animalToCheck.ReleaseDate?.ToString("yyyy-MM-dd")} Not set");
                            }
                            else
                            {
                                Console.WriteLine("No important dates have been set");
                            }
                            Console.WriteLine();
                            while (true)
                            {
                                Console.WriteLine("[1]ADD a date for a vet visit");
                                Console.WriteLine("[2] Add a date for the animal’s return to the wild");
                                Console.WriteLine("[3] RETURN to the MAIN MENU");

                                string animalToCheckChoice = Console.ReadLine();

                                if (animalToCheckChoice == "1")
                                {

                                    if (animalToCheck.VetVisitDate == null)
                                    {
                                        Console.WriteLine("Enter next vet visit date in the format [YYYY-MM-DD]");

                                        string newVetVisitDateText = Console.ReadLine();

                                        DateTime newVetVisitDate;
                                        bool isValidDate = DateTime.TryParseExact(newVetVisitDateText, "yyyy-MM-dd",
                                                CultureInfo.InvariantCulture, DateTimeStyles.None, out newVetVisitDate);

                                        if (isValidDate)
                                        {
                                            animalToCheck.VetVisitDate = newVetVisitDate;
                                            Console.WriteLine($"{animalToCheck.VetVisitDate?.ToString("yyyy-MM-dd")}: The next vet visit has been successfully added.");
                                            Console.WriteLine();
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine($"Enter a date in the format [YYYY-MM-DD]");
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("The date has already been set");
                                        break;
                                    }
                                }


                                else if (animalToCheckChoice == "2")
                                {
                                    if (animalToCheck.BackToWild == true)
                                    {
                                        if (animalToCheck.ReleaseDate == null)
                                        {
                                            Console.WriteLine("Enter the date of returning to the wild in the format [YYYY-MM-DD]");
                                            string backToWildText = Console.ReadLine();
                                            DateTime backToWildDate;
                                            bool isValidDate = DateTime.TryParseExact(backToWildText, "yyyy-MM-dd",
                                            CultureInfo.InvariantCulture, DateTimeStyles.None, out backToWildDate);


                                            if (isValidDate)
                                            {
                                                animalToCheck.ReleaseDate = backToWildDate;
                                                Console.WriteLine($"{animalToCheck.ReleaseDate?.ToString("yyyy-MM-dd")}: back to the wild.");
                                                Console.WriteLine();
                                                break;
                                            }
                                            else
                                            {
                                                Console.WriteLine($"Enter a date in the format [YYYY-MM-DD]");
                                            }
                                        }

                                        else
                                        {
                                            Console.WriteLine("The date has already been set");
                                            break;
                                        }
                                    }

                                    else
                                    {
                                        Console.WriteLine($"Animal species: {animalToCheck.AnimalSpecies}, ID:{animalToCheck.IDofAnimal}, injury: {animalToCheck.Injury}, Back to wild: {animalToCheck.BackToWild}, Stays in WLRC");
                                        Console.WriteLine();
                                    }
                                }

                                else if (animalToCheckChoice == "3")
                                {
                                    Console.WriteLine("Returning to MAIN menu");
                                    break;
                                }

                                else
                                {
                                    Console.WriteLine("Enter a number from 1 to 3");
                                }
                            }
                        }


                        else
                        {
                            Console.WriteLine($"Animal with ID: {animalCheckText} was not found.");
                            break;
                        }
                        Console.WriteLine();
                    }

                    else if (animalsChoice == "5")
                    {
                        Console.WriteLine("The program is closing.");
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number from 1 to 5");
                    }
                    Console.WriteLine();
                }
            }

            else if (userChoice == "3")
            {
                Console.WriteLine("INDOOR ENCLOSURES: ");
                Console.WriteLine($"The enclosure is {CapacityOfIndoorEnclosure(numberOfAnimal, currentAnimals)}/{Indoorenclosures.Capacity} full");
                Console.WriteLine();
                var animalIndoorEnclosureJunior = currentAnimals
                                            .Where(a => a.IDofAnimalSplitEnclosure() == "IE" && a.IDofAnimalSplitCareTaker() == "J");
                var animalIndoorEnclosureSenior = currentAnimals
                                            .Where(a => a.IDofAnimalSplitEnclosure() == "IE" && a.IDofAnimalSplitCareTaker() == "S");

                foreach (var e in takecarerEvenWeek)
                {
                    if (e.CareTakerLevel() < 3)
                    {
                        Console.WriteLine($"Junior caretaker {e.Name} takes care of: ");

                        if (animalIndoorEnclosureJunior != null && animalIndoorEnclosureJunior.Any())
                        {
                            foreach (var a in animalIndoorEnclosureJunior)
                            {
                                Console.WriteLine($"{a.AnimalSpecies}, ID {a.IDofAnimal}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{e.Name} has no animal to take care of.");
                        }
                        Console.WriteLine();
                    }
                    else if (e.CareTakerLevel() >= 3)
                    {
                        Console.WriteLine($"Senior caretaker {e.Name} takes care of: ");

                        if (animalIndoorEnclosureSenior != null && animalIndoorEnclosureSenior.Any())
                        {
                            foreach (var a in animalIndoorEnclosureSenior)
                            {
                                Console.WriteLine($"{a.AnimalSpecies}, ID {a.IDofAnimal}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{e.Name} has no animal to take care of.");
                        }
                    }
                    Console.WriteLine();
                }

                Console.WriteLine("OUTDOOR ENCLOSURES: ");
                Console.WriteLine($"The enclosure is {CapacityOfOutdoorEnclosure(numberOfAnimal, currentAnimals)}/{Outdoorenclosures.Capacity} full");
                Console.WriteLine();
                var animalOutdoorEnclosureJunior = currentAnimals
                                            .Where(a => a.IDofAnimalSplitEnclosure() == "OE" && a.IDofAnimalSplitCareTaker() == "J");
                var animalOutdoorEnclosureSenior = currentAnimals
                                            .Where(a => a.IDofAnimalSplitEnclosure() == "OE" && a.IDofAnimalSplitCareTaker() == "S");

                foreach (var e in takecarerOddWeek)
                {
                    if (e.CareTakerLevel() < 3)
                    {
                        Console.WriteLine($"Junior caretaker {e.Name} takes care of: ");
                        if (animalOutdoorEnclosureJunior != null && animalOutdoorEnclosureJunior.Any())
                        {
                            foreach (var a in animalOutdoorEnclosureJunior)
                            {
                                Console.WriteLine($"{a.AnimalSpecies}, ID {a.IDofAnimal}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{e.Name} has no animal to take care of.");
                        }
                        Console.WriteLine();
                    }
                    else if (e.CareTakerLevel() >= 3)
                    {
                        Console.WriteLine($"Senior caretaker {e.Name} takes care of: ");
                        if (animalOutdoorEnclosureSenior != null && animalOutdoorEnclosureSenior.Any())
                        {
                            foreach (var a in animalOutdoorEnclosureSenior)
                            {
                                Console.WriteLine($"{a.AnimalSpecies}, ID {a.IDofAnimal}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"{e.Name} has no animal to take care of.");
                        }
                        Console.WriteLine();
                    }
                }
            }

            else if (userChoice == "4")
            {

                bool somethingPrinted = false;

                foreach (var e in currentEmployees)
                {
                    if (e.DateOfBirth == DateTime.Today)
                    {
                        Console.WriteLine($"({e.Name} has a birthday today!");
                        somethingPrinted = true;
                    }
                }

                foreach (var a in currentAnimals)
                {
                    if (a.ReleaseDate == DateTime.Today)
                    {
                        Console.WriteLine($"({a.AnimalSpecies} with ID: {a.IDofAnimal} is being returned to the wild today!");
                        somethingPrinted = true;
                    }

                    else if (a.VetVisitDate == DateTime.Today)
                    {
                        Console.WriteLine($"{a.AnimalSpecies} with ID: {a.IDofAnimal} has a vet visit appointment today!");
                        somethingPrinted = true;
                    }
                }

                if (DateTime.Today.DayOfWeek == DayOfWeek.Tuesday)
                {
                    Console.WriteLine("Today is an open day for the public from 2 PM.");
                    somethingPrinted = true;
                }

                if (!somethingPrinted)
                {
                    Console.WriteLine("There is nothing planned for today.");
                }
            }

            else if (userChoice == "5")
            {
                Console.WriteLine("The program is closing");
                return;
            }

            else
            {
                Console.WriteLine("Please enter a number from 1 to 5");
            }
        }
    }



    public static int CapacityOfIndoorEnclosure(int numberOfAnimal, List<Animals> animals)
    {
        foreach (var a in animals)
        {
            if (a.IDofAnimalSplitEnclosure() == "IE")
            {
                Console.WriteLine($"{a.AnimalSpecies}, ID: {a.IDofAnimal}");
                numberOfAnimal++;
            }
        }
        Console.WriteLine();
        return numberOfAnimal;
    }

    public static int CapacityOfOutdoorEnclosure(int numberOfAnimal, List<Animals> animals)
    {
        foreach (var a in animals)
        {
            if (a.IDofAnimalSplitEnclosure() == "OE")
            {
                Console.WriteLine($"{a.AnimalSpecies}, ID: {a.IDofAnimal}");
                numberOfAnimal++;
            }
        }
        Console.WriteLine();
        return numberOfAnimal;
    }

}




