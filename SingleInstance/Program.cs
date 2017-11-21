using System;
using System.Threading;

namespace SingleInstance
{
    class Program
    {
        static void Main(string[] args)
        {
            Mutex mutex = null;
            const string mutexName = "RUNMEONLYONCE";
            while (true)
            {
                try
                {
                    mutex = Mutex.OpenExisting(mutexName);
                    Console.WriteLine("Mutex found!");
                    mutex.Close();
                    break;
                }
                catch (WaitHandleCannotBeOpenedException)
                {
                    Mutex mutex2 = new Mutex(true, mutexName);
                    Console.WriteLine("Mutex not found, created.");
                }
            }
            Console.ReadKey();
        }
    }
}
