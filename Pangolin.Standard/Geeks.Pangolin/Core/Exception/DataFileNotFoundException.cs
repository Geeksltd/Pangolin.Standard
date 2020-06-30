using System;

namespace Geeks.Pangolin.Core.Exception
{
    [Serializable]
    public class DataFileNotFoundException : ApplicationException
    {
        public DataFileNotFoundException() { }
        public DataFileNotFoundException(string message) : base(message) { }
        public DataFileNotFoundException(string message, System.Exception inner) : base(message, inner) { }
        protected DataFileNotFoundException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
