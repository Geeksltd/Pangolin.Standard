using System.Runtime.Serialization;

namespace Geeks.Pangolin.Core.Exception
{
    public class MissingWindowException : FinderException
    {
        public MissingWindowException(string message)
            : base(message)
        {
        }

        public MissingWindowException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        public MissingWindowException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
