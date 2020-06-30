using System;

namespace Geeks.Pangolin.Core.Exception
{
    [Serializable]
    public class ElementNotFoundException : ApplicationException
    {
        public ElementNotFoundException() { }
        public ElementNotFoundException(string message) : base(message) { }
        public ElementNotFoundException(string message, System.Exception inner) : base(message, inner) { }
        protected ElementNotFoundException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
