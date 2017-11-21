using System;
using System.Threading;

namespace ThreadPoolDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            WaitCallback myCall = new WaitCallback(ShowMyText);
            ThreadPool.QueueUserWorkItem(myCall, "hello");
            ThreadPool.QueueUserWorkItem(myCall, "hi");
            ThreadPool.QueueUserWorkItem(myCall, "hey");
            ThreadPool.QueueUserWorkItem(myCall, "yo");
            Console.ReadKey();
        }

        static void ShowMyText(object state)
        {
            string myString = "State " + state as string;
            myString += " Thread " + Thread.CurrentThread.ManagedThreadId;
            Console.WriteLine(myString);
        }
    }
}
