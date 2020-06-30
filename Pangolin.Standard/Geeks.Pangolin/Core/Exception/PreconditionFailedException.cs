using System;

namespace Geeks.Pangolin.Core.Exception
{
    [Serializable]
    public class PreconditionFailedException : ApplicationException
    {
        public string PreconditionTestName { get; private set; }

        public PreconditionFailedException() { }

        public PreconditionFailedException(string preconditionTestName, System.Exception inner) : this("Precondition faild: " + preconditionTestName, preconditionTestName, inner) { }

        public PreconditionFailedException(string message, string preconditionTestName) : base(message)
        {
            PreconditionTestName = preconditionTestName;
        }

        public PreconditionFailedException(string message, string preconditionTestName, System.Exception inner) : base(message, inner)
        {
            PreconditionTestName = preconditionTestName;
        }

        protected PreconditionFailedException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
