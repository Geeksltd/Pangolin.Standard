using System.Runtime.Serialization;

namespace Geeks.Pangolin.Core.Exception
{
    public class MissingHtmlException : FinderException
    {
        public MissingHtmlException(string message)
            : base(message)
        {
        }

        public MissingHtmlException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        public MissingHtmlException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
