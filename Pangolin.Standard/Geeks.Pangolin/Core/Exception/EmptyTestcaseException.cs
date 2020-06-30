using System;

namespace Geeks.Pangolin.Core.Exception
{
    [Serializable]
    public class EmptyTestcaseException : ApplicationException
    {
        public EmptyTestcaseException() { }
        public EmptyTestcaseException(string message) : base(message) { }
        public EmptyTestcaseException(string message, System.Exception inner) : base(message, inner) { }
        protected EmptyTestcaseException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
