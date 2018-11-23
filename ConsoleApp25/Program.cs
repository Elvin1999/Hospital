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
            Console.WriteLine("============================");
            Console.WriteLine($"Name -> {Name}");
            Console.WriteLine("============================");
            Console.WriteLine($"Surname -> {Surname}");
            Console.WriteLine("============================");
            Console.WriteLine($"Experience Year -> {ExperienceYear}");
            Console.WriteLine("============================");
            Console.WriteLine("Worktime -> "); int count = 0;
            Console.WriteLine("============================");
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
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($" ({++count}) LINE");
                Console.ForegroundColor = ConsoleColor.Green;
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
                        System.Threading.Thread.Sleep(3000);
                    }
                    else
                    {
                        person = new User(name, surname, email, phonenumber);
                    }
                } while (!CheckPersonRegistration(name, surname, email, phonenumber));
                Console.Clear();
                userlist.Add(person);
                ShowSectionOfHospital();
                int selection = -1;
                do
                {
                    Console.Write("Select - >");
                    selection = Convert.ToInt32(Console.ReadLine());
                    if (!(selection >= 1 && selection <= 3))
                    {
                        Console.WriteLine("You can select between 1-3");
                    }
                } while (!(selection >= 1 && selection <= 3));
                bool boolselection;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Blue;
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
                Console.ForegroundColor = ConsoleColor.Green;
                if (boolselection)
                {
                    int selecttime = 1;
                    int line = 0;

                    if (selection == 1)//Pediatriya
                    {
                        do
                        {
                            Console.WriteLine("=================================================");
                            Console.WriteLine("Please write LINE of Doctor -> (for example 1,2,3) ->");
                            Console.WriteLine("=================================================");
                            line = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                if (!(line >= 1 && line <= Pediatriya.doctors.Count))
                                {
                                    throw new Exception($"We have only {Pediatriya.doctors.Count} doctors");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(ex.Message);
                                Console.ForegroundColor = ConsoleColor.Green;
                            }

                        } while (!(line >= 1 && line <= Pediatriya.doctors.Count));

                        --line;
                        string time;
                        do
                        {

                            if (Pediatriya.doctors[line].isFullOrEmpty)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("=================================================================");
                                Console.WriteLine($" {Pediatriya.doctors[line].Name} doctor does not have time in this interval");
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
                                    Console.WriteLine($"{Pediatriya.doctors[line].Name} doctor in this time {time} is already reserved ");
                                    System.Threading.Thread.Sleep(3000);
                                }
                            }

                        } while (Pediatriya.doctors[line].WorkTime[selecttime - 1].Contains("Reserved"));
                        if (!Pediatriya.doctors[line].isFullOrEmpty)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            time = Pediatriya.doctors[line].WorkTime[selecttime - 1];
                            Pediatriya.doctors[line].WorkTime[selecttime - 1] += " Reserved";
                            Console.WriteLine($"{person.Name}  {person.Surname} You were written to the doctor {Pediatriya.doctors[line].Name} queue\n in this time {time}  ");
                            System.Threading.Thread.Sleep(3000);
                        }

                    }
                    else if (selection == 2)
                    {
                        do
                        {
                            Console.WriteLine("=================================================");
                            Console.WriteLine("Please write LINE of Doctor -> (for example 1,2,3) ->");
                            Console.WriteLine("=================================================");
                            line = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                if (!(line >= 1 && line <= Travmatologiya.doctors.Count))
                                {
                                    throw new Exception($"We have only {Travmatologiya.doctors.Count} doctors");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(ex.Message);
                                Console.ForegroundColor = ConsoleColor.Green;
                            }

                        } while (!(line >= 1 && line <= Travmatologiya.doctors.Count));

                        --line;
                        string time;
                        do
                        {

                            if (Travmatologiya.doctors[line].isFullOrEmpty)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("=================================================================");
                                Console.WriteLine($" {Travmatologiya.doctors[line].Name} doctor does not have time in this interval");
                                Console.WriteLine("=================================================================");
                                System.Threading.Thread.Sleep(3000);
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
                                    Console.WriteLine($"{Travmatologiya.doctors[line].Name} doctor in this time {time} is already reserved");
                                    System.Threading.Thread.Sleep(3000);
                                }
                            }
                        } while (Travmatologiya.doctors[line].WorkTime[selecttime - 1].Contains("Reserved"));
                        if (!Travmatologiya.doctors[line].isFullOrEmpty)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            time = Travmatologiya.doctors[line].WorkTime[selecttime - 1];
                            Travmatologiya.doctors[line].WorkTime[selecttime - 1] += " Reserved";
                            Console.WriteLine($"{person.Name}  {person.Surname} You were written to the doctor {Travmatologiya.doctors[line].Name} queue\n in this time {time}  ");
                            System.Threading.Thread.Sleep(3000);
                        }

                    }
                    else if (selection == 3)
                    {
                        do
                        {
                            Console.WriteLine("=================================================");
                            Console.WriteLine("Please write LINE of Doctor -> (for example 1,2,3) ->");
                            Console.WriteLine("=================================================");
                            line = Convert.ToInt32(Console.ReadLine());
                            try
                            {
                                if (!(line >= 1 && line <= Stamotologiya.doctors.Count))
                                {
                                    throw new Exception($"We have only {Stamotologiya.doctors.Count} doctors");
                                }
                            }
                            catch (Exception ex)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine(ex.Message);
                                Console.ForegroundColor = ConsoleColor.Green;
                            }

                        } while (!(line >= 1 && line <= Stamotologiya.doctors.Count));
                        --line;
                        string time;
                        do
                        {
                            if (Stamotologiya.doctors[line].isFullOrEmpty)
                            {
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("=================================================================");
                                Console.WriteLine($" {Stamotologiya.doctors[line].Name} doctor does not have time in this interval");
                                Console.WriteLine("=================================================================");
                                System.Threading.Thread.Sleep(3000);
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
                                    Console.WriteLine($"{Stamotologiya.doctors[line].Name} doctor in this time {time} is already reserved");
                                    System.Threading.Thread.Sleep(3000);
                                }
                            }
                        } while (Stamotologiya.doctors[line].WorkTime[selecttime - 1].Contains("Reserved"));
                        if (!Stamotologiya.doctors[line].isFullOrEmpty)
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            time = Stamotologiya.doctors[line].WorkTime[selecttime - 1];
                            Stamotologiya.doctors[line].WorkTime[selecttime - 1] += " Reserved";
                            Console.WriteLine($"{person.Name}  {person.Surname} You were written to the doctor {Stamotologiya.doctors[line].Name} queue \n in this time {time}  ");
                            System.Threading.Thread.Sleep(3000);
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
