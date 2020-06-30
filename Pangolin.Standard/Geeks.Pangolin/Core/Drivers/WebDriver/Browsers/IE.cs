using System;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using Microsoft.Win32;

namespace Geeks.Pangolin.Core.Drivers.WebDriver.Browsers
{
    public class IE : SupportedBrowser
    {
        #region [Property]

        #endregion

        #region [Constructor]

        public IE(int servicePort)
        {
            Name = "IE";
            ServicePort = servicePort;
        }

        #endregion

        #region [Public Method]

        public override IExtendedRemoteWebDriver CreateDriver()
        {
            var uri = new Uri($"http://localhost:{ServicePort}");
            return new ExtendedRemoteWebDriver(uri, GetCapabilities(), supportsAlertIsPresent: false);
        }
        public override DriverService CreateDriverService()
        {
            Prepare();
            var service = InternetExplorerDriverService.CreateDefaultService();
            service.Port = ServicePort;
            service.HideCommandPromptWindow = true;
            return service;
        }

        #endregion

        #region [Private Method]

        private void Prepare()
        {
            // IE11 hack, based on https://code.google.com/p/selenium/wiki/InternetExplorerDriver
            const string keyPath32 = @"HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BFCACHE";
            const string keyPath64 = @"HKEY_LOCAL_MACHINE\SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BFCACHE";
            const string valueName = "iexplore.exe";

            if (Environment.Is64BitOperatingSystem)
            {
                Registry.SetValue(keyPath64, valueName, 0);
            }
            else
            {
                Registry.SetValue(keyPath32, valueName, 0);
            }
        }

        private ICapabilities GetCapabilities(bool headless = false)
        {
            var options = new InternetExplorerOptions();
            return options.ToCapabilities();
        }

        #endregion
    }
}
