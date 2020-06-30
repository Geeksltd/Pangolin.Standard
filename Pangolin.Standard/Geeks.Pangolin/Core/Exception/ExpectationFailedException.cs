using System;

namespace Geeks.Pangolin.Core.Exception
{
    [Serializable]
    public class ExpectationFailedException : ApplicationException
    {
        public ExpectationFailedException() { }
        public ExpectationFailedException(string message) : base(message) { }
        public ExpectationFailedException(string message, System.Exception inner) : base(message, inner) { }
        protected ExpectationFailedException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
