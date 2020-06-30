using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using Geeks.Pangolin.Core.Dom;
using Geeks.Pangolin.Core.Exception;
using Geeks.Pangolin.Core.Helper;
using Geeks.Pangolin.Core.Helper.Enums;
using Geeks.Pangolin.Service.Dom;
using Geeks.Pangolin.Service.Helper.Extensions;

namespace Geeks.Pangolin.Service.Commands
{
    partial class WebCommand
    {
        #region [Property]

        #endregion

        #region [Constructor]

        #endregion

        #region [Public Method]

        protected override ClickOutcome ExecuteClick(Element element)
        {
            var webElement = (element as WebElement);
            ((IJavaScriptExecutor)WebContext.Browser).ExecuteScript("arguments[0].scrollIntoView(true);", webElement.DomElement);
            PerformClick(webElement);
            return GetClickResult();
        }

        #endregion

        #region [Private Method]

        private void PerformClick(WebElement webElement)
        {
            try
            {
                webElement.DomElement.Click();
            }
            catch (InvalidOperationException err)
            {
                try
                {
                    if (err.Message.Contains("tt-suggestion"))
                        webElement.DomElement.SendKeys(OpenQA.Selenium.Keys.Escape);
                    else
                        WebContext.Browser.ExecuteScript("window.scrollBy(0,50);");
                }
                catch (InvalidOperationException ex) when (ex.Message.Contains("Element is not clickable at point"))
                {
                    throw new ElementIsMaskedException("Element is not clickable. Another element is masking it.");
                }
            }
            catch (WebDriverException ex) when (ex.Message.Contains("is not clickable at point"))
            {
                WebContext.Browser.ExecuteScript("window.scrollBy(0,50);");
                webElement.DomElement.Click();
            }
        }

        private ClickOutcome GetClickResult()
        {
            try
            {
                WebContext.Browser.SwitchToIframeIfNecessary();
                WebContext.Browser.Manage().Timeouts().AsynchronousJavaScript = 120.Seconds();
                var result = WebContext.Browser.ExecuteAsyncScript(@"var callback = arguments[arguments.length - 1];
                    if (typeof(page)==='undefined') return callback(null);

                    function getResult() {
                        return { 'isAjaxNavigate': (page.isAjaxRedirecting || false), 'isOpeningModal': (page.isOpeningModal || false), 'isClosingModal': (page.isClosingModal || false) };
                    }

                    if (page.isAwaitingAjaxResponse) {
                        console.log('Detected Awaiting Ajax Response');
                        var waitLoop = setInterval(function() {
                            if (!page.isAwaitingAjaxResponse) {
                                clearInterval(waitLoop);
                                callback(getResult());
                            }
                        }, 10);
                    }
                    else
                    {
                        callback(getResult());
                    }") as Dictionary<string, object>;


                if (result == null)
                    return ClickOutcome.Unknown;

                if ((bool)result["isAjaxNavigate"])
                    return ClickOutcome.PartialUpdate;

                if ((bool)result["isOpeningModal"])
                    return ClickOutcome.OpenModal;

                if ((bool)result["isClosingModal"])
                    return ClickOutcome.CloseModal;

                return ClickOutcome.Unknown;
            }
            catch (Exception err) when (err.Message.Contains("document unloaded while waiting for result")
                                        || err.Message.Contains("Cannot find execution context with given id")
                                        || err.Message.Contains("Cannot find context with specified id"))
            {
                return ClickOutcome.Unknown;
            }
            catch(UnhandledAlertException ex)
            {
                return ClickOutcome.Unknown;
            }
            catch(Exception ex)
            {
                return ClickOutcome.Unknown;
            }
        }

        #endregion
    }
}
