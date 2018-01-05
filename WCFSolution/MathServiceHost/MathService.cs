using System;
using MathTypes;

namespace MathServiceHost
{
    class MathService : IMath
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        public double Divide(double x, double y)
        {
            return x / y;
        }

        public double Multiply(double x, double y)
        {
            return x * y;
        }

        public double Subtract(double x, double y)
        {
            return x - y;
        }
    }
}
