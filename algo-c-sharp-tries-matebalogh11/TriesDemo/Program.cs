using System;
using System.Collections.Generic;
using System.IO;
using TriesLogic;

namespace Tries
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = @"../../../assets/wordlist.txt";
            AutoComplete autoComplete = new AutoComplete();

            using (StreamReader streamReader = new StreamReader(path))
            {
                while (!streamReader.EndOfStream)
                {
                    autoComplete.AddWord(streamReader.ReadLine());
                }
            }

            // Try to write tests to verify your code!
            List<string> result = autoComplete.GetCompletions("spectrog");
            Console.WriteLine($"Result for spectrog: {string.Join(", ", result)}");
            Console.WriteLine("done");
            Console.ReadKey();
        }
    }
}
