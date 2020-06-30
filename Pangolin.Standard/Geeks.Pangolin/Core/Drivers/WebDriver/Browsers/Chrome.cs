using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Geeks.Pangolin.Core.Drivers.Selenium.ChromeRemoteInterface;
using Geeks.Pangolin.Core.Parameters;
using Geeks.Pangolin.Core.Helper;

namespace Geeks.Pangolin.Core.Drivers.WebDriver.Browsers
{
    public class Chrome : SupportedBrowser
    {
        #region [Property]
        

        #endregion

        #region [Constructor]

        public Chrome(int servicePort)
        {
            Name = "Chrome";
            ServicePort = servicePort;
        }

        #endregion

        #region [Public Method]

        public override IExtendedRemoteWebDriver CreateDriver()
        {
            var uri = new Uri($"http://localhost:{ServicePort}");
            var driver = new ExtendedRemoteWebDriver(uri, GetCapabilities(UISetting.Instance.Headless), supportsAlertIsPresent: true);

            if (UISetting.Instance.Headless)
                (new ChromeRemoteInterface(driver)).TryEnableFileDownloading(UISetting.Instance.DownloadUrl);

            return driver;
        }

        public override DriverService CreateDriverService()
        {
            var service = ChromeDriverService.CreateDefaultService();
            service.Port = ServicePort;
            service.EnableVerboseLogging = true;
            service.HideCommandPromptWindow = false;
            return service;
        }

        #endregion

        #region [Private Method]

        private ICapabilities GetCapabilities(bool headless = false)
        {
            var options = new ChromeOptions();

            if (headless)
            {
                options.AddArgument("--headless");
                options.AddArgument("--disable-gpu");
                options.AddArgument($"window-size={AppConstants.BrowserSize.Width},{AppConstants.BrowserSize.Height}");
            }

            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("start-maximized");
            options.AddArgument("--ignore-certificate-errors");
            options.AddArgument("--no-sandbox");
            options.AddArgument($"--window-position=0,0");
            options.LeaveBrowserRunning = true;
            options.AddUserProfilePreference("download.default_directory", new Uri(UISetting.Instance.DownloadUrl));
            return options.ToCapabilities();
        }

        #endregion
    }
}
