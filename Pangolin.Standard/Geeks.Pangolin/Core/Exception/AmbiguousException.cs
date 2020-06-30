using System.Runtime.Serialization;

namespace Geeks.Pangolin.Core.Exception
{
    public class AmbiguousException : System.Exception
    {
        public AmbiguousException(string message)
            : base(message)
        {
        }

        public AmbiguousException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        public AmbiguousException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
