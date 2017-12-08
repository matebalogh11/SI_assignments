using System;
using System.Diagnostics;

namespace InstrumentationEx1
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!EventLog.SourceExists("Demo", "DESKTOP-27ATJO4"))
            {
                EventSourceCreationData eventData = new EventSourceCreationData("Demo", "Application");
                eventData.MachineName = "DESKTOP-27ATJO4";
                EventLog.CreateEventSource(eventData);
            }
            EventLog logDemo = new EventLog("Demo", "Application", "DESKTOP-27ATJO4");
            logDemo.WriteEntry("Event written to application log", EventLogEntryType.Information, 234, Convert.ToInt16(3));
        }
    }
}
