using System.Runtime.Serialization;

namespace Geeks.Pangolin.Core.Exception
{
    public class FinderException : System.Exception
    {
        public FinderException(string message) : base(message)
        {
        }

        public FinderException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        public FinderException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
