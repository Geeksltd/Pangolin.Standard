using System;

namespace Geeks.Pangolin.Core.Exception
{
    [Serializable]
    public class StaleElementReferenceException : System.Exception
    {
        public StaleElementReferenceException() { }
        public StaleElementReferenceException(string message) : base(message) { }
        public StaleElementReferenceException(string message, System.Exception inner) : base(message, inner) { }
        protected StaleElementReferenceException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
