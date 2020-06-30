using System;

namespace Geeks.Pangolin.Core.Exception
{
    [Serializable]
    public class SyntaxErrorException : ApplicationException
    {
        public SyntaxErrorException() { }
        public SyntaxErrorException(string message) : base(message) { }
        public SyntaxErrorException(string message, System.Exception inner) : base(message, inner) { }
        protected SyntaxErrorException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
