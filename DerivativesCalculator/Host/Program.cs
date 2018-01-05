using System;
using DerivativesCalculatorService;
using System.ServiceModel;

namespace Host
{
    class Program
    {
        static void Main(string[] args)
        {
            Type serviceType = typeof(Calculator);
            using (ServiceHost host = new ServiceHost(serviceType))
            {
                host.Open();
                Console.WriteLine("The derivatives calculator seervice is available.");
                Console.ReadKey();
            }
        }
    }
}
 