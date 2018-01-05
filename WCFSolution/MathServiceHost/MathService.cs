using System;
using MathTypes;

namespace MathServiceHost
{
    class MathService : IMath
    {
        public MathResponse Add(MathRequest req)
        {
            return new MathResponse(req.x + req.y);
        }

        public MathResponse Divide(MathRequest req)
        {
            return new MathResponse(req.x / req.y);
        }

        public MathResponse Multiply(MathRequest req)
        {
            return new MathResponse(req.x * req.y);
        }

        public MathResponse Subtract(MathRequest req)
        {
            return new MathResponse(req.x - req.y);
        }
    }
}
