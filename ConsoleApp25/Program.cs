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
        int checkcount;
        public bool isFullOrEmpty;
        public void ShowDoctors()
        {
            Console.WriteLine($"Name -> {Name}");
            Console.WriteLine($"Surname -> {Surname}");
            Console.WriteLine($"Experience Year -> {ExperienceYear}");
            Console.WriteLine("Worktime -> "); int count = 0;
            checkcount = 0;
            foreach (var item in WorkTime)
            {
                var isFull = item.Contains("Reserved");
                if (isFull)
                {
                    Console.ForegroundColor = ConsoleColor.Red; ++checkcount;
                }
                if (checkcount == 3)
                {
                    checkcount = 0;
                    isFullOrEmpty = true;
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

        }

        public User(string name, string surname, string email, string phoneNumber)
        {
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        //public User()
        //{
        //    Console.WriteLine("\n\n\n\n\n\n\n\n\t\t\t\t\t================================");
        //    Console.Write("\t\t\t\t\tName ->");
        //    Name = Console.ReadLine();
        //    Console.WriteLine("\t\t\t\t\t================================");
        //    Console.Write("\t\t\t\t\tSurname ->");
        //    Surname = Console.ReadLine();
        //    Console.WriteLine("\t\t\t\t\t================================");
        //    Console.Write("\t\t\t\t\tEmail ->");
        //    Email = Console.ReadLine();
        //    Console.WriteLine("\t\t\t\t\t================================");
        //    Console.Write("\t\t\t\t\tPhone Number ->");
        //    PhoneNumber = Console.ReadLine();
        //    Console.WriteLine("\t\t\t\t\t================================");
        //    System.Threading.Thread.Sleep(2000); Console.Clear();
        //}
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
        public bool CheckPersonRegistration(string Name, string Surname, string Email, string PhoneNumber)
        {
            var checkName = string.IsNullOrEmpty(Name);
            var checkSurname = string.IsNullOrEmpty(Surname);
            var checkMail = Email.Length;
            var checkPhoneNumber = int.TryParse(PhoneNumber, out int result);
            if (checkName)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\tThere is a problem in your name"); return false;
            }
            else if (checkSurname)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\tThere is a problem in your surname"); return false;
            }
            else if (checkMail < 10)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\tThere is a problem in your mail,Mail letters count must be greater than 10"); return false;
            }
            else if (!checkPhoneNumber)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\t\t\t\t\tPhoneNumber must be only digit"); return false;
            }

            return true;
        }
        /// <summary>
        /// All things happen here.
        /// </summary>
        public void Run()
        {

            Console.ForegroundColor = ConsoleColor.Green;
            User person = new User(); string name, surname, email, phonenumber;
            Pediatriya.doctors.Add(Elvin); Travmatologiya.doctors.Add(Samir); Stamotologiya.doctors.Add(Anar);
            Pediatriya.doctors.Add(John); Travmatologiya.doctors.Add(Ismayil); Stamotologiya.doctors.Add(Tofiq);
            while (true)
            {
                do
                {
                    Console.Clear();
                    Console.WriteLine("\n\n\n\n\n\n\n\n\t\t\t\t\t================================");
                    Console.Write("\t\t\t\t\tName ->");
                    name = Console.ReadLine();
                    Console.WriteLine("\t\t\t\t\t================================");
                    Console.Write("\t\t\t\t\tSurname ->");
                    surname = Console.ReadLine();
                    Console.WriteLine("\t\t\t\t\t================================");
                    Console.Write("\t\t\t\t\tEmail ->");
                    email = Console.ReadLine();
                    Console.WriteLine("\t\t\t\t\t================================");
                    Console.Write("\t\t\t\t\tPhone Number ->");
                    phonenumber = Console.ReadLine();
                    Console.WriteLine("\t\t\t\t\t================================");
                    if (!CheckPersonRegistration(name, surname, email, phonenumber))
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        System.Threading.Thread.Sleep(2000);
                    }
                    else
                    {
                        person = new User(name, surname, email, phonenumber);
                    }
                } while (!CheckPersonRegistration(name, surname, email, phonenumber));
                Console.Clear();
                userlist.Add(person);



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
                    int selecttime = 1;
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

                            if (Pediatriya.doctors[line].isFullOrEmpty)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("=================================================================");
                                Console.WriteLine($" {Pediatriya.doctors[line].Name} hekimin bu gun hech vaxti yoxdur");
                                Console.WriteLine("=================================================================");
                                System.Threading.Thread.Sleep(1500);
                                break;
                            }
                            else
                            {
                                ShowTimeTableManagement();
                                selecttime = Convert.ToInt32(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Red;
                                time = Pediatriya.doctors[line].WorkTime[selecttime - 1];
                                if (Pediatriya.doctors[line].WorkTime[selecttime - 1].Contains("Reserved"))
                                {
                                    Console.WriteLine($"{Pediatriya.doctors[line].Name} hekimin {time} vaxti artiq rezerv olunub");
                                    System.Threading.Thread.Sleep(2000);
                                }
                            }

                        } while (Pediatriya.doctors[line].WorkTime[selecttime - 1].Contains("Reserved"));
                        if (!Pediatriya.doctors[line].isFullOrEmpty)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            time = Pediatriya.doctors[line].WorkTime[selecttime - 1];
                            Pediatriya.doctors[line].WorkTime[selecttime - 1] += " Reserved";
                            Console.WriteLine($" {person.Name}  {person.Surname} siz saat {time} de {Pediatriya.doctors[line].Name} hekimin qebuluna yazildiniz");
                            System.Threading.Thread.Sleep(2000);
                        }

                    }
                    else if (selection == 2)
                    {
                        string time;
                        do
                        {

                            if (Travmatologiya.doctors[line].isFullOrEmpty)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("=================================================================");
                                Console.WriteLine($" {Travmatologiya.doctors[line].Name} hekimin bu gun hech vaxti yoxdur");
                                Console.WriteLine("=================================================================");
                                System.Threading.Thread.Sleep(2000);
                                break;
                            }
                            else
                            {
                                ShowTimeTableManagement();
                                selecttime = Convert.ToInt32(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Red;
                                time = Travmatologiya.doctors[line].WorkTime[selecttime - 1];
                                if (Travmatologiya.doctors[line].WorkTime[selecttime - 1].Contains("Reserved"))
                                {
                                    Console.WriteLine($"{Travmatologiya.doctors[line].Name} hekimin {time} vaxti artiq rezerv olunub");
                                    System.Threading.Thread.Sleep(2000);
                                }
                            }
                        } while (Travmatologiya.doctors[line].WorkTime[selecttime - 1].Contains("Reserved"));
                        if (!Travmatologiya.doctors[line].isFullOrEmpty)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            time = Travmatologiya.doctors[line].WorkTime[selecttime - 1];
                            Travmatologiya.doctors[line].WorkTime[selecttime - 1] += " Reserved";
                            Console.WriteLine($" {person.Name}  {person.Surname} siz saat {time} de {Travmatologiya.doctors[line].Name} hekimin qebuluna yazildiniz");
                            System.Threading.Thread.Sleep(2000);
                        }

                    }
                    else if (selection == 3)
                    {
                        string time;
                        do
                        {
                            if (Stamotologiya.doctors[line].isFullOrEmpty)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("=================================================================");
                                Console.WriteLine($" {Stamotologiya.doctors[line].Name} hekimin bu gun hech vaxti yoxdur");
                                Console.WriteLine("=================================================================");
                                System.Threading.Thread.Sleep(2000);
                                break;
                            }
                            else
                            {
                                ShowTimeTableManagement();
                                selecttime = Convert.ToInt32(Console.ReadLine());
                                Console.ForegroundColor = ConsoleColor.Red;
                                time = Stamotologiya.doctors[line].WorkTime[selecttime - 1];
                                if (Stamotologiya.doctors[line].WorkTime[selecttime - 1].Contains("Reserved"))
                                {
                                    Console.WriteLine($"{Stamotologiya.doctors[line].Name} hekimin {time} vaxti artiq rezerv olunub");
                                    System.Threading.Thread.Sleep(2000);
                                }
                            }
                        } while (Stamotologiya.doctors[line].WorkTime[selecttime - 1].Contains("Reserved"));
                        if (!Stamotologiya.doctors[line].isFullOrEmpty)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            time = Stamotologiya.doctors[line].WorkTime[selecttime - 1];
                            Stamotologiya.doctors[line].WorkTime[selecttime - 1] += " Reserved";
                            Console.WriteLine($" {person.Name}  {person.Surname} siz saat {time} de {Stamotologiya.doctors[line].Name} hekimin qebuluna yazildiniz");
                            System.Threading.Thread.Sleep(2000);
                        }

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
