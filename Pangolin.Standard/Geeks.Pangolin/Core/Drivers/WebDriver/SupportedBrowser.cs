using OpenQA.Selenium;

namespace Geeks.Pangolin.Core.Drivers.WebDriver
{
    public abstract class SupportedBrowser
    {
        public string Name { get; set; }
        public int ServicePort { get; set; }
        public abstract IExtendedRemoteWebDriver CreateDriver();
        public abstract DriverService CreateDriverService();
    }
}
