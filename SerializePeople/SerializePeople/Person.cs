using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace SerializePeople
{
    [Serializable]
    public class Person
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
            Person testPerson = new Person("Adam Test", new DateTime(1983, 11, 3), Genders.MALE);
            Console.WriteLine(testPerson.ToString().Equals("Name: Adam Test, Birth date: 1983 11 03, Gender: MALE"));

            Employee worker = new Employee("Joe Fahey", new DateTime(1965, 2, 15), Genders.MALE, 1500, "plumber");
            worker.Room = new Room(13);

            Employee worker2 = (Employee)worker.Clone();
            worker2.Name = "Rod Bushman";
            worker2.Room.RoomNumber = 123;

            Console.WriteLine(person.ToString());
            Console.WriteLine(worker.ToString());
            Console.WriteLine("Now let's see the clone!");
            Console.WriteLine(worker2.ToString());
            Console.ReadKey();
        }

        public void Serialize(string output)
        {
            using (FileStream stream = new FileStream(output, FileMode.OpenOrCreate))
            {
                BinaryFormatter formatter = new BinaryFormatter();
                try
                {
                    formatter.Serialize(stream, this);
                } catch(SerializationException)
                {
                    Console.WriteLine("Serialization error!");
                }
            }
        }

        public override String ToString()
        {
            return $"Name: {Name}, Birth date: {BirthDate.ToString("yyyy MM dd")}, Gender: {Gender}";
        }
    }

    public enum Genders
    {
        MALE,
        FEMALE
    }
}
