using OpenQA.Selenium;
using Geeks.Pangolin.Core.Drivers.WebDriver;

namespace Geeks.Pangolin.Core.Helper.Context
{
    public class WebContext : Context
    {
        public string BaseUrl { get; set; }
        public IExtendedRemoteWebDriver Browser { get; set; }
        public IWebElement HtmlElementBeforeLastCommand;
        public IWebElement MainElemetnBeforeLastCommand;
    }
}
