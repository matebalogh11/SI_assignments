using System;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Configuration;
using MathTypes;

namespace MathServiceHost
{
    class Program
    {

        static void Main(string[] args)
        {
            ServiceHost host = new ServiceHost(typeof(MathService), new Uri(ConfigurationManager.AppSettings["baseAddress"]));
            host.AddServiceEndpoint(typeof(IMath), new BasicHttpBinding(), "math");
            host.Open();

            Console.WriteLine("MathService is listening on the following...");
            foreach(ServiceEndpoint e in host.Description.Endpoints)
            {
                Console.WriteLine("{0} ({1})", e.Address.ToString(), e.Binding.Name);
            }
            Console.WriteLine("\nPress [Enter] to terminate.");
            Console.ReadKey();
        }

    }
}
