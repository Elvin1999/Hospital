using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace ConsoleApp25
{
    class Person
    {
        public Person() { }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
    class Doctor : Person
    {
        public Doctor(string name, string surname, int experience)
        {
            Name = name;
            Surname = surname;
            ExperienceYear = experience;
        }
        public int ExperienceYear { get; set; }
        public List<string> WorkTime = new List<string>()
        {
            "09:00-11:00","12:00 - 14:00","15:00 - 17:00"
        };
        public void ShowDoctors()
        {
            Console.WriteLine($"Name -> {Name}");
            Console.WriteLine($"Surname -> {Surname}");
            Console.WriteLine($"Experience Year -> {ExperienceYear}");
            Console.Write("Worktime -> ");int count = 0;
            foreach (var item in WorkTime)
            {
                Console.Write($" |{++count}| {item}");
            }
        }
    }
    class User : Person
    {
        public User()
        {
            Console.Write("Name ->");
            Name = Console.ReadLine();
            Console.Write("Surname ->");
            Surname = Console.ReadLine();
            Console.Write("Email ->");
            Email = Console.ReadLine();
            Console.Write("Phone Number ->");
            PhoneNumber = Console.ReadLine();
        }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
    class Section
    {
        public List<Doctor> doctors = new List<Doctor>();
        public void ShowAllDoctors()
        {
            foreach (var item in doctors)
            {
                item.ShowDoctors();
            }
        }
    }
    class Action
    {
        List<User> userlist = new List<User>();
        Doctor Elvin = new Doctor("Elvin", "Camalzade", 20);
        Doctor Samir = new Doctor("Samir", "Osmanli", 2);
        Doctor Anar = new Doctor("Anar", "Ehmedov", 1);
        Section Pediatriya = new Section();
        Section Travmatologiya = new Section();
        Section Stamotologiya = new Section();
        /// <summary>
        /// All things happen here.
        /// </summary>
        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            User person = new User();
            Pediatriya.doctors.Add(Elvin); Travmatologiya.doctors.Add(Samir); Stamotologiya.doctors.Add(Anar);
            ShowSectionOfHospital();
            Console.Write("Select - >");
            int selection = Convert.ToInt32(Console.ReadLine());
            switch (selection)
            {
                case 1:
                    {
                        Pediatriya.ShowAllDoctors();
                        break;
                    }
                case 2:
                    {
                        Travmatologiya.ShowAllDoctors();
                        break;
                    }
                case 3:
                    {
                        Stamotologiya.ShowAllDoctors();
                        break;
                    }
            }

        }
        public void ShowSectionOfHospital()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("========================");
            Console.WriteLine("Pediatriya 1");
            Console.WriteLine("========================");
            Console.WriteLine("Travmatologiya 2");
            Console.WriteLine("========================");
            Console.WriteLine("Stamotologiya 3");
            Console.WriteLine("========================");
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Action action = new Action();
            action.Run();
            Console.WriteLine();
        }
    }
}
