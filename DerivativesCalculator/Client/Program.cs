using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Press any key when the service is ready!");
            Console.ReadKey();

            DerivativesCalculatorClient proxy = new DerivativesCalculatorClient("DerivativesCalculatorConfiguration");
            decimal result = proxy.CalculateDerivative(3, new string[] { "Codecool" }, new string[] { });
            Console.WriteLine($"Result: {result}");

            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
