using System;

namespace Codecool
{
    class Employee : Person, ICloneable
    {
        public int Salary { get; set; }
        public String Profession { get; set; }
        public Room Room { get; set; }

        public Employee(String Name, DateTime BirthDate, Genders Gender, int Salary, String Profession) 
            : base(Name, BirthDate, Gender)
        {
            this.Salary = Salary;
            this.Profession = Profession;
        }

        public object Clone()
        {
            Employee newEmployee = (Employee)this.MemberwiseClone();
            newEmployee.Room = new Room(Room.RoomNumber);
            return newEmployee;
        }

        override
            public String ToString()
        {
            return $"{base.ToString()}, Salary: {Salary}$, Profession: {Profession}, Room number: {Room.RoomNumber}";
        }

    }
}
