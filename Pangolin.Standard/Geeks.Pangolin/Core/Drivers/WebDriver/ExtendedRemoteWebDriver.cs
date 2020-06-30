using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;

namespace Geeks.Pangolin.Core.Drivers.WebDriver
{
    public class ExtendedRemoteWebDriver : RemoteWebDriver, IExtendedRemoteWebDriver
    {
        #region [Property]

        #endregion

        #region [Constructor]

        public ExtendedRemoteWebDriver(Uri remoteAddress, ICapabilities desiredCapabilities, bool supportsAlertIsPresent)
            : base(remoteAddress, desiredCapabilities, TimeSpan.FromMinutes(5))
        {
            this.SupportsAlertIsPresent = supportsAlertIsPresent;
        }

        #endregion

        #region [Public Method]

        public bool SupportsAlertIsPresent { get; private set; }
        public IWebElement CurrentFrame { get; set; }
        public IWebElement CurrentPopup { get; set; }

        #endregion

        #region [Private Method]

        #endregion
    }
}
