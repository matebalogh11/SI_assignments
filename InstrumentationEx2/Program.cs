using System;
using System.Diagnostics;

namespace InstrumentationEx2
{
    class Program
    {
        static void Main(string[] args)
        {

            EventLog MyLog = new EventLog("X", "localhost", "Demo");
            Trace.AutoFlush = true;
            EventLogTraceListener MyListener = new EventLogTraceListener(MyLog);
            Trace.WriteLine("This is a test");
            Console.ReadKey();
        }
    }
}
