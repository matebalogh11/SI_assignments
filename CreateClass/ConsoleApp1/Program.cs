using System;

namespace Codecool
{
    class Person
    {
        public String Name { get; set; }
        public DateTime BirthDate { get; set; }
        public Genders Gender { get; set; }

        public Person(String Name, DateTime BirthDate, Genders Gender)
        {
            this.Name = Name;
            this.BirthDate = BirthDate;
            this.Gender = Gender;
        }

        public static void Main(string[] args)
        {

            Person person = new Person("Julie Smith", new DateTime(1983, 11, 3), Genders.FEMALE);

            Employee worker = new Employee("Joe Fahey", new DateTime(1965, 2, 15), Genders.MALE, 1500, "plumber");
            worker.Room = new Room(13);

            Employee worker2 = (Employee) worker.Clone();
            worker2.Name = "Rod Bushman";
            worker2.Room.RoomNumber = 123;

            Console.WriteLine(person.ToString());
            Console.WriteLine(worker.ToString());
            Console.WriteLine("Now let's see the clone!");
            Console.WriteLine(worker2.ToString());
            Console.ReadKey();
        }

        override
            public String ToString()
        {
            return $"Name: {Name}, Birth date: {BirthDate.ToString("yyyy MM dd")}, Gender: {Gender}";
        }
    }

    enum Genders
    {
        MALE,
        FEMALE
    }
}