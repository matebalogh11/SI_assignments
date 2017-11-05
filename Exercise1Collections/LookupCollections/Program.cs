using System;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;

namespace LookupCollections
{
    class Program
    {
        static void Main(string[] args)
        {
            ListDictionary myDict = new ListDictionary(new CaseInsensitiveComparer(CultureInfo.InvariantCulture));
            myDict.Add("Estados Unidos", "United States");
            myDict.Add("Canadá", "Canada");
            myDict.Add("España", "Spain");

            foreach (string key in myDict.Keys)
            {
                if (!myDict[key].Equals("United States")) Console.WriteLine(myDict[key]);
            }
            Console.ReadKey();
        }
    }
}
