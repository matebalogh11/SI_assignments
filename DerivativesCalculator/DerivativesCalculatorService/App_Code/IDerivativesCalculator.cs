using System;
using System.ServiceModel;

namespace DerivativesCalculatorService
{
    [ServiceContract]
    public interface IDerivativesCalculator
    {
        [OperationContract]
        Decimal CalculateDerivative(int days, string[] symbols, string[] functions);
    }
}
