using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace WildlifeRescueCenter
{
    public class Employees
    {
        //jmeno, datum narozeni, pozice, delka trvani pracovniho pomeru, plat (zvyseni podle odpravanych let)
        public string Name { get; set; }

        public string ID { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Position { get; set; }
        public DateTime StartDate { get; set; }
        public double Salary { get; set; }

        public Employees(string name, string id, DateTime dateOfBirth, string position, DateTime startDate, double salary)
        {
            Name = name;
            ID = id;
            DateOfBirth = dateOfBirth;
            Position = position;
            StartDate = startDate;
            Salary = salary;
        }

        public double SalaryRaise(DateTime StartDate)
        {
            int totalMonthWorked = ((DateTime.Now.Year - StartDate.Year)*12) + (DateTime.Now.Month - StartDate.Month);
            int totalYearWorked = totalMonthWorked / 12;
            double raiseOfSalary = Salary + Math.Round(Salary * totalYearWorked * 0.1);

            return raiseOfSalary;
        }
        public void listOfEmployees()
        {
            Console.WriteLine($"Employees name: {Name}, ID:{ID}, date of Birth:{DateOfBirth.ToString("dd.MM.yyyy")}, position: {Position}, date of start: {StartDate.ToString("dd.MM.yyyy")}, salary:{SalaryRaise(StartDate)}");
        }

        public void EmployeeInfo()
        {
            Console.WriteLine($"Employees name: {Name}, ID:{ID}, date of Birth:{DateOfBirth.ToString("dd.MM.yyyy")}, position: {Position}, date of start: {StartDate.ToString("dd.MM.yyyy")}, salary:{SalaryRaise(StartDate)}");
        }
    }
}