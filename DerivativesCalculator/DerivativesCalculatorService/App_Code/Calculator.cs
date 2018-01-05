using System;

namespace DerivativesCalculatorService
{
    public class Calculator : IDerivativesCalculator
    {
        #region
        public decimal CalculateDerivative(int days, string[] symbols, string[] functions)
        {
            return DateTime.Now.Millisecond;
        }
        #endregion
    }
}
