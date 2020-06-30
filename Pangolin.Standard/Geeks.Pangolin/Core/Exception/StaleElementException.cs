using System.Runtime.Serialization;

namespace Geeks.Pangolin.Core.Exception
{
    public class StaleElementException : System.Exception
    {
        private new const string Message = "This element has been removed from the DOM. Geeks.Pangolin will normally re-find elements using the original locators in this situation, except if you have captured a snapshot list of all matching elements using FindAllCss() or FindAllXPath()";

        public StaleElementException()
            : base(Message)
        {
        }

        public StaleElementException(System.Exception innerException)
            : base(Message, innerException)
        {
        }

        public StaleElementException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }
    }
}
