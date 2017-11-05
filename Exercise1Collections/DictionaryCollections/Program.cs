using System;
using System.Collections;

namespace DictionaryCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Hashtable myTable = new Hashtable();
            myTable.Add("1", "one");
            myTable.Add("2", "two");
            myTable.Add("3", "three");
            myTable.Add("4", "four");
            myTable.Add("5", "five");
            myTable.Add("6", "six");
            myTable.Add("7", "seven");
            myTable.Add("8", "eight");
            myTable.Add("9", "nine");

            string nums = "123456789";
            foreach (char num in nums)
            {
                string n = num.ToString();
                if (myTable.ContainsKey(n))
                {
                    Console.WriteLine(myTable[n]);
                }
            }
            Console.ReadKey();
        }
    }
}
