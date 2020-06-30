using System.Runtime.Serialization;

namespace Geeks.Pangolin.Core.Exception
{
    public class CommandException : System.Exception
    {
        public CommandException(string message) : base(message)
        {
        }

        public CommandException(string message, System.Exception innerException) : base(message, innerException)
        {
        }

        public CommandException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
