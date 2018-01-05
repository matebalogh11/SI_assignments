using System.ServiceModel;
using System.Runtime.Serialization;

namespace MathTypes
{
    [ServiceContract(
        Namespace = "http://example.org/math/contracts")]
    public interface IMath
    {
        [OperationContract]
        MathResponse Add(MathRequest req);
        [OperationContract]
        MathResponse Subtract(MathRequest req);
        [OperationContract]
        MathResponse Multiply(MathRequest req);
        [OperationContract]
        MathResponse Divide(MathRequest req);
    }

    [DataContract(
        Namespace = "http://example.org/math/types")]
    public class MathRequest
    {
        [DataMember]
        public double x;
        [DataMember]
        public double y;

        public MathRequest(double x, double y)
        {
            this.x = x;
            this.y = y;
        }
    }

    [DataContract(
        Namespace = "http://example.org/math/types")]
    public class MathResponse
    {
        [DataMember]
        public double result;

        public MathResponse(double result)
        {
            this.result = result;
        }
    }

    [MessageContract]
    public class MathRequestMessage
    {
        [MessageHeader]
        public int CustomHeader;

        [MessageBodyMember]
        public MathRequest request;
    }

    [MessageContract]
    public class MathResponseMessage
    {
        [MessageBodyMember]
        public MathResponse response;
    }
}
