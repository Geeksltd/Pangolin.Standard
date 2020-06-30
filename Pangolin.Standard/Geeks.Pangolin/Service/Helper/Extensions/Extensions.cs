using System;
using OpenQA.Selenium;
using Geeks.Pangolin.Core.Helper;
using Geeks.Pangolin.Service.Dom;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Support.UI;
using Geeks.Pangolin.Core.Drivers.WebDriver;

namespace Geeks.Pangolin.Service.Helper.Extensions
{
    public static class Extensions
    {
        #region [Property]

        #endregion

        #region [Constructor]

        #endregion

        #region [Public Method]

        public static void SwitchToIframeIfNecessary(this IExtendedRemoteWebDriver browser)
        {
            if (browser.CurrentFrame == null)
                browser.SwitchTo().DefaultContent();
            try
            {
                var iframe = GetPopupIframe(browser);
                if (iframe != null)
                {
                    try
                    {
                        browser.SwitchTo().Frame(iframe);
                    }
                    catch (System.Exception err) when (err.Message.Contains("no such frame") ||
                                                       err.Message.Contains("element is not attached to the page document"))
                    {}
                }
                browser.CurrentPopup = iframe;
            }
            catch (StaleElementReferenceException)
            {}
        }

        public static bool IsInside(this IWebElement element, Area area, WebElementCache cache = null)
        {
            var location = element.Location;
            var result = true;

            if (element.TagName == "textarea")
                location = element.GetParent().Location;

            if (location.IsEmpty && cache?.TagName == "option")
                location = element.GetParent().Location;

            if (cache?.TagName == "div" && cache?.Classes?[0] == "tt-suggestion")
            {
                try
                {
                    location = element.GetParent().GetParent().GetParent().GetParent().GetParent().GetParent().Location;
                }
                catch
                {
                    location = element.Location;
                }
            }

            if (area.Top.HasValue) result = result && location.Y >= area.Top;
            if (result && area.Bottom.HasValue) result = location.Y < area.Bottom;
            if (result && area.Left.HasValue) result = result && location.X >= area.Left;
            if (result && area.Right.HasValue) result = result && location.X < area.Right;

            return result;
        }

        public static void SafeClick(this IWebElement webElement, IExtendedRemoteWebDriver browser) => (new WebDriverWait(browser, TimeSpan.FromSeconds(20))).Until(ExpectedConditions.ElementToBeClickable(webElement)).Click();

        public static void ClickOn(this IExtendedRemoteWebDriver driver, IWebElement expectedElement)
        {
            try
            {
                driver.WaitUntil((d) => ExpectedConditions.ElementToBeClickable(expectedElement));
                expectedElement.Click();
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("tt-suggestion"))
                    expectedElement.SendKeys(OpenQA.Selenium.Keys.Escape);
                if (IsTerminatingException(ex))
                    throw;

                var originalViewportPosition = driver.ScrollViewportToElement(expectedElement);

                try
                {
                    driver.WaitUntil((d) => driver.IsElementInteractable(expectedElement));
                }
                catch (WebDriverTimeoutException)
                {
                    throw ex;
                }

                expectedElement.Click();
                originalViewportPosition.Restore();
            }
        }

        public static TResult WaitUntil<TResult>(this IExtendedRemoteWebDriver driver, Func<IWebDriver, TResult> waitPredictor, int timeout = 10) => (new WebDriverWait(driver, TimeSpan.FromSeconds(timeout))).Until(waitPredictor);

        public static int GetScrollY(this IExtendedRemoteWebDriver driver)
        {
            return (int)(long)driver.ExecuteScript(@"
        if(typeof window.scrollY != 'undefined'){
            return window.scrollY;
        }else if(typeof document.documentElement.scrollTop != 'undefined'){
            return document.documentElement.scrollTop;
        }
        return 0;
");
        }

        public static string GetSafeFileName(this string fileName) => fileName
                .Replace("%25", "%")
                .Replace("%24", "$")
                .Replace("%40", "@")
                .Replace("%27", "'")
                .Replace("%3B", ";")
                .Replace("%3F", "?")
                .Replace("%2A", "*")
                .Replace("%28", "(")
                .Replace("%29", ")");

       

        #endregion

        #region [Private Method]

        private static IWebElement GetPopupIframe(IExtendedRemoteWebDriver browser)
        {
            var iframes = browser.ExecuteScript(@"
return Array.prototype.slice.call(document.querySelectorAll('span.modal-wrapper6>iframe,span.modal-wrapper>iframe,div.modal-body>iframe'))
.filter(function(e) { return e.offsetWidth>0 || e.offsetHeight>0  })") as ReadOnlyCollection<IWebElement>;

            if (iframes == null || iframes.Count == 0)
                return null;

            return iframes[0];
        }

        private static bool IsTerminatingException(Exception ex) => ex is InvalidOperationException == false && ex is WebDriverException == false;

        private static ViewPortPosition ScrollViewportToElement(this IExtendedRemoteWebDriver driver, IWebElement expectedElement)
        {
            int? originalScrollPosition = null;
            if (expectedElement.Location.Y > driver.GetWindowHeight())
            {
                originalScrollPosition = driver.GetScrollY();
                driver.ExecuteScript($"window.scrollBy(0,{expectedElement.Location.Y + expectedElement.Size.Height});");
            }
            return new ViewPortPosition(originalScrollPosition, driver);
        }

        private static int GetWindowHeight(this IExtendedRemoteWebDriver driver) => (int)(long)driver.ExecuteScript("return window.innerHeight");

        static bool IsElementInteractable(this IExtendedRemoteWebDriver driver, IWebElement element)
        {
            return (bool)driver.ExecuteScript(@"
                return (function(element)
                {
                    function belongsToElement(subElement)
                    {
                        return element == subElement || element.contains(subElement);
                    }
                    var rec = element.getBoundingClientRect();  
                    var elementAtPosition1 = document.elementFromPoint(rec.left, rec.top);
                    var elementAtPosition2 = document.elementFromPoint(rec.left+rec.width/2, rec.top+rec.height/2);
                    var elementAtPosition3 = document.elementFromPoint(rec.left+rec.width/3, rec.top+rec.height/3);
                    return belongsToElement(elementAtPosition1) || belongsToElement(elementAtPosition2) || belongsToElement(elementAtPosition3);
                })(arguments[0]);", element);
        }

        #endregion
    }

    public class ViewPortPosition
    {
        #region [Property]

        private readonly int? scrollPositionY;
        private readonly IExtendedRemoteWebDriver webDriver;

        #endregion

        #region [Constructor]

        public ViewPortPosition(int? scrollPositionY, IExtendedRemoteWebDriver webDriver)
        {
            this.scrollPositionY = scrollPositionY;
            this.webDriver = webDriver;
        }

        #endregion

        #region [Public Method]

        public void Restore()
        {
            if (scrollPositionY != null)
                webDriver.ExecuteScript($"window.scrollBy(0,{scrollPositionY.Value});");
        }

        #endregion

        #region [Private Method]

        #endregion
    }
}
