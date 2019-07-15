using System;
using System.Collections.Generic;

namespace Clone_Wars
{
    class Program
    {
        public enum Gender { Male, Female }
        public class Person
        {
            private String name;
            private DateTime birthDate;
            private Gender gender;

            public Person(string name, DateTime birthDate, Gender gender)
            {
                this.name = name;
                this.birthDate = birthDate;
                this.gender = gender;
            }

            public string Name { get => name; set => name = value; }
            public DateTime BirthDate { get => birthDate; set => birthDate = value; }
            internal Gender Gender { get => gender; set => gender = value; }

            public override string ToString()
            {
                return "Person name is: " + name + "\nbirthdate: " + birthDate + "\ngender: " + gender;
            }
        }
        public class Employee : Person, ICloneable
        {
            private int Salary;
            private String Profession;
            private Room room;

            public int Salary1 { get => Salary; set => Salary = value; }
            public string Profession1 { get => Profession; set => Profession = value; }
            internal Room Room { get => room; set => room = value; }

            public Employee(string name, DateTime birthDate, Gender gender, int salary, string profession, Room room) : base(name, birthDate, gender)
            {
                Salary = salary;
                Profession = profession;
                Room = room;
            }

            public object Clone()
            {
                Employee newEmployee = (Employee)this.MemberwiseClone();
                newEmployee.Room = new Room(Room.Number);
                return newEmployee;
            }

            public override string ToString()
            {
                return "Person name is: " + base.Name + "\nbirthdate: " + base.BirthDate + "\ngender: " + base.Gender + "\nsalary: " + Salary
                    + "\nprofession: " + Profession + "\nWorking in room " + Room;
            }
        }

        public class Room
        {
            public int Number;

            public Room(int roomNumber)
            {
                this.Number = roomNumber;
            }

            public int RoomNumber { get => Number; set => Number = value; }

            public override string ToString()
            {
                return Number.ToString();
            }
        }
        static void Main(string[] args)
        {
            Employee Kovacs = new Employee("Géza", DateTime.Now, Gender.Male, 111000, "léhűtő", null);
            Kovacs.Room = new Room(111);
            Employee Kovacs2 = (Employee)Kovacs.Clone();
            Kovacs2.Room.Number = 112;
            Console.WriteLine(Kovacs.ToString());
            Console.WriteLine(Kovacs2.ToString());
            Console.ReadKey();
        }
    }
}
