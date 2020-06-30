using System;

namespace Geeks.Pangolin.Core.Exception
{
    [Serializable]
    public class ElementIsMaskedException : ApplicationException
    {
        public ElementIsMaskedException() { }
        public ElementIsMaskedException(string message) : base(message) { }
        public ElementIsMaskedException(string message, System.Exception inner) : base(message, inner) { }
        protected ElementIsMaskedException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
