using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Diagnostics;
using Geeks.Pangolin.Core.Parameters;
using Geeks.Pangolin.Core.Helper;
using System.Net.NetworkInformation;
using System.Linq;

namespace Geeks.Pangolin.Core.Drivers.WebDriver
{
    public class WebDriverManager
    {
        #region [Property]

        private Dictionary<int, IExtendedRemoteWebDriver> Drivers { get; } = new Dictionary<int, IExtendedRemoteWebDriver>();
        DriverService Service;
        private readonly List<string> _processesToCheck = new List<string> {
                "geckodriver.exe",
                "chromedriver.exe",
                "iedriverserver.exe"
            };

        #endregion

        #region [Constructor]

        #endregion

        #region [Public Method]

        public IExtendedRemoteWebDriver StartBrowser(SupportedBrowser supportedBrowser)
        {
            if (IsBrowserWindowOpen(supportedBrowser.ServicePort))
                return Drivers[supportedBrowser.ServicePort];

            var driver = Drivers.TryGet(supportedBrowser.ServicePort);
            if (driver != null)
            {
                driver?.Quit();
                Drivers.Remove(supportedBrowser.ServicePort);
            }

            if (!IsPortOpen(supportedBrowser.ServicePort))
            {
                var service = supportedBrowser.CreateDriverService();
                service.Start();
                Service = service;
            }

            driver = supportedBrowser.CreateDriver();
            Drivers.Add(supportedBrowser.ServicePort, driver);
            driver.Manage().Timeouts().AsynchronousJavaScript = 15.Seconds();
            return driver;


        }
        private static bool IsPortOpen(int port) => IPGlobalProperties.GetIPGlobalProperties().GetActiveTcpListeners().Any(e => e.Port == port);

        public void Quit()
        {
            foreach (var driver in Drivers.Values)
            {
                if (UISetting.Instance.CloseBrowser)
                {
                    try
                    {
                        driver?.Close();
                    }
                    catch (System.Exception err)
                    {
                        Debug.WriteLine(err.ToFullMessage());
                    }
                }

                if (UISetting.Instance.DisposeDriverService)
                {
                    try
                    {
                        driver?.Quit();
                        Service?.Dispose();
                        Drivers.Clear();
                    }
                    catch (System.Exception err)
                    {
                        Debug.WriteLine(err.ToFullMessage());
                    }

                }
            }

        }


        public bool IsBrowserWindowOpen(int port)
        {
            var driver = Drivers.TryGet(port);
            if (driver == null)
                return false;
            try
            {
                if (driver.WindowHandles?.Count == 0)
                    return false;
                if (driver.SupportsAlertIsPresent)
                    (ExpectedConditions.AlertIsPresent().Invoke(driver))?.Accept();
                driver.SwitchTo().DefaultContent();
                return driver.Url.Length > -1;
            }
            catch (UnhandledAlertException)
            {
                driver.SwitchTo().Alert().Accept();
                driver.SwitchTo().DefaultContent();
                return driver.Url.Length > -1;
            }
            catch (NoSuchWindowException)
            {
                return false;
            }
            catch (InvalidOperationException err) when (err.Message.Contains("not reachable"))
            {
                return false;
            }
            catch (WebDriverException err) when (err.Message.Contains("Unable to connect to the remote server"))
            {
                return false;
            }
        }

        public void SwitchToTab(IExtendedRemoteWebDriver driver, string name)
        {
            var windowHandles = driver.WindowHandles;
            var currentHandle = driver.CurrentWindowHandle;
            if (driver == null)
                return;
            try
            {
                var numberOfFoundWindows = 0;
                var foundHandle = string.Empty;
                foreach (var window in windowHandles)
                {
                    driver.SwitchTo().Window(window);
                    if (driver.Title == name)
                    {
                        foundHandle = window;
                        ++numberOfFoundWindows;
                    }
                }

                if (numberOfFoundWindows > 1)
                {
                    throw new NoSuchWindowException($"Multiple windows with {name} in their titles detected.");
                }
                else if (numberOfFoundWindows == 0)
                {
                    driver.SwitchTo().Window(currentHandle);
                }
                else
                {
                    driver.SwitchTo().Window(foundHandle);
                }
            }
            catch (NoSuchWindowException)
            {
                return;
            }
            catch (InvalidOperationException err) when (err.Message.Contains("not reachable"))
            {
                return;
            }
        }

        public void BringBrowserFront(int port)
        {
            try
            {
                var driver = Drivers.TryGet(port);
                if (driver != null)
                {
                    if (!UISetting.Instance.Headless)
                        driver.Manage().Window.Maximize();
                    else
                        driver.Manage().Window.Size = AppConstants.BrowserSize;
                }
            }
            catch (InvalidOperationException err) when (err.Message.Contains("not reachable"))
            {
                return;
            }
        }

        #endregion

        #region [Private Method]

        private void KillDrivers()
        {
            foreach (var processname in _processesToCheck)
            {
                var p = new ProcessStartInfo("cmd.exe", "/C " + $"taskkill /f /im {processname}");
                p.UseShellExecute = false;
                p.RedirectStandardOutput = true;
                var proc = new Process();
                proc.StartInfo = p;
                proc.Start();
                proc.WaitForExit();
                proc.Close();
            }
        }

        #endregion
    }
}
