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


            MathRequest request = new MathRequest(23, 44);
            MathResponse response = null;

            response = mathChannel.Add(request);

            Console.WriteLine("Call via basic HTTP binding: {0}", response.result);
            Console.WriteLine("Press Enter to exit.");
            Console.ReadKey();
        }
    }
}
