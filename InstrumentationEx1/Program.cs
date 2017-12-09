using System;
using System.Diagnostics;

namespace InstrumentationEx1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!EventLog.SourceExists("Demo", "."))
            {
                EventSourceCreationData eventData = new EventSourceCreationData("Demo", "Application");
                eventData.MachineName = ".";
                EventLog.CreateEventSource(eventData);
            }
            EventLog logDemo = new EventLog("Application", ".", "Demo");
            logDemo.WriteEntry("Event written to application log", EventLogEntryType.Information, 234, Convert.ToInt16(3));
        }
    }
}
