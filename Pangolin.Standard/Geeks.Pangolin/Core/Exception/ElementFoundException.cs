using System;

namespace Geeks.Pangolin.Core.Exception
{
    [Serializable]
    public class ElementFoundException : ApplicationException
    {
        public ElementFoundException() { }
        public ElementFoundException(string message) : base(message) { }
        public ElementFoundException(string message, System.Exception inner) : base(message, inner) { }
        protected ElementFoundException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
