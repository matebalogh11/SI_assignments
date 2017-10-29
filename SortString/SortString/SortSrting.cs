using System;
using System.Linq;

namespace ConsoleApp2
{
    class SortString
    {
        static void Main(string[] args)
        {
            string str = "I have a small doggo who cannot behave!";
            String[] words = str.Split();
            words.ToList().ForEach(Console.WriteLine);
            Array.Sort(words);
            str = string.Join(" ", words);
            Console.WriteLine(Environment.NewLine + str);
            Console.ReadKey();
        }
    }
}
