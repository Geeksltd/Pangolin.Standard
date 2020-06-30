using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using Geeks.Pangolin.Core.Parameters;
using Geeks.Pangolin.Core.Helper;

namespace Geeks.Pangolin.Core.Drivers.WebDriver.Browsers
{
    public class Firefox : SupportedBrowser
    {
        #region [Property]

        #endregion

        #region [Constructor]

        public Firefox(int servicePort)
        {
            Name = "Firefox";
            ServicePort = servicePort;
        }

        #endregion

        #region [Public Method]

        public override IExtendedRemoteWebDriver CreateDriver()
        {
            var uri = new Uri($"http://localhost:{ServicePort}");
            var driver = new ExtendedRemoteWebDriver(uri, GetCapabilities(UISetting.Instance.Headless), supportsAlertIsPresent: false);
            return driver;
        }
        public override DriverService CreateDriverService()
        {
            var service = FirefoxDriverService.CreateDefaultService();
            service.Port = ServicePort;
            service.HideCommandPromptWindow = true;
            return service;
        }

        #endregion

        #region [Private Method]

        private ICapabilities GetCapabilities(bool headless = false)
        {
            var profile = new FirefoxProfile();
            profile.SetPreference("browser.download.folderList", 2);
            profile.SetPreference("browser.download.dir", UISetting.Instance.DownloadUrl);
            profile.SetPreference("browser.download.alertOnEXEOpen", false);
            profile.SetPreference("browser.helperApps.neverAsksaveToDisk", "application/x-msexcel,application/excel,application/x-excel,application/excel,application/x-excel,application/excel,application/vnd.ms-excel,application/x-excel,application/x-msexcel,application/vnd.openxmlformats-officedocument.wordprocessingml.document, aapplication/octet-stream, aapplication/pdf, atext/plain, aapplication/vnd.ms-powerpoint, aimage/jpeg, aimage/png, aimage/gif, atext/csv, aapplication/x-rar-compressed, aapplication/zip, aapplication/msword, aapplication/vnd.openxmlformats-officedocument.spreadsheetml.sheet, aapplication/vnd.ms-excel, aapplication/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            profile.SetPreference("browser.download.manager.focusWhenStarting", false);
            profile.SetPreference("browser.helperApps.alwaysAsk.force", false);
            profile.SetPreference("browser.download.manager.alertOnEXEOpen", false);
            profile.SetPreference("browser.download.manager.closeWhenDone", false);
            profile.SetPreference("browser.download.manager.showAlertOnComplete", false);
            profile.SetPreference("browser.download.manager.useWindow", false);
            profile.SetPreference("browser.helperApps.neverAsk.saveToDisk", "application/x-msexcel,application/excel,application/x-excel,application/excel,application/x-excel,application/excel,application/vnd.ms-excel,application/x-excel,application/x-msexcel,application/vnd.openxmlformats-officedocument.wordprocessingml.document, aapplication/octet-stream, aapplication/pdf, atext/plain, aapplication/vnd.ms-powerpoint, aimage/jpeg, aimage/png, aimage/gif, atext/csv, aapplication/x-rar-compressed, aapplication/zip, aapplication/msword, aapplication/vnd.openxmlformats-officedocument.spreadsheetml.sheet, aapplication/vnd.ms-excel, aapplication/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            profile.SetPreference("services.sync.prefs.sync.browser.download.manager.showWhenStarting", false);
            profile.SetPreference("pdfjs.disabled", true);

            profile.Port = ServicePort;
            var options = new FirefoxOptions
            {
                AcceptInsecureCertificates = true
            };

            if (headless)
            {
                options.AddArgument("--headless");
                options.AddArgument("--disable-gpu");
                options.AddArgument($"window-size={AppConstants.BrowserSize.Width},{AppConstants.BrowserSize.Height}");
            }
            options.AddArgument("--disable-extensions");
            options.AddArgument("--disable-popup-blocking");
            options.AddArgument("start-maximized");
            options.AddArgument("--no-sandbox");
            options.AddArgument($"--window-position=0,0");

            options.Profile = profile;
            options.AddAdditionalCapability("moz:webdriverClick", false, true);
            return options.ToCapabilities();
        }

        #endregion
    }
}
