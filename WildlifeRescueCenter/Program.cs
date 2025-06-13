using System.Runtime.CompilerServices;
using System.Globalization;
using WildlifeRescueCenter;

namespace WildlifeRescueCenter;

class Program
{
    static void Main(string[] args)
    {
        /*--IE = Indoor enclosures , OE-OutDoor enclosures  Junior - Senior TakeCarer-*/
        Animals Hedgehog = new Animals("Hedgehog", "HO1-IE-JS", "bad condition", true);
        Animals Kingfisher = new Animals("Kingfisher", "KO2-IE-S", "broken wing", false);
        Animals Roedeer_K03 = new Animals("Roe deer", "RO3-OE-S", "orphan", true);
        Animals Roedeer_R04 = new Animals("Roe deer", "RO4-OE-S", "orphan", true);
        Animals Fox = new Animals("Fox", "FO5-OE", "blind-JS", false);

        List<Animals> currentAnimals = new List<Animals>() { Hedgehog, Kingfisher, Roedeer_K03, Roedeer_R04, Fox };

        /*-IE = Indoor enclosures , OE-OutDoor enclosures  J 0-1 S 3+ -*/
        Employees Albert = new Employees("Albert", "V&05", DateTime.Parse("22.08.1991"), "TakeCarer", DateTime.Parse("01.02.2025"), 28000);
        Employees Jakub = new Employees("Jakub", "V&02", DateTime.Parse("20.10.1984"), "Vet", DateTime.Parse("01.08.2020"), 45000);
        Employees Meda = new Employees("Meda", "T&04", DateTime.Parse("15.04.2000"), "TakeCarer", DateTime.Parse("01.06.2022"), 28000);
        Employees Lubos = new Employees("Lubos", "T&01", DateTime.Parse("23.07.1988"), "TakeCarer", DateTime.Parse("01.10.2015"), 28000);
        Employees Monika = new Employees("Monika", "O&03", DateTime.Parse("04.11.1995"), "Office", DateTime.Parse("01.10.2020"), 35000);
        Employees Zuzana = new Employees("Zuzana", "T&05", DateTime.Parse("20.06.1998"), "TakeCarer", DateTime.Parse("01.06.2017"), 28000);

        List<Employees> currentEmployees = new List<Employees>() { Albert, Jakub, Meda, Lubos, Monika, Zuzana };

        Worksite Outdoorenclosures = new Worksite("Outdoor enclosures", 15);
        Worksite Indoorenclosures = new Worksite("Indoor enclosures", 5);
        Worksite OutDoor = new Worksite("Outdoor", 0);

        List<Worksite> worksites = new List<Worksite>() { Outdoorenclosures, Indoorenclosures, OutDoor };

        while (true)
        {

            Console.WriteLine("Choose an option:");
            Console.WriteLine("[1]EMPLOYEES");
            Console.WriteLine("[2]ANIMALS");
            Console.WriteLine("[3]WORKSITE");
            Console.WriteLine("[4]TODAYINFO");
            Console.WriteLine("[5]END");

            string userChoice = Console.ReadLine();

            if (userChoice == "1")
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("[1]ADD new employees");
                Console.WriteLine("[2]REMOVE employee");
                Console.WriteLine("[3]INFO about employee");
                Console.WriteLine("[4]LIST of employees");
                Console.WriteLine("[5]END");

                string employeesChoice = Console.ReadLine();

                if (employeesChoice == "1")
                {
                    Console.WriteLine("Enter a new employee name, ID, date of birth, position, start date and salary in the format: [name]; [ID]; [YYYY-MM-DD]; [position]; [YYYY-MM-DD]; [salary].");
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

                                Employees addEmployees = new Employees(name, id, dateOfBirth, position, startDay, salary);
                                currentEmployees.Add(addEmployees);
                                break;
                            }
                            catch
                            {
                                Console.WriteLine("Invalid format of date of Birth, start day or salary. Please write the date of Birth and start day in the format YYYY-MM-DD and salary as a numeric value.");
                                newEmployee = Console.ReadLine();
                                newEmployeeSplit = newEmployee.Split(";", StringSplitOptions.RemoveEmptyEntries);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid enter");
                            Console.WriteLine("Enter a new employee name, author, date of birth, position, start date and salary in the format: [name]; [YYYY-MM-DD]; [position]; [YYYY-MM-DD]; [salary].");
                            newEmployee = Console.ReadLine();
                            newEmployeeSplit = newEmployee.Split(";", StringSplitOptions.RemoveEmptyEntries);
                        }
                    }
                }

                else if (employeesChoice == "2")
                {
                    Console.WriteLine("What employee do you want to remove from the list? Please enter a ID");
                    string employeeRemove = Console.ReadLine();

                    var employeeToRemove = currentEmployees.FirstOrDefault(e => e.ID == employeeRemove);

                    if (employeeToRemove != null)
                    {
                        currentEmployees.Remove(employeeToRemove);
                        Console.WriteLine($"Employee with ID '{employeeRemove}' has been removed.");
                    }
                    else
                    {
                        Console.WriteLine($"Employee with ID '{employeeRemove}' was not found.");
                    }
                }

                else if (employeesChoice == "3")
                {
                    Console.WriteLine("Which employee do you want to check? Please enter a ID");
                    string employeeCheck = Console.ReadLine();

                    var employeeToCheck = currentEmployees.FirstOrDefault(e => e.ID == employeeCheck);
                    if (employeeToCheck != null)
                    {
                        employeeToCheck.SalaryRaise(employeeToCheck.StartDate);

                        employeeToCheck.EmployeeInfo();
                    }
                    else
                    {
                        Console.WriteLine($"Employee with ID '{employeeToCheck}' was not found.");
                    }
                }
                else if (employeesChoice == "4")
                {
                    foreach (var employee in currentEmployees)
                    {
                        employee.listOfEmployees();
                    }
                }

                else if (employeesChoice == "5")
                {
                    Console.WriteLine("The program is closing.");
                    return;
                }
            }

            else if (userChoice == "2")
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("[1]ADD new animal");
                Console.WriteLine("[2]REMOVE animal");
                Console.WriteLine("[3]LIST of animals");
                Console.WriteLine("[4]INFO about animal");
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
                                bool backToWild;
                                bool backToWildConvert = bool.TryParse(backToWildText, out backToWild);

                                Animals addAnimal = new Animals(animalSpecies, idOfAnimal, injury, backToWild);
                                currentAnimals.Add(addAnimal);
                                break;
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
                    Console.WriteLine("What animal do you want to remove from the list? Please enter a ID of the animal");
                    string animalRemove = Console.ReadLine();

                    var animalToRemove = currentAnimals.FirstOrDefault(a => a.IDofAnimal == animalRemove);

                    if (animalToRemove != null)
                    {
                        currentAnimals.Remove(animalToRemove);
                        Console.WriteLine($"Animal with ID '{animalToRemove}' has been removed.");
                    }
                    else
                    {
                        Console.WriteLine($"Animal with ID '{animalToRemove}' was not found.");
                    }
                }

                else if (animalsChoice == "3")
                {
                    foreach (var animal in currentAnimals)
                    {
                        animal.listOfAnimals();
                    }
                }

                else if (animalsChoice == "4")
                {
                    Console.WriteLine("Which animal do you want to check? Please enter a ID");
                    string animalCheck = Console.ReadLine();

                    var animalToCheck = currentAnimals.FirstOrDefault(a => a.IDofAnimal == animalCheck);
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
                            Console.WriteLine("No important date set");
                        }


                        Console.WriteLine("[1]ADD a term of a vet visit");
                        Console.WriteLine("[2] ADD a term of returning to the wild");
                        Console.WriteLine("[3]END");

                        string animalToCheckChoice = Console.ReadLine();

                        if (animalToCheckChoice == "1")
                        {
                            Console.WriteLine("Enter a date of the next vet visit in the format [YYYY-MM-DD]");
                            string newVetVisitDateText = Console.ReadLine();

                            DateTime newVetVisitDate = DateTime.ParseExact(newVetVisitDateText, "yyyy-MM-dd",
                                    CultureInfo.InvariantCulture);
                            animalToCheck.VetVisitDate = newVetVisitDate;

                            Console.WriteLine($"Date: {animalToCheck.VetVisitDate?.ToString("yyyy-MM-dd")} of a next visit has been successfully added.");
                        }

                        if (animalToCheckChoice == "2")
                        {
                            if (animalToCheck.BackToWild == true)
                            {
                                Console.WriteLine("Enter date of returning to the wild in the format [YYYY-MM-DD]");
                                string BackToWildText = Console.ReadLine();
                                DateTime BackToWildDate = DateTime.ParseExact(BackToWildText, "yyyy-MM-dd",
                                CultureInfo.InvariantCulture);
                                animalToCheck.ReleaseDate = BackToWildDate;

                                Console.WriteLine($"Date: {animalToCheck.ReleaseDate?.ToString("yyyy-MM-dd")} of a next visit has been successfully added.");
                            }

                            else if (animalToCheck.BackToWild == false)
                            {
                                Console.WriteLine($"Animal species: {animalToCheck.AnimalSpecies}, ID:{animalToCheck.IDofAnimal}, injury: {animalToCheck.Injury}, Back to wild: {animalToCheck.BackToWild}, Stays in WLRC");
                            }
                        }

                    }
                }
                else if (animalsChoice == "5")
                {
                    Console.WriteLine("The program is closing.");
                    return;
                }
            }


            else if (userChoice == "3")
            {
                Console.WriteLine("Animals in the indoor enclosures are:");
                foreach (var a in currentAnimals)
                {
                    if (a.IDofAnimalSplit() == "IE")
                    {
                        Console.WriteLine($"{a.AnimalSpecies}, ID: {a.IDofAnimal}");
                    }
                }
                Console.WriteLine();
                Console.WriteLine("Animals in the outdoor enclosures are:");
                foreach (var a in currentAnimals)
                {
                    if (a.IDofAnimalSplit() == "OE")
                    {
                        Console.WriteLine($"{a.AnimalSpecies}, ID: {a.IDofAnimal}");
                    }
                }

            }


            else if (userChoice == "4")
            {
                foreach (var e in currentEmployees)
                {
                    if (e.DateOfBirth == DateTime.Today)
                    {
                        Console.WriteLine($"({e.Name} has Birthday today!");
                    }
                }

                foreach (var a in currentAnimals)
                {
                    if (a.ReleaseDate == DateTime.Today)
                    {
                        Console.WriteLine($"({a.AnimalSpecies} with ID: {a.IDofAnimal} is getting return to the wild today!");
                    }
                }

                foreach (var a in currentAnimals)
                {
                    if (a.VetVisitDate == DateTime.Today)
                    {
                        Console.WriteLine($"{a.AnimalSpecies} with ID: {a.IDofAnimal} has a vet visit today!");
                    }
                }

                if (DateTime.Today.DayOfWeek == DayOfWeek.Tuesday)
                {
                    Console.WriteLine("Today is open day for the public from 14:00");
                }
            }
        }
    }
}




