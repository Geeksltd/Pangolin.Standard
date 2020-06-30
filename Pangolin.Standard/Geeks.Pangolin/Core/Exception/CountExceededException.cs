using System.Runtime.Serialization;

namespace Geeks.Pangolin.Core.Exception
{
    public class CountExceededException : System.Exception
    {
        public CountExceededException(string message) : base(message)
        {
        }

        public CountExceededException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        public CountExceededException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
