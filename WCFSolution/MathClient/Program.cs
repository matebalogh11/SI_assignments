using MathTypes;
using System;
using System.ServiceModel;


namespace MathClient
{
    class Program
    {
        static void Main(string[] args)
        {
            IMath mathChannel = new ChannelFactory<IMath>(new BasicHttpBinding(),
                                new EndpointAddress("http://localhost:8080/math")).CreateChannel();

            double sum = mathChannel.Add(2, 3);

            Console.WriteLine("Call via basic HTTP binding: {0}", sum);
            Console.WriteLine("Press Enter to exit.");
            Console.ReadKey();
        }
    }
}
