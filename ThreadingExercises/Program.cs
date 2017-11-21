using System;
using System.Threading;

namespace ThreadingExercises
{
    class Program
    {
        static void Main(string[] args)
        {
            ThreadStart myStart = new ThreadStart(Counting);
            Thread t1 = new Thread(myStart);
            Thread t2 = new Thread(myStart);
            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            Console.ReadKey();
        }

        static void Counting()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine($"Current count: {i} thread id: {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(10);
            }
        }
    }
}
