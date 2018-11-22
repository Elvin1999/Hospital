﻿using System;
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
            System.Threading.Thread.Sleep(2000);Console.Clear();
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
            userlist.Add(person);
            Pediatriya.doctors.Add(Elvin); Travmatologiya.doctors.Add(Samir); Stamotologiya.doctors.Add(Anar);
            while (true)
            {
                //Console.Clear();
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
                    Console.Write("Please write line of Doctor -> (for example 1,2,3) ->");
                    int line = Convert.ToInt32(Console.ReadLine());
                    --line;
                    if (selection == 1)//Pediatriya
                    {
                        do
                        {
                            Console.WriteLine("Select time section -> |1| |2| |3|");
                            selecttime = Convert.ToInt32(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Red;
                        } while (Pediatriya.doctors[line].WorkTime[selecttime - 1].Contains("Reserved"));
                        Console.ForegroundColor = ConsoleColor.Green;
                        string time = Pediatriya.doctors[line].WorkTime[selecttime - 1];
                        Pediatriya.doctors[line].WorkTime[selecttime - 1] += " Reserved";
                        Console.WriteLine($" {person.Name}  {person.Surname} siz saat {time} de {Pediatriya.doctors[line].Name} hekimin qebuluna yazildiniz");
                    }
                    else if (selection == 2)
                    {
                        do
                        {
                            Console.WriteLine("Select time section -> |1| |2| |3|");
                            selecttime = Convert.ToInt32(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Red;
                        } while (Travmatologiya.doctors[line].WorkTime[selecttime - 1].Contains("Reserved"));
                        Console.ForegroundColor = ConsoleColor.Green;
                        string time = Travmatologiya.doctors[line].WorkTime[selecttime - 1];
                        Travmatologiya.doctors[line].WorkTime[selecttime - 1] += " Reserved";
                        Console.WriteLine($" {person.Name}  {person.Surname} siz saat {time} de {Travmatologiya.doctors[line].Name} hekimin qebuluna yazildiniz");
                    }
                    else if (selection == 3)
                    {
                        do
                        {
                            Console.WriteLine("Select time section -> |1| |2| |3|");
                            selecttime = Convert.ToInt32(Console.ReadLine());
                            Console.ForegroundColor = ConsoleColor.Red;
                        } while (Stamotologiya.doctors[line].WorkTime[selecttime - 1].Contains("Reserved"));
                        Console.ForegroundColor = ConsoleColor.Green;
                        string time = Stamotologiya.doctors[line].WorkTime[selecttime - 1];
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
