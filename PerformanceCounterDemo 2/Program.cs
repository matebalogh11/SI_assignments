﻿using System;
using System.Diagnostics;
using System.Management;

namespace PerformanceCounterDemo_2
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteToEventLog();
            Console.ReadKey();
        }

        public static void WriteToEventLog()
        {
            WqlEventQuery DemoQuery = new WqlEventQuery("__InstanceCreationEvent",
                                                        new TimeSpan(0, 0, 1),
                                                        "TargetInstance isa \"Win32_Process\"");
            ManagementEventWatcher DemoWatcher = new ManagementEventWatcher();
            DemoWatcher.Query = DemoQuery;
            DemoWatcher.Options.Timeout = new TimeSpan(0, 0, 30);
            Console.WriteLine("Open an application to trigger an event.");
            ManagementBaseObject e = DemoWatcher.WaitForNextEvent();
            EventLog DemoLog = new EventLog("Chap10Demo");
            DemoLog.Source = "Demo";
            String EventName = ((ManagementBaseObject)e["TargetInstance"])["Name"].ToString();
            Console.WriteLine(EventName);
            DemoLog.WriteEntry(EventName, EventLogEntryType.Information);
            DemoWatcher.Stop();
        }
    }
}
