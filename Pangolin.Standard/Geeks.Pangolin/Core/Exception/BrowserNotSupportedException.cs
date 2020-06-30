using System;

namespace Geeks.Pangolin.Core.Exception
{
    public class BrowserNotSupportedException : System.Exception
    {
        public BrowserNotSupportedException(Browser browser, Type driverType)
            : this(browser, driverType, null)
        {
        }

        public BrowserNotSupportedException(Browser browser, Type driverType, System.Exception inner)
            : base(string.Format("{0} is not supported by {1}", browser, driverType.Name), inner)
        {
        }
    }
}
