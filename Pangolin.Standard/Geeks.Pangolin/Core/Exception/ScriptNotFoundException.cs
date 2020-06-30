using System;

namespace Geeks.Pangolin.Core.Exception
{
    [Serializable]
    public class ScriptNotFoundException : ApplicationException
    {
        public ScriptNotFoundException() { }
        public ScriptNotFoundException(string message) : base(message) { }
        public ScriptNotFoundException(string message, System.Exception inner) : base(message, inner) { }
        protected ScriptNotFoundException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
