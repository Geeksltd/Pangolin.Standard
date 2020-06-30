using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Html5;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Remote;

namespace Geeks.Pangolin.Core.Drivers.WebDriver
{
    public interface IExtendedRemoteWebDriver : IWebDriver, IDisposable, ISearchContext, IJavaScriptExecutor, IFindsById, IFindsByClassName, IFindsByLinkText, IFindsByName, IFindsByTagName, IFindsByXPath, IFindsByPartialLinkText, IFindsByCssSelector, ITakesScreenshot, IHasInputDevices, IHasCapabilities, IHasWebStorage, IHasLocationContext, IHasApplicationCache, IAllowsFileDetection, IHasSessionId, IActionExecutor
    {
        bool SupportsAlertIsPresent { get; }
        IWebElement CurrentFrame { get; set; }
        IWebElement CurrentPopup { get; set; }
    }
}
