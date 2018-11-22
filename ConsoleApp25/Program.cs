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
            "09:00 - 11:00","12:00 - 14:00","15:00 - 17:00"
        };
        public void ShowDoctors()
        {
            Console.WriteLine($"Name -> {Name}");
            Console.WriteLine($"Surname -> {Surname}");
            Console.WriteLine($"Experience Year -> {ExperienceYear}");
            Console.WriteLine("Worktime -> "); int count = 0; int checkcount = 0;
            foreach (var item in WorkTime)
            {
                var isFull = item.Contains("Reserved");
                if (isFull)
                {
                    Console.ForegroundColor = ConsoleColor.Red; checkcount++;
                }
                Console.Write($" |{++count}| {item}");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine();
            }
        }
    }
    class User : Person
    {
        public User()
        {
            Console.WriteLine("\n\n\n\n\n\n\n\n\t\t\t\t\t================================");
            Console.Write("\t\t\t\t\tName ->");
            Name = Console.ReadLine();
            Console.WriteLine("\t\t\t\t\t================================");
            Console.Write("\t\t\t\t\tSurname ->");
            Surname = Console.ReadLine();
            Console.WriteLine("\t\t\t\t\t================================");
            Console.Write("\t\t\t\t\tEmail ->");
            Email = Console.ReadLine();
            Console.WriteLine("\t\t\t\t\t================================");
            Console.Write("\t\t\t\t\tPhone Number ->");
            PhoneNumber = Console.ReadLine();
            Console.WriteLine("\t\t\t\t\t================================");
            System.Threading.Thread.Sleep(2000); Console.Clear();
        }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
    }
    class Section
    {
        public List<Doctor> doctors = new List<Doctor>();
        public void ShowAllDoctors()
        {
            int count = 0;
            foreach (var item in doctors)
            {
                Console.WriteLine($" ({++count}) LINE");
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
        Doctor John = new Doctor("John", "Jane", 1);
        Doctor Ismayil = new Doctor("Ismayil", "Ismayilli", 1);
        Doctor Tofiq = new Doctor("Tofiq", "Tofiq", 1);
        Section Pediatriya = new Section();
        Section Travmatologiya = new Section();
        Section Stamotologiya = new Section();
        public bool CheckPersonRegistration(User person)
        {
            var checkName = string.IsNullOrEmpty(person.Name);
            var checkSurname = string.IsNullOrEmpty(person.Surname);
            var checkMail = person.Email.Length;
            var checkPhoneNumber = int.TryParse(person.PhoneNumber, out int result);
            if (!checkName && !checkSurname && checkMail > 10 && checkPhoneNumber) return true;
            return false;
        }
        /// <summary>
        /// All things happen here.
        /// </summary>
        public void Run()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            User person = new User();
            userlist.Add(person);
            Pediatriya.doctors.Add(Elvin); Travmatologiya.doctors.Add(Samir); Stamotologiya.doctors.Add(Anar);
            Pediatriya.doctors.Add(John); Travmatologiya.doctors.Add(Ismayil); Stamotologiya.doctors.Add(Tofiq);
            while (true)
            {
                ShowSectionOfHospital();
                Console.Write("Select - >");
                int selection = Convert.ToInt32(Console.ReadLine()); bool boolselection;
                Console.Clear();
                switch (selection)
                {
                    case 1:
                        {
                            Console.WriteLine("===================================");
                            Console.WriteLine("       Pediatriya Section");
                            Console.WriteLine("===================================");
                            Pediatriya.ShowAllDoctors(); boolselection = true;
                            break;
                        }
                    case 2:
                        {
                            Console.WriteLine("===================================");
                            Console.WriteLine("       Travmatologiya Section");
                            Console.WriteLine("===================================");
                            Travmatologiya.ShowAllDoctors(); boolselection = true;
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("===================================");
                            Console.WriteLine("       Stamotologiya Section");
                            Console.WriteLine("===================================");
                            Stamotologiya.ShowAllDoctors(); boolselection = true;
                            break;
                        }
                    default: boolselection = false; break;
                }
                if (boolselection)
                {
                    int selecttime;
                    Console.WriteLine("=================================================");
                    Console.WriteLine("Please write LINE of Doctor -> (for example 1,2,3) ->");
                    Console.WriteLine("=================================================");
                    int line = Convert.ToInt32(Console.ReadLine());
                    --line;
                    if (selection == 1)//Pediatriya
                    {
                        string time;
                        do
                        {
                            ShowTimeTableManagement();
                            selecttime = Convert.ToInt32(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Red;
                            time = Pediatriya.doctors[line].WorkTime[selecttime - 1];
                            if (Pediatriya.doctors[line].WorkTime[selecttime - 1].Contains("Reserved"))
                            {
                                Console.WriteLine($"{Pediatriya.doctors[line].Name} hekimin {time} vaxti artiq rezerv olunub");
                            }
                        } while (Pediatriya.doctors[line].WorkTime[selecttime - 1].Contains("Reserved"));
                        Console.ForegroundColor = ConsoleColor.Green;
                        time = Pediatriya.doctors[line].WorkTime[selecttime - 1];
                        Pediatriya.doctors[line].WorkTime[selecttime - 1] += " Reserved";
                        Console.WriteLine($" {person.Name}  {person.Surname} siz saat {time} de {Pediatriya.doctors[line].Name} hekimin qebuluna yazildiniz");
                    }
                    else if (selection == 2)
                    {
                        string time;
                        do
                        {

                            ShowTimeTableManagement();
                            selecttime = Convert.ToInt32(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Red;
                            time = Travmatologiya.doctors[line].WorkTime[selecttime - 1];
                            if (Travmatologiya.doctors[line].WorkTime[selecttime - 1].Contains("Reserved"))
                            {
                                Console.WriteLine($"{Travmatologiya.doctors[line].Name} hekimin {time} vaxti artiq rezerv olunub");
                            }
                        } while (Travmatologiya.doctors[line].WorkTime[selecttime - 1].Contains("Reserved"));
                        Console.ForegroundColor = ConsoleColor.Green;
                        time = Travmatologiya.doctors[line].WorkTime[selecttime - 1];
                        Travmatologiya.doctors[line].WorkTime[selecttime - 1] += " Reserved";
                        Console.WriteLine($" {person.Name}  {person.Surname} siz saat {time} de {Travmatologiya.doctors[line].Name} hekimin qebuluna yazildiniz");
                    }
                    else if (selection == 3)
                    {
                        string time;
                        do
                        {
                            ShowTimeTableManagement();
                            selecttime = Convert.ToInt32(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Red;
                            time = Stamotologiya.doctors[line].WorkTime[selecttime - 1];
                            if (Stamotologiya.doctors[line].WorkTime[selecttime - 1].Contains("Reserved"))
                            {
                                Console.WriteLine($"{Stamotologiya.doctors[line].Name} hekimin {time} vaxti artiq rezerv olunub");
                            }
                        } while (Stamotologiya.doctors[line].WorkTime[selecttime - 1].Contains("Reserved"));
                        Console.ForegroundColor = ConsoleColor.Green;
                        time = Stamotologiya.doctors[line].WorkTime[selecttime - 1];
                        Stamotologiya.doctors[line].WorkTime[selecttime - 1] += " Reserved";
                        Console.WriteLine($" {person.Name}  {person.Surname} siz saat {time} de {Stamotologiya.doctors[line].Name} hekimin qebuluna yazildiniz");
                    }
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
        public void ShowTimeTableManagement()
        {
            Console.WriteLine("===================================");
            Console.WriteLine("Select time section -> |1| |2| |3|");
            Console.WriteLine("===================================");
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
