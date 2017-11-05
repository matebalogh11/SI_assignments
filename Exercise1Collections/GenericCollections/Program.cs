using System;
using System.Collections.Generic;

namespace GenericCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<int, string> myDict = new Dictionary<int, string>();
            myDict.Add(856, "Laos");
            myDict.Add(371, "Latvia");
            myDict.Add(961, "Lebanon");
            myDict.Add(853, "Macau");

            Console.WriteLine(myDict[856]);
            foreach (KeyValuePair<int, string> pair in myDict)
            {
                Console.WriteLine($"Country code: {pair.Key} name: {pair.Value}");
            }
            Console.ReadKey();
        }
    }
}
