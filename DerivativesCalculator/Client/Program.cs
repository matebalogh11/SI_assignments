using DerivativesCalculatorService;
using System;

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Calculator client = new Calculator();
            var result = client.CalculateDerivative(30, new string[] { "symbol" }, new string[] { "function" });
            Console.WriteLine($"Derivative was calculated: {result}");
        }
    }
}
