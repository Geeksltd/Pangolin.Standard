using System.Runtime.Serialization;

namespace Geeks.Pangolin.Core.Exception
{
    public class MissingDialogException : FinderException
    {
        public MissingDialogException(string message)
            : base(message)
        {
        }

        public MissingDialogException(string message, System.Exception innerException)
            : base(message, innerException)
        {
        }

        public MissingDialogException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
