using System;
using System.Collections.Generic;
using Geeks.Pangolin.Core.Dom;

namespace Geeks.Pangolin.Core.Exception
{
    [Serializable]
    public class MultipleElementsFoundException : ApplicationException
    {
        public List<Element> Elements { get; private set; }

        public MultipleElementsFoundException(IEnumerable<Element> elements) : this(elements, "Found multiple elements") { }
        public MultipleElementsFoundException(IEnumerable<Element> elements, string message) : this(elements, message, null) { }
        public MultipleElementsFoundException(IEnumerable<Element> elements, string message, System.Exception inner) : base(message, inner)
        {
            Elements = new List<Element>(elements);
        }

        protected MultipleElementsFoundException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context)
        { }
    }
}
